using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.Audit;
using Data.DGECM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    [AllowAnonymous]
    public class AuditUsersController : Controller
    {
        private readonly ArtAuditContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly DGECMContext db;
        private readonly IDropDownService _dropSrv;

        public AuditUsersController(ArtAuditContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, DGECMContext db, IDropDownService dropSrv)
        {
            _env = env; _pdfSrv = pdfSrv; context = _context;
            this.db = db;
            _dropSrv = dropSrv;
        }

        //private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtUsersAuditView> data = context.ArtUsersAuditViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(AuditUsersController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {nameof(ArtUsersAuditView.GroupNames)      .ToLower()     , _dropSrv.GetGroupAudNameDropDown().ToDynamicList() },
                    {nameof(ArtUsersAuditView.CreatedBy)       .ToLower()     , _dropSrv.GetUserAudNameDropDown().ToDynamicList() },
                    {nameof(ArtUsersAuditView.LastUpdatedBy)   .ToLower()         , _dropSrv.GetUserAudNameDropDown().ToDynamicList() },
                    {nameof(ArtUsersAuditView.RoleNames)       .ToLower()     , _dropSrv.GetRoleAudNameDropDown().ToDynamicList() },
                    {nameof(ArtUsersAuditView.DomainAccounts)  .ToLower()         , _dropSrv.GetMemberUsersDropDown().ToDynamicList() },
                    {nameof(ArtUsersAuditView.Action)          .ToLower()     , new List<string> { "Add", "Update", "Delete" }.ToDynamicList() },
                    {nameof(ArtUsersAuditView.UserName)        .ToLower()     , _dropSrv.GetRoleAudNameDropDown().ToDynamicList() },

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].SkipList;
            }


            KendoDataDesc<ArtUsersAuditView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }
        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            Microsoft.EntityFrameworkCore.DbSet<ArtUsersAuditView> data = context.ArtUsersAuditViews;
            byte[] bytes = await data.ExportToCSV<ArtUsersAuditView, GenericCsvClassMapper<ArtUsersAuditView, AuditUsersController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(AuditUsersController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AuditUsersController).ToLower()].SkipList;
            List<ArtUsersAuditView> data = context.ArtUsersAuditViews.CallData(req).Data.ToList();
            ViewData["title"] = "ART User Audit Report";
            ViewData["desc"] = "This report Presents all events of users with the related information as below";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

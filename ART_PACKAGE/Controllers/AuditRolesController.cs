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
    public class AuditRolesController : Controller
    {

        private readonly ArtAuditContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly DGECMContext db;
        private readonly IDropDownService _dropSrv;


        public AuditRolesController(ArtAuditContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, DGECMContext db, IDropDownService dropSrv)
        {
            _env = env; _pdfSrv = pdfSrv; context = _context;
            this.db = db;
            _dropSrv = dropSrv;
        }

        //private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtRolesAuditView> data = context.ArtRolesAuditViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(AuditRolesController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {nameof(ArtRolesAuditView.GroupNames)       .ToLower()    , _dropSrv.GetGroupAudNameDropDown().ToDynamicList() },
                    {nameof(ArtRolesAuditView.CreatedBy)        .ToLower()    , _dropSrv.GetUserAudNameDropDown().ToDynamicList() },
                    {nameof(ArtRolesAuditView.LastUpdatedBy)    .ToLower()        , _dropSrv.GetUserAudNameDropDown().ToDynamicList() },
                    {nameof(ArtRolesAuditView.Action)           .ToLower()        , new List<string> { "Add", "Update", "Delete" }.ToDynamicList() },
                    {nameof(ArtRolesAuditView.RoleName)         .ToLower()    , _dropSrv.GetRoleAudNameDropDown().ToDynamicList() },
                    {nameof(ArtRolesAuditView.MemberUsers)      .ToLower()    , _dropSrv.GetMemberUsersDropDown().ToDynamicList() },

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].SkipList;
            }


            KendoDataDesc<ArtRolesAuditView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            Microsoft.EntityFrameworkCore.DbSet<ArtRolesAuditView> data = context.ArtRolesAuditViews;
            byte[] bytes = await data.ExportToCSV<ArtRolesAuditView, GenericCsvClassMapper<ArtRolesAuditView, AuditRolesController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(AuditRolesController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AuditRolesController).ToLower()].SkipList;
            List<ArtRolesAuditView> data = context.ArtRolesAuditViews.CallData(req).Data.ToList();
            ViewData["title"] = "ART Role Audit Report";
            ViewData["desc"] = "This report Presents all events of roles with the related information as below";
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

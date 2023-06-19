using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using Data.DGECM;
using ART_PACKAGE.Helpers.DropDown;

namespace ART_PACKAGE.Controllers
{
    [AllowAnonymous]
    public class AuditRolesController : Controller
    {

        private readonly AuthContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly DGECMContext db;
        private readonly IDropDownService _dropSrv;


        public AuditRolesController(AuthContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, DGECMContext db, IDropDownService dropSrv)
        {
            this._env = env; _pdfSrv = pdfSrv; context = _context;
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


            var Data = data.CallData<ArtRolesAuditView>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = context.ArtRolesAuditViews;
            var bytes = await data.ExportToCSV<ArtRolesAuditView, GenericCsvClassMapper<ArtRolesAuditView, AuditRolesController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(AuditRolesController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(AuditRolesController).ToLower()].SkipList;
            var data = context.ArtRolesAuditViews.CallData<ArtRolesAuditView>(req).Data.ToList();
            ViewData["title"] = "Audit Roles Report";
            ViewData["desc"] = "This report Presents all events of roles with the related information as below";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

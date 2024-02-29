using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Hubs;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "AlertDetails")]
    public class AmlAuditReportController : Controller
    {
        private readonly SasAmlContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;

        public AmlAuditReportController(SasAmlContext dbfcfkc, IDropDownService dropDown, IPdfService pdfSrv, IHubContext<ExportHub> exportHub, UsersConnectionIds connections)
        {
            this.dbfcfkc = dbfcfkc;

            _dropDown = dropDown;
            _pdfSrv = pdfSrv;

            _exportHub = exportHub;
            this.connections = connections;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtAuditReportView> data = dbfcfkc.ArtAuditReportViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(AmlAuditReportController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                };

                ColumnsToSkip = ReportsConfig.CONFIG[nameof(AmlAuditReportController).ToLower()].SkipList;
            }



            KendoDataDesc<ArtAuditReportView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }
        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(AmlAuditReportController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AmlAuditReportController).ToLower()].SkipList;
            List<ArtAuditReportView> data = dbfcfkc.ArtAuditReportViews.CallData(req).Data.ToList();
            ViewData["title"] = "AML Audit Report";
            ViewData["desc"] = "This report presents all users' actions with the related information below";
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

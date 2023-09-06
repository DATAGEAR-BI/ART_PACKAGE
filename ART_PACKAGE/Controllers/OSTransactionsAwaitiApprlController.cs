using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers { 
    //[Authorize(Policy = "Licensed" , Roles = "OSTransactionsAwaitiApprl")]

    
    public class OSTransactionsAwaitiApprlController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;

        public OSTransactionsAwaitiApprlController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiOsTransAwaitiApprlReport> data = fti.ArtTiOsTransAwaitiApprlReports.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {

                DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsAwaitiApprlController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"Fullname".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Fullname).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Descri56".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Descri56).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"MasterRef".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"EventReference".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.EventReference).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Status".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Status).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"PcpAddress1".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.PcpAddress1).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"NpcpAddress1".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.NpcpAddress1).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Ccy".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Lstmoduser".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Lstmoduser).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSTransactionsAwaitiApprlController).ToLower()].SkipList;

            }
            var Data = data.CallData<ArtTiOsTransAwaitiApprlReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {
                },
                reportname = "OSTransactionsAwaitiApprl"
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            var data = fti.ArtTiOsTransAwaitiApprlReports;
            var bytes = await data.ExportToCSV<ArtTiOsTransAwaitiApprlReport, GenericCsvClassMapper<ArtTiOsTransAwaitiApprlReport, OSTransactionsAwaitiApprlController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var data = fti.ArtTiOsTransAwaitiApprlReports.CallData<ArtTiOsTransAwaitiApprlReport>(req).Data.ToList();
            ViewData["title"] = "OS Transactions Awaiti Apprl Report";
            ViewData["desc"] = "This report produces information transactions awaiting credit approval only with the related master records and the related events have been initiated with the related status";

            var DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsAwaitiApprlController).ToLower()].DisplayNames;
            var columnsToPrint = new List<string>()
            { nameof(ArtTiOsTransAwaitiApprlReport.MasterRef)
            , nameof(ArtTiOsTransAwaitiApprlReport.EventReference)
            , nameof(ArtTiOsTransAwaitiApprlReport.PcpAddress1)
            , nameof(ArtTiOsTransAwaitiApprlReport.NpcpAddress1)
            , nameof(ArtTiOsTransAwaitiApprlReport.Amount)
            , nameof(ArtTiOsTransAwaitiApprlReport.Ccy)
            , nameof(ArtTiOsTransAwaitiApprlReport.Status)
            , nameof(ArtTiOsTransAwaitiApprlReport.Lstmoduser)
            };
            var ColumnsToSkip = typeof(ArtTiOsTransAwaitiApprlReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

            if (req.Group is not null && req.Group.Count != 0)
            {
                var pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, this.ControllerContext
                                                   , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
            else
            {
                var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 8
                                                   , User.Identity.Name, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
        }
    }
}

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

namespace ART_PACKAGE.Controllers {
    //[Authorize(Policy = "Licensed" , Roles = "OSLiability")]

    
    public class OSLiabilityController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;


        public OSLiabilityController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiOsLiabilityReport> data = fti.ArtTiOsLiabilityReports.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {


                DisplayNames = ReportsConfig.CONFIG[nameof(OSLiabilityController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"Gfcun".ToLower(),fti.ArtTiOsLiabilityReports.Select(x=>x.Gfcun).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Sovalue".ToLower(),fti.ArtTiOsLiabilityReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"LiabCcy".ToLower(),fti.ArtTiOsLiabilityReports.Select(x=>x.LiabCcy).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSLiabilityController).ToLower()].SkipList;

            }

            var Data = data.CallData<ArtTiOsLiabilityReport>(request, DropDownColumn, DisplayNames: DisplayNames);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {

                },
                reportname = "OSLiability"
            };
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }
        public IActionResult Index()
        {
            //Gfcun
            var defaultGrouping = JsonConvert.SerializeObject(new
            {
                field = nameof(ArtTiOsLiabilityReport.Gfcun)
            }) ;
            ViewBag.defaultGroup = defaultGrouping;
            return View();
        }

        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            var data = fti.ArtTiOsLiabilityReports;
            var bytes = await data.ExportToCSV<ArtTiOsLiabilityReport, GenericCsvClassMapper<ArtTiOsLiabilityReport, OSLiabilityController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var data = fti.ArtTiOsLiabilityReports.CallData<ArtTiOsLiabilityReport>(req).Data.ToList();
            ViewData["title"] = "OS Liability Report";
            ViewData["desc"] = "This report produces totals for outstanding liability";

            var DisplayNames = ReportsConfig.CONFIG[nameof(OSLiabilityController).ToLower()].DisplayNames;
            var columnsToPrint = new List<string>() {nameof(ArtTiOsLiabilityReport.Gfcun)
                , nameof(ArtTiOsLiabilityReport.Sovalue) ,
            nameof(ArtTiOsLiabilityReport.LiabCcy) , nameof(ArtTiOsLiabilityReport.Totliabamt)    };
            var ColumnsToSkip = typeof(ArtTiOsLiabilityReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

            if (req.Group is not null && req.Group.Count != 0)
            {
                var pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, this.ControllerContext
                                                   , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
            else
            {
                var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 4
                                                   , User.Identity.Name, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
        }
    }
}

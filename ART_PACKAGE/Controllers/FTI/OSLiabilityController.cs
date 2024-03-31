using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;
using Data.Services.Grid;

namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "OSLiability")]


    public class OSLiabilityController : Controller
    {
        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;


        public OSLiabilityController(IPdfService pdfSrv, FTIContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiOsLiabilityReport> data = fti.ArtTiOsLiabilityReports.AsQueryable();

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
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

            KendoDataDesc<ArtTiOsLiabilityReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames);
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
            string defaultGrouping = JsonConvert.SerializeObject(new
            {
                field = nameof(ArtTiOsLiabilityReport.Gfcun)
            });
            ViewBag.defaultGroup = defaultGrouping;
            return View();
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            List<ArtTiOsLiabilityReport> data = fti.ArtTiOsLiabilityReports.CallData(req).Data.ToList();
            ViewData["title"] = "OS Liability Report";
            ViewData["desc"] = "This report produces totals for outstanding liability";

            Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(OSLiabilityController).ToLower()].DisplayNames;
            List<string> columnsToPrint = new() {nameof(ArtTiOsLiabilityReport.Gfcun)
                , nameof(ArtTiOsLiabilityReport.Sovalue) ,
            nameof(ArtTiOsLiabilityReport.LiabCcy) , nameof(ArtTiOsLiabilityReport.Totliabamt)    };
            List<string> ColumnsToSkip = typeof(ArtTiOsLiabilityReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

            if (req.Group is not null && req.Group.Count != 0)
            {
                byte[] pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, ControllerContext
                                                   , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
            else
            {
                byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 4
                                                   , User.Identity.Name, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
        }
    }
}

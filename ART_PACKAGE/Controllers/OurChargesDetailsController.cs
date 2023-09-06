using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Services.Pdf;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers {
    //[Authorize(Policy = "Licensed" , Roles = "OurChargesDetails")]

    
    public class OurChargesDetailsController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;

        public OurChargesDetailsController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiChargesDetailsReport> data = fti.ArtTiChargesDetailsReports.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {

                DisplayNames = ReportsConfig.CONFIG[nameof(OurChargesDetailsController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"Hvbad1".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.Hvbad1).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Longname".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.Longname).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"MasterRef".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Address1".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.Address1).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Status".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.Status).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Descr".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.Descr).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"ParticChg".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.ParticChg).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"EventRef".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.EventRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Action".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.Action).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"ChgbasCcy".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.ChgbasCcy).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"SchCcy".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.SchCcy).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"SchRate".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.SchRate).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"ChgCcy".ToLower(),fti.ArtTiChargesDetailsReports.Select(x=>x.ChgCcy).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(OurChargesDetailsController).ToLower()].SkipList;

            }
            var Data = data.CallData<ArtTiChargesDetailsReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {

                },
                reportname = "OurChargesDetails"
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        public IActionResult Index()
        {
            var defaultGrouping = JsonConvert.SerializeObject(new
            {
                field = "MasterRef",
                aggregates = new List<dynamic>
                {
                    new
                    {
                        field = "ChgDueEgp",
                        aggregate = GridAggregateType.sum.ToString()
                    }
                    
                    
                }
            });
            ViewBag.defaultGroup = defaultGrouping;
            return View();
        }

        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            var data = fti.ArtTiChargesDetailsReports;
            var bytes = await data.ExportToCSV<ArtTiChargesDetailsReport, GenericCsvClassMapper<ArtTiChargesDetailsReport, OurChargesDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var data = fti.ArtTiChargesDetailsReports.CallData<ArtTiChargesDetailsReport>(req).Data.ToList();
            ViewData["title"] = "Our Charges Details";
            ViewData["desc"] = "This report produces more detailed analysis of the individual charges for each event";

            var DisplayNames = ReportsConfig.CONFIG[nameof(OurChargesDetailsController).ToLower()].DisplayNames;
            var columnsToPrint = new List<string>() {
                nameof(ArtTiChargesDetailsReport.MasterRef)
               ,nameof(ArtTiChargesDetailsReport.EventRef)
               ,nameof(ArtTiChargesDetailsReport.Address1) 
               ,nameof(ArtTiChargesDetailsReport.Action) 
               ,nameof(ArtTiChargesDetailsReport.Status)
               ,nameof(ArtTiChargesDetailsReport.ChgDue)
               ,nameof(ArtTiChargesDetailsReport.ChgCcy)
               ,nameof(ArtTiChargesDetailsReport.SchAmt)
               ,nameof(ArtTiChargesDetailsReport.Descr)    
            };
            var ColumnsToSkip = typeof(ArtTiChargesDetailsReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

            if (req.Group is not null && req.Group.Count != 0)
            {
                var pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, this.ControllerContext
                                                   , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
            else
            {
                var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 9
                                                   , User.Identity.Name, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
            
        }
    }
}

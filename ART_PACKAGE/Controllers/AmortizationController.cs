using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    //[Authorize(Policy = "Licensed", Roles = "Amortization")]
    public class AmortizationController : Controller
    {
        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;

        public AmortizationController(IPdfService pdfSrv, FTIContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiAmortizationReport> data = fti.ArtTiAmortizationReports.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(AmortizationController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {

                { "MasterRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "AcctNo".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.AcctNo).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "AccountType".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.AccountType).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "Shortname".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.Shortname).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "CusMnm".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.CusMnm).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "Ccy".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "DrCrFlg".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.DrCrFlg).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "Mainbanking".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Mainbanking).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "BranchName".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.BranchName).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "EventRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.EventRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "Spsk".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Spsk).Distinct().Where(x=> x != null ).ToDynamicList() },

            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(AmortizationController).ToLower()].SkipList;
            }
            var Data = data.CallData<ArtTiAmortizationReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {

                },
                reportname = "Amortization"

            };
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            var data = fti.ArtTiAmortizationReports;
            var bytes = await data.ExportToCSV<ArtTiAmortizationReport, GenericCsvClassMapper<ArtTiAmortizationReport, AmortizationController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var data = fti.ArtTiAmortizationReports.CallData<ArtTiAmortizationReport>(req).Data.ToList();
            ViewData["title"] = "Amortization Report";
            ViewData["desc"] = "This report produces all postings posted to an account by value date";
            var DisplayNames = ReportsConfig.CONFIG[nameof(AmortizationController).ToLower()].DisplayNames;
            var columnsToPrint = new List<string>()
            {
                // nameof(ArtTiAmortizationReport.EventRef)
                //,nameof(ArtTiAmortizationReport.MasterRef)
                //,nameof(ArtTiAmortizationReport.AccountType)
                //,nameof(ArtTiAmortizationReport.Valuedate)
                //,nameof(ArtTiAmortizationReport.AcctNo)
                //,nameof(ArtTiAmortizationReport.DrCrFlg)
                //,nameof(ArtTiAmortizationReport.Ccy)
                //,nameof(ArtTiAmortizationReport.PostAmount)
            };
            var ColumnsToSkip = typeof(ArtTiAcpostingsAccReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

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


        public IActionResult Index()
        {
            return View();
        }
    }
}

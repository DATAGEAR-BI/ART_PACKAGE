using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Services.Pdf;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers {
    //[Authorize(Policy = "Licensed" , Roles = "PeriodicCHRGs")]

    
    public class PeriodicCHRGsController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;

        public PeriodicCHRGsController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiPeriodicChrgsReport> data = fti.ArtTiPeriodicChrgsReports.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(PeriodicCHRGsController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"Fullname".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Fullname).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Sovalue".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Descr".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Descr).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Descri56".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Descri56).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Address1".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Address1).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"MasterRef".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Payrec".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Payrec).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"AdvArr".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.AdvArr).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Outstccy".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"AccrueCcy".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.AccrueCcy).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(PeriodicCHRGsController).ToLower()].SkipList;
            }
            var Data = data.CallData<ArtTiPeriodicChrgsReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {


                },
                reportname = "PeriodicCHRGs"
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
            var data = fti.ArtTiPeriodicChrgsReports;
            var bytes = await data.ExportToCSV<ArtTiPeriodicChrgsReport, GenericCsvClassMapper<ArtTiPeriodicChrgsReport, PeriodicCHRGsController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(PeriodicCHRGsController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(PeriodicCHRGsController).ToLower()].SkipList;
            var data = fti.ArtTiPeriodicChrgsReports.CallData<ArtTiPeriodicChrgsReport>(req).Data.ToList();
            ViewData["title"] = "Amortization Report";
            ViewData["desc"] = "This report produces all transactions which have not yet expired and which have periodic charges either accruing or amortising within a period that you can specify";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }

    }
}

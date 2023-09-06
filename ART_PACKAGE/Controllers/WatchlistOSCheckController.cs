using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Services.Pdf;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    public class WatchlistOSCheckController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;

        public WatchlistOSCheckController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiWatchlistOsCheckReport> data = fti.ArtTiWatchlistOsCheckReports.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(WatchlistOSCheckController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
               {"Fullname".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Fullname).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"Descri56".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Descri56).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"MasterRef".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"Pcpaddress1".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Pcpaddress1).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"Npcpaddress1".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Npcpaddress1).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"Longna85".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Longna85).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"Shortname".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Shortname).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"Descr".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Descr).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"Status".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Status).Distinct().Where(x=> x != null ).ToDynamicList() },

            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(WatchlistOSCheckController).ToLower()].SkipList;

            }

            var Data = data.CallData<ArtTiWatchlistOsCheckReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {


                },
                reportname = "WatchlistOSCheck"
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
            var data = fti.ArtTiWatchlistOsCheckReports;
            var bytes = await data.ExportToCSV<ArtTiWatchlistOsCheckReport, GenericCsvClassMapper<ArtTiWatchlistOsCheckReport, WatchlistOSCheckController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(WatchlistOSCheckController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(WatchlistOSCheckController).ToLower()].SkipList;
            var data = fti.ArtTiWatchlistOsCheckReports.CallData<ArtTiWatchlistOsCheckReport>(req).Data.ToList();
            ViewData["title"] = "Watchlist - OS Check Report";
            ViewData["desc"] = "This report produces lists of transactions that have been pended and are awaiting list checking";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
    }
}

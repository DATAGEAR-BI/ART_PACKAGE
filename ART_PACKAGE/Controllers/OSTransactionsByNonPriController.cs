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
    //[Authorize(Policy = "Licensed" , Roles = "OSTransactionsByNonPri")]

    
    public class OSTransactionsByNonPriController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;

        public OSTransactionsByNonPriController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiOsTransByNonpriReport> data = fti.ArtTiOsTransByNonpriReports.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {

                DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsByNonPriController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"BhalfBrn".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.BhalfBrn).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Address1".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Address1).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Sovalue".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Descrip".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Descrip).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"MasterRef".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Partptd".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Partptd).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Revolving".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Revolving).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Outstccy".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Ccy".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSTransactionsByNonPriController).ToLower()].SkipList;

            }
            var Data = data.CallData<ArtTiOsTransByNonpriReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {


                },
                reportname = "OSTransactionsByNonPri"
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
            var data = fti.ArtTiOsTransByNonpriReports;
            var bytes = await data.ExportToCSV<ArtTiOsTransByNonpriReport, GenericCsvClassMapper<ArtTiOsTransByNonpriReport, OSTransactionsByNonPriController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsByNonPriController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSTransactionsByNonPriController).ToLower()].SkipList;
            var data = fti.ArtTiOsTransByNonpriReports.CallData<ArtTiOsTransByNonpriReport>(req).Data.ToList();
            ViewData["title"] = "OS Transactions By Non-Pri Report";
            ViewData["desc"] = "This report produces information for non-principal parties instead of principal parties. All totals are in the reporting currency if one is specified, otherwise in base currency";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
    }
}

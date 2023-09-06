using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;

namespace ART_PACKAGE.Controllers { 
    //[Authorize(Policy = "Licensed" , Roles = "OSTransactionsByPrincipal")]

    
    public class OSTransactionsByPrincipalController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;

        public OSTransactionsByPrincipalController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiOsTransByPrincipalReport> data = fti.ArtTiOsTransByPrincipalReports.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {

                DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsByPrincipalController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
              {"BhalfBrn".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.BhalfBrn).Distinct().Where(x=> x != null ).ToDynamicList() },
              {"Address1".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Address1).Distinct().Where(x=> x != null ).ToDynamicList() },
              {"Sovalue".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null ).ToDynamicList() },
              {"Descrip".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Descrip).Distinct().Where(x=> x != null ).ToDynamicList() },
              {"MasterRef".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
              {"Partptd".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Partptd).Distinct().Where(x=> x != null ).ToDynamicList() },
              {"Revolving".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Revolving).Distinct().Where(x=> x != null ).ToDynamicList() },
              {"Outstccy".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null ).ToDynamicList() },
              {"Ccy".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSTransactionsByPrincipalController).ToLower()].SkipList;

            }
            var Data = data.CallData<ArtTiOsTransByPrincipalReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {

                },
                reportname = "OSTransactionsByPrincipal"
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
            var data = fti.ArtTiOsTransByPrincipalReports;
            var bytes = await data.ExportToCSV<ArtTiOsTransByPrincipalReport, GenericCsvClassMapper<ArtTiOsTransByPrincipalReport, OSTransactionsByPrincipalController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsByPrincipalController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSTransactionsByPrincipalController).ToLower()].SkipList;
            var data = fti.ArtTiOsTransByPrincipalReports.CallData<ArtTiOsTransByPrincipalReport>(req).Data.ToList();
            ViewData["title"] = "OS Transactions By Principal Report";
            ViewData["desc"] = "This report produces list information for master records that are not yet booked off or cancelled";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
    }
}

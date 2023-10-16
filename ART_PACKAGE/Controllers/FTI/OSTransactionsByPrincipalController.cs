using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "OSTransactionsByPrincipal")]


    public class OSTransactionsByPrincipalController : Controller
    {
        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;

        public OSTransactionsByPrincipalController(IPdfService pdfSrv, FTIContext fti)
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
            KendoDataDesc<ArtTiOsTransByPrincipalReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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



        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsByPrincipalController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSTransactionsByPrincipalController).ToLower()].SkipList;
            List<ArtTiOsTransByPrincipalReport> data = fti.ArtTiOsTransByPrincipalReports.CallData(req).Data.ToList();
            ViewData["title"] = "OS Transactions By Principal Report";
            ViewData["desc"] = "This report produces list information for master records that are not yet booked off or cancelled";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
    }
}

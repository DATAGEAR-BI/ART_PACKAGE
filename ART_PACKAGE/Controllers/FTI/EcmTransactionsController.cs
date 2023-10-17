using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "EcmTransactions")]


    public class EcmTransactionsController : Controller
    {

        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;

        public EcmTransactionsController(IPdfService pdfSrv, FTIContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiEcmTransactionsReport> data = fti.ArtTiEcmTransactionsReports.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(EcmTransactionsController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"CaseId".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.CaseId).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Product".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Product).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Producttype".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Producttype).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Behalfofbranch".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Behalfofbranch).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Eventname".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Eventname).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"TransactionCurrency".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.TransactionCurrency).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"PrimaryOwner".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.PrimaryOwner).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"CaseStatCd".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.CaseStatCd).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"UpdateUserId".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.UpdateUserId).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
            }

            KendoDataDesc<ArtTiEcmTransactionsReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {


                },
                reportname = "EcmTransactions"
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
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(EcmTransactionsController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = new() { };
            List<ArtTiEcmTransactionsReport> data = fti.ArtTiEcmTransactionsReports.CallData(req).Data.ToList();
            ViewData["title"] = "ECM Transactions Report";
            ViewData["desc"] = "";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
    }
}

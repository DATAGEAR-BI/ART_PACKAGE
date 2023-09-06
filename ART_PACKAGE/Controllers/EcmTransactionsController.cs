using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;

namespace ART_PACKAGE.Controllers { 
    //[Authorize(Policy = "Licensed" , Roles = "EcmTransactions")]

    
    public class EcmTransactionsController : Controller
    {

        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;

        public EcmTransactionsController(IPdfService pdfSrv, AuthContext fti)
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

            var Data = data.CallData<ArtTiEcmTransactionsReport>(request, DropDownColumn, DisplayNames: DisplayNames);
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



        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            IQueryable<ArtTiEcmTransactionsReport> data = fti.ArtTiEcmTransactionsReports;
            var bytes = await data.ExportToCSV<ArtTiEcmTransactionsReport>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(EcmTransactionsController).ToLower()].DisplayNames;
            var ColumnsToSkip = new List<string>() { };
            var data = fti.ArtTiEcmTransactionsReports.CallData<ArtTiEcmTransactionsReport>(req).Data.ToList();
            ViewData["title"] = "ECM Transactions Report";
            ViewData["desc"] = "";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
    }
}

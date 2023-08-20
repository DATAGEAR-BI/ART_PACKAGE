using Microsoft.AspNetCore.Mvc;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Newtonsoft.Json;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Services.Pdf;
using Microsoft.AspNetCore.Authorization;
using ART_PACKAGE.Helpers.DropDown;

namespace ART_PACKAGE.Controllers
{
    [Authorize(Roles = "ArtFtiEcmTransaction", Policy = "License")]
    public class ArtFtiEcmTransactionController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _drpSrv;
        public ArtFtiEcmTransactionController(AuthContext dbfcfkc, IPdfService pdfSrv, DropDownService drpSrv)
        {
            this.dbfcfkc = dbfcfkc;
            _pdfSrv = pdfSrv;
            _drpSrv = drpSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtFtiEcmTransaction> data = dbfcfkc.ArtFtiEcmTransactions.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtFtiEcmTransactionController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    {"Product".ToLower(),_drpSrv.GetProductDropDown().ToDynamicList() },
                    {"FtiReference".ToLower(),dbfcfkc.ArtFtiEcmTransactions.Where(x=>x.FtiReference!=null).Select(x => x.FtiReference).Distinct().ToDynamicList() },
                    {"FirstLineParty".ToLower(),dbfcfkc.ArtFtiEcmTransactions.Where(x=>x.FirstLineParty!=null).Select(x => x.FirstLineParty).Distinct().ToDynamicList() },
                    {"EcmReference".ToLower(),_drpSrv.GetECMREFERNCEDropDown().ToDynamicList() },

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtFtiEcmTransactionController).ToLower()].SkipList;
            }

            KendoDataDesc<ArtFtiEcmTransaction> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {
                    /*new
                    {
                        text = "Delete Cases",
                        id="dltCases",
                        show = User.IsInRole("Delete_Cases")
                    }*/
                },

            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        /*public IActionResult Export([FromBody] ExportDto<decimal> req)
        {
            var data = dbfcfkc.AmlCaseDetailViews.AsQueryable();
            var bytes = data.ExportToCSV<AmlCaseDetailView>(req.Req);
            return File(bytes, "test/csv");
        }*/
        public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        {
            IQueryable<ArtFtiEcmTransaction> data = dbfcfkc.ArtFtiEcmTransactions.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtFtiEcmTransaction, GenericCsvClassMapper<ArtFtiEcmTransaction, ArtFtiEcmTransactionController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtFtiEcmTransactionController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtFtiEcmTransactionController).ToLower()].SkipList;
            List<ArtFtiEcmTransaction> data = dbfcfkc.ArtFtiEcmTransactions.CallData(req).Data.ToList();
            ViewData["title"] = "FTI-ECM Transaction";
            ViewData["desc"] = "FTI Activity report showing what transaction have been created from DGECM or from FTI and their status";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

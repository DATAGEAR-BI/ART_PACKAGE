using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.TRADE_BASE;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.TRADE_BASE
{
    public class TradeBaseAMLSummaryController : Controller
    {
        private readonly TRADE_BASEContext context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;
        private readonly ICsvExport _csvSrv;
        public TradeBaseAMLSummaryController(TRADE_BASEContext context, IPdfService pdfSrv, IDropDownService dropSrv, ICsvExport csvSrv)
        {
            this.context = context;
            _pdfSrv = pdfSrv;
            _dropSrv = dropSrv;
            _csvSrv = csvSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTradeBaseSummary> data = context.ArtTradeBaseSummaries.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(TradeBaseAMLSummaryController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
                {

                };
            }
            ColumnsToSkip = ReportsConfig.CONFIG[nameof(TradeBaseAMLSummaryController).ToLower()].SkipList;

            KendoDataDesc<ArtTradeBaseSummary> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);

            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            Microsoft.EntityFrameworkCore.DbSet<ArtTradeBaseSummary> data = context.ArtTradeBaseSummaries;
            await _csvSrv.ExportAllCsv<ArtTradeBaseSummary, TradeBaseAMLSummaryController, decimal>(data, User.Identity.Name, para);
            return new EmptyResult();
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(TradeBaseAMLSummaryController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(TradeBaseAMLSummaryController).ToLower()].SkipList;
            List<ArtTradeBaseSummary> data = context.ArtTradeBaseSummaries.CallData(req).Data.ToList();
            ViewData["title"] = "Trade Base AML Summary Report";
            ViewData["desc"] = "This report presents all Trade Base AML Summary ";
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

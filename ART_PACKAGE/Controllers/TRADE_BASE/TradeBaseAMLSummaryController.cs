using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.TRADE_BASE;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.TRADE_BASE
{
    public class TradeBaseAMLSummaryController : BaseReportController<IGridConstructor<IBaseRepo<TRADE_BASEContext, ArtTradeBaseSummary>, TRADE_BASEContext, ArtTradeBaseSummary>, IBaseRepo<TRADE_BASEContext, ArtTradeBaseSummary>, TRADE_BASEContext, ArtTradeBaseSummary>
    {
        public TradeBaseAMLSummaryController(IGridConstructor<IBaseRepo<TRADE_BASEContext, ArtTradeBaseSummary>, TRADE_BASEContext, ArtTradeBaseSummary> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }


        /* private readonly TRADE_BASEContext context;
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

             Dictionary<string, GridColumnConfiguration> DisplayNames = null;
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
             Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(TradeBaseAMLSummaryController).ToLower()].DisplayNames;
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
         }*/

        public override IActionResult Index()
        {
            return View();
        }
    }
}

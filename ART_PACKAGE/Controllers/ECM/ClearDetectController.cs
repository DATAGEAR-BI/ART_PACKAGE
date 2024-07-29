using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    public class ClearDetectController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtClearDetect>, EcmContext, ArtClearDetect>, IBaseRepo<EcmContext, ArtClearDetect>, EcmContext, ArtClearDetect>
    {
        public ClearDetectController(IGridConstructor<IBaseRepo<EcmContext, ArtClearDetect>, EcmContext, ArtClearDetect> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
        /* private readonly EcmContext context;
         private readonly IPdfService _pdfSrv;
         private readonly IDropDownService _dropSrv;
         private readonly ICsvExport _csvSrv;
         public ClearDetectController(EcmContext context, IPdfService pdfSrv, IDropDownService dropSrv, ICsvExport csvSrv)
         {
             this.context = context;
             _pdfSrv = pdfSrv;
             _dropSrv = dropSrv;
             _csvSrv = csvSrv;
         }

         public IActionResult GetData([FromBody] KendoRequest request)
         {
             IQueryable<ArtClearDetect> data = context.ArtClearDetects.AsQueryable();

             Dictionary<string, GridColumnConfiguration> DisplayNames = null;
             Dictionary<string, List<dynamic>> DropDownColumn = null;
             List<string> ColumnsToSkip = null;

             if (request.IsIntialize)
             {
                 DisplayNames = ReportsConfig.CONFIG[nameof(ClearDetectController).ToLower()].DisplayNames;

                 DropDownColumn = new Dictionary<string, List<dynamic>>
                 {

                 };
             }
             ColumnsToSkip = ReportsConfig.CONFIG[nameof(ClearDetectController).ToLower()].SkipList;

             KendoDataDesc<ArtClearDetect> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);

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
             Microsoft.EntityFrameworkCore.DbSet<ArtClearDetect> data = context.ArtClearDetects;
             await _csvSrv.ExportAllCsv<ArtClearDetect, ClearDetectController, decimal>(data, User.Identity.Name, para);
             return new EmptyResult();
         }


         public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
         {
             Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ClearDetectController).ToLower()].DisplayNames;
             List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ClearDetectController).ToLower()].SkipList;
             List<ArtClearDetect> data = context.ArtClearDetects.CallData(req).Data.ToList();
             ViewData["title"] = "Clear Detect Report";
             ViewData["desc"] = "This report presents all Clear Detects";
             byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
                                                     , User.Identity.Name, ColumnsToSkip, DisplayNames);
             return File(pdfBytes, "application/pdf");
         }

         public IActionResult Index()
         {
             return View();
         }*/
    }
}

//using ART_PACKAGE.Areas.Identity.Data;
//using ART_PACKAGE.Helpers.Grid;
//using Data.Data.ECM;
//using Data.Services;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace ART_PACKAGE.Controllers.ECM
//{
//    public class CFTConfigController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtCFTConfig>, EcmContext, ArtCFTConfig>, IBaseRepo<EcmContext, ArtCFTConfig>, EcmContext, ArtCFTConfig>
//    {
//        public CFTConfigController(IGridConstructor<IBaseRepo<EcmContext, ArtCFTConfig>, EcmContext, ArtCFTConfig> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
//        {
//        }

//        public override IActionResult Index()
//        {
//            return View();
//        }
//        /*private readonly EcmContext context;
//private readonly IPdfService _pdfSrv;
//private readonly IDropDownService _dropSrv;
//private readonly ICsvExport _csvSrv;
//public CFTConfigController(EcmContext context, IPdfService pdfSrv, IDropDownService dropSrv, ICsvExport csvSrv)
//{
//   this.context = context;
//   _pdfSrv = pdfSrv;
//   _dropSrv = dropSrv;
//   _csvSrv = csvSrv;
//}

//public IActionResult GetData([FromBody] KendoRequest request)
//{
//   IQueryable<ArtCFTConfig> data = context.ArtCFTConfigs.AsQueryable();

//   Dictionary<string, GridColumnConfiguration> DisplayNames = null;
//   Dictionary<string, List<dynamic>> DropDownColumn = null;
//   List<string> ColumnsToSkip = null;

//   if (request.IsIntialize)
//   {
//       DisplayNames = ReportsConfig.CONFIG[nameof(CFTConfigController).ToLower()].DisplayNames;

//       DropDownColumn = new Dictionary<string, List<dynamic>>
//       {

//       };
//   }
//   ColumnsToSkip = ReportsConfig.CONFIG[nameof(CFTConfigController).ToLower()].SkipList;

//   KendoDataDesc<ArtCFTConfig> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);

//   var result = new
//   {
//       data = Data.Data,
//       columns = Data.Columns,
//       total = Data.Total,
//       containsActions = false,
//   };

//   return new ContentResult
//   {
//       ContentType = "application/json",
//       Content = JsonConvert.SerializeObject(result)
//   };
//}

//public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
//{
//   Microsoft.EntityFrameworkCore.DbSet<ArtCFTConfig> data = context.ArtCFTConfigs;
//   await _csvSrv.ExportAllCsv<ArtCFTConfig, CFTConfigController, decimal>(data, User.Identity.Name, para);
//   return new EmptyResult();
//}


//public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
//{
//   Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(CFTConfigController).ToLower()].DisplayNames;
//   List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(CFTConfigController).ToLower()].SkipList;
//   List<ArtCFTConfig> data = context.ArtCFTConfigs.CallData(req).Data.ToList();
//   ViewData["title"] = "CFT Configs Report";
//   ViewData["desc"] = "This report presents all sanction CFT Configs";
//   byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
//                                           , User.Identity.Name, ColumnsToSkip, DisplayNames);
//   return File(pdfBytes, "application/pdf");
//}

//public IActionResult Index()
//{
//   return View();
//}*/
//    }
//}

using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTDGAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLArtScenarioHistoryController : BaseReportController<IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtScenarioHistoryView>, ArtDgAmlContext, ArtScenarioHistoryView>, IBaseRepo<ArtDgAmlContext, ArtScenarioHistoryView>, ArtDgAmlContext, ArtScenarioHistoryView>
    {
        public DGAMLArtScenarioHistoryController(IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtScenarioHistoryView>, ArtDgAmlContext, ArtScenarioHistoryView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        /*
private readonly ArtDgAmlContext _context;
private readonly IDropDownService _dropDown;
private readonly IPdfService _pdfSrv;
public DGAMLArtScenarioHistoryController(ArtDgAmlContext _context, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
{
   this._context = _context;

   _dropDown = dropDown;
   _pdfSrv = pdfSrv;
}

public IActionResult GetData([FromBody] KendoRequest request)
{
   IQueryable<ArtScenarioHistoryView> data = _context.ArtScenarioHistoryViews.AsQueryable();

   Dictionary<string, GridColumnConfiguration> DisplayNames = null;
   Dictionary<string, List<dynamic>> DropDownColumn = null;
   List<string> ColumnsToSkip = null;
   if (request.IsIntialize)
   {
       DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtScenarioHistoryController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtScenarioHistoryController).ToLower()].DisplayNames : new();
       DropDownColumn = new Dictionary<string, List<dynamic>>
       {
           {"CreateUserId".ToLower(),_dropDown.GetDGCreateUserIdDropDown().ToDynamicList() },
           {"RoutineName".ToLower(),_dropDown.GetDGScenarioNameDropDown().ToDynamicList() },
       };

       ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtScenarioHistoryController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtScenarioHistoryController).ToLower()].SkipList : new();
   }



   KendoDataDesc<ArtScenarioHistoryView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

public async Task<IActionResult> Export([FromBody] ExportDto<decimal> req)
{
   IQueryable<ArtScenarioHistoryView> data = _context.ArtScenarioHistoryViews.AsQueryable();
   byte[] bytes = await data.ExportToCSV<ArtScenarioHistoryView, GenericCsvClassMapper<ArtScenarioHistoryView, DGAMLArtScenarioHistoryController>>(req.Req);
   return File(bytes, "test/csv");
}
public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
{
   Dictionary<string, GridColumnConfiguration>? DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtScenarioHistoryController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtScenarioHistoryController).ToLower()].DisplayNames : null;
   List<string>? ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtScenarioHistoryController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtScenarioHistoryController).ToLower()].SkipList : null;
   List<ArtScenarioHistoryView> data = _context.ArtScenarioHistoryViews.CallData(req).Data.ToList();
   ViewData["title"] = "Data Gear Aml Art Scenario History";
   ViewData["desc"] = "Presents the art scenario history details";
   byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
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

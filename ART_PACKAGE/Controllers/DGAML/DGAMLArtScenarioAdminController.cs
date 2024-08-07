﻿using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTDGAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLArtScenarioAdminController : BaseReportController<IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtScenarioAdminView>, ArtDgAmlContext, ArtScenarioAdminView>, IBaseRepo<ArtDgAmlContext, ArtScenarioAdminView>, ArtDgAmlContext, ArtScenarioAdminView>
    {
        public DGAMLArtScenarioAdminController(IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtScenarioAdminView>, ArtDgAmlContext, ArtScenarioAdminView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        /*private readonly ArtDgAmlContext _context;
private readonly IDropDownService _dropDown;
private readonly IPdfService _pdfSrv;
public DGAMLArtScenarioAdminController(ArtDgAmlContext _context, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
{
   this._context = _context;

   _dropDown = dropDown;
   _pdfSrv = pdfSrv;
}

public IActionResult GetData([FromBody] KendoRequest request)
{
   IQueryable<ArtScenarioAdminView> data = _context.ArtScenarioAdminViews.AsQueryable();

   Dictionary<string, GridColumnConfiguration> DisplayNames = null;
   Dictionary<string, List<dynamic>> DropDownColumn = null;
   List<string> ColumnsToSkip = null;
   if (request.IsIntialize)
   {
       DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtScenarioAdminController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtScenarioAdminController).ToLower()].DisplayNames : new();
       DropDownColumn = new Dictionary<string, List<dynamic>>
       {
           {"ScenarioName".ToLower(),_dropDown         .GetDGScenarioNameDropDown()        .ToDynamicList() },
           {"ScenarioCategory".ToLower(),_dropDown     .GetDGScenarioCategoryDropDown()    .ToDynamicList() },
           {"ScenarioStatus".ToLower(),_dropDown       .GetDGScenarioStatusDropDown()      .ToDynamicList() },
           {"ProductType".ToLower(),_dropDown          .GetDGProductTypeDropDown()         .ToDynamicList() },
           {"ScenarioType".ToLower(),_dropDown         .GetDGScenarioTypeDropDown()        .ToDynamicList() },
           {"ScenarioFrequency".ToLower(),_dropDown    .GetDGScenarioFrequencyDropDown()   .ToDynamicList() },
           {"ObjectLevel".ToLower(),_dropDown          .GetDGObjectLevelDropDown()         .ToDynamicList() },
           {"AlarmType".ToLower(),_dropDown            .GetDGAlarmTypeDropDown()           .ToDynamicList() },
           {"AlarmCategory".ToLower(),_dropDown        .GetDGAlarmCategoryDropDown()       .ToDynamicList() },
           {"AlarmSubcategory".ToLower(),_dropDown     .GetDGAlarmSubcategoryDropDown()    .ToDynamicList() },
           {"RiskFact".ToLower(),_dropDown             .GetDGRiskFactDropDown()            .ToDynamicList() },
           {"CreateUserId".ToLower(),_dropDown         .GetDGRoutineCreateUserIdDropDown() .ToDynamicList() },
           {"ParmValue".ToLower(),_dropDown            .GetDGParmValueDropDown()           .ToDynamicList() },
           {"ParmTypeDesc".ToLower(),_dropDown         .GetDGParmTypeDescDropDown()        .ToDynamicList() },
       };

       ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtScenarioAdminController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtScenarioAdminController).ToLower()].SkipList : new();
   }



   KendoDataDesc<ArtScenarioAdminView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
   IQueryable<ArtScenarioAdminView> data = _context.ArtScenarioAdminViews.AsQueryable();
   byte[] bytes = await data.ExportToCSV<ArtScenarioAdminView, GenericCsvClassMapper<ArtScenarioAdminView, DGAMLArtScenarioAdminController>>(req.Req);
   return File(bytes, "test/csv");
}
public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
{
   Dictionary<string, GridColumnConfiguration>? DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtScenarioAdminController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtScenarioAdminController).ToLower()].DisplayNames : null;
   List<string>? ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtScenarioAdminController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtScenarioAdminController).ToLower()].SkipList : null;
   List<ArtScenarioAdminView> data = _context.ArtScenarioAdminViews.CallData(req).Data.ToList();
   ViewData["title"] = "Data Gear Aml Art Scenario Admin";
   ViewData["desc"] = "Presents the art scenario admin details";
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

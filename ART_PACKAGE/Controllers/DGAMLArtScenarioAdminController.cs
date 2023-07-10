using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Services.Pdf;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    public class DGAMLArtScenarioAdminController : Controller
    {
        private readonly AuthContext _context;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public DGAMLArtScenarioAdminController(AuthContext _context, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this._context = _context;

            this._dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtScenarioAdminView> data = _context.ArtScenarioAdminViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtScenarioAdminController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtScenarioAdminController).ToLower()].DisplayNames : new();
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"ScenarioName".ToLower(),_dropDown.GetDGScenarioNameDropDown().ToDynamicList() },
                    {"ScenarioCategory".ToLower(),_dropDown.GetDGScenarioCategoryDropDown().ToDynamicList() },
                    {"ScenarioStatus".ToLower(),_dropDown.GetDGScenarioStatusDropDown().ToDynamicList() },
                    {"ProductType".ToLower(),_dropDown.GetDGProductTypeDropDown().ToDynamicList() },
                    {"ScenarioType".ToLower(),_dropDown.GetDGScenarioTypeDropDown().ToDynamicList() },
                    {"ScenarioFrequency".ToLower(),_dropDown.GetDGScenarioFrequencyDropDown().ToDynamicList() },
                    {"ObjectLevel".ToLower(),_dropDown.GetDGObjectLevelDropDown().ToDynamicList() },
                    {"AlarmType".ToLower(),_dropDown.GetDGAlarmTypeDropDown().ToDynamicList() },
                    {"AlarmCategory".ToLower(),_dropDown.GetDGAlarmCategoryDropDown().ToDynamicList() },
                    {"AlarmSubcategory".ToLower(),_dropDown.GetDGAlarmSubcategoryDropDown().ToDynamicList() },
                    {"RiskFact".ToLower(),_dropDown.GetDGRiskFactDropDown().ToDynamicList() },
                    {"CreateUserId".ToLower(),_dropDown.GetDGRoutineCreateUserIdDropDown().ToDynamicList() },
                    {"ParmValue".ToLower(),_dropDown.GetDGParmValueDropDown().ToDynamicList() },
                    {"ParmTypeDesc".ToLower(),_dropDown.GetDGParmTypeDescDropDown().ToDynamicList() },
                };

                ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtScenarioAdminController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtScenarioAdminController).ToLower()].SkipList : new();
            }



            var Data = data.CallData<ArtScenarioAdminView>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = _context.ArtScenarioAdminViews.AsQueryable();
            var bytes = await data.ExportToCSV<ArtScenarioAdminView, GenericCsvClassMapper<ArtScenarioAdminView, DGAMLArtScenarioAdminController>>(req.Req);
            return File(bytes, "test/csv");
        }
        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtScenarioAdminController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtScenarioAdminController).ToLower()].DisplayNames : null;
            var ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtScenarioAdminController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtScenarioAdminController).ToLower()].SkipList : null;
            var data = _context.ArtScenarioAdminViews.CallData<ArtScenarioAdminView>(req).Data.ToList();
            ViewData["title"] = "Data Gear Aml Art Scenario Admin";
            ViewData["desc"] = "Presents the art scenario admin details";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

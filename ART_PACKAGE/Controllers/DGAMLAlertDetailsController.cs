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
    public class DGAMLAlertDetailsController : Controller
    {
        private readonly AuthContext _context;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public DGAMLAlertDetailsController(AuthContext _context, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this._context = _context;

            this._dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtDgAmlAlertDetailView> data = _context.ArtDGAMLAlertDetailViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLAlertDetailsController).ToLower()].DisplayNames : new();
                var PEPlist = new List<dynamic>()
                    {
                        "Y","N"
                    };
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //{"AlertStatus".ToLower(),_dropDown.GetAlertStatusDropDown().ToDynamicList() },
                    //{"AlertSubCat".ToLower(),_dropDown.GetCaseSubCategoryDropDown().ToDynamicList() },
                    ////{"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    //{"PartyTypeDesc".ToLower(),_dropDown.GetPartyTypeDropDown().ToDynamicList() },
                    //{"PoliticallyExposedPersonInd".ToLower(),PEPlist.ToDynamicList() },
                    //{"ScenarioName".ToLower(),_dropDown.GetScenarioNameDropDown().ToDynamicList() }
                };

                ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLAlertDetailsController).ToLower()].SkipList : new();
            }



            var Data = data.CallData<ArtDgAmlAlertDetailView>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = _context.ArtDGAMLAlertDetailViews.AsQueryable();
            var bytes = await data.ExportToCSV<ArtDgAmlAlertDetailView, GenericCsvClassMapper<ArtAmlAlertDetailView, DGAMLAlertDetailsController>>(req.Req);
            return File(bytes, "test/csv");
        }
        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLAlertDetailsController).ToLower()].DisplayNames : null;
            var ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLAlertDetailsController).ToLower()].SkipList : null;
            var data = _context.ArtDGAMLAlertDetailViews.CallData<ArtDgAmlAlertDetailView>(req).Data.ToList();
            ViewData["title"] = "Alert Details";
            ViewData["desc"] = "Presents the alerts details";
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

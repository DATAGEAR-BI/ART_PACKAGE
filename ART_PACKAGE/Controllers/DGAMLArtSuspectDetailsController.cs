using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{

    public class DGAMLArtSuspectDetailsController : Controller
    {
        private readonly ArtDgAmlContext _context;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public DGAMLArtSuspectDetailsController(ArtDgAmlContext _context, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this._context = _context;

            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtSuspectDetailView> data = _context.ArtSuspectDetailViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtSuspectDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtSuspectDetailsController).ToLower()].DisplayNames : new();
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"BranchName".ToLower(),_dropDown           .GetDGBranchNameDropDown()              .ToDynamicList() },
                    {"ProfileRisk".ToLower(),_dropDown          .GetDGProfileRiskDropDown()             .ToDynamicList() },
                    {"OwnerUserid".ToLower(),_dropDown          .GetDGOwnerDropDown()                   .ToDynamicList() },
                    {"PoliticalExpPrsnInd".ToLower(),_dropDown  .GetDGPoliticalExpPrsnIndDropDown()     .ToDynamicList() },
                    {"RiskClassification".ToLower(),_dropDown   .GetDGRiskClassificationDropDown()      .ToDynamicList() },
                    {"CitizenCntryName".ToLower(),_dropDown     .GetDGCitizenCountryNameDropDown()      .ToDynamicList() },
                    {"CustIdentTypeDesc".ToLower(),_dropDown    .GetDGCustIdentTypeDescDropDown()       .ToDynamicList() },
                    {"OccupDesc".ToLower(),_dropDown            .GetDGOccupDescDropDown()               .ToDynamicList() },
                };

                ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtSuspectDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtSuspectDetailsController).ToLower()].SkipList : new();
            }



            KendoDataDesc<ArtSuspectDetailView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat>? DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtSuspectDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtSuspectDetailsController).ToLower()].DisplayNames : null;
            List<string>? ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtSuspectDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtSuspectDetailsController).ToLower()].SkipList : null;
            List<ArtSuspectDetailView> data = _context.ArtSuspectDetailViews.CallData(req).Data.ToList();
            ViewData["title"] = "Data Gear Aml Art Suspect Details";
            ViewData["desc"] = "Presents the art suspect details";
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

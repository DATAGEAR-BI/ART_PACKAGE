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

    public class DGAMLArtExternalCustomerDetailsController : Controller
    {
        private readonly ArtDgAmlContext _context;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public DGAMLArtExternalCustomerDetailsController(ArtDgAmlContext _context, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this._context = _context;

            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtExternalCustomerDetailView> data = _context.ArtExternalCustomerDetailViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtExternalCustomerDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtExternalCustomerDetailsController).ToLower()].DisplayNames : new();
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"BranchName".ToLower(),_dropDown           .GetDGExternalCustomerBranchNameDropDown()      .ToDynamicList() },
                    {"CitizenCntryName".ToLower(),_dropDown     .GetDGExternalCustomerCitizenshipCountryNameDropDown()          .ToDynamicList() },
                    {"CityName".ToLower(),_dropDown             .GetDGExternalCustomerCityNameDropDown()                        .ToDynamicList() },
                    {"CustomerType".ToLower(),_dropDown      .GetDGExternalCustomerTypeDropDown()                    .ToDynamicList() },
                    {"CustomerIdentificationType".ToLower(),_dropDown      .GetDGCustomerIdentificationTypeDropDown()                    .ToDynamicList() },
                };

                ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtExternalCustomerDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtExternalCustomerDetailsController).ToLower()].SkipList : new();
            }



            KendoDataDesc<ArtExternalCustomerDetailView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            Dictionary<string, DisplayNameAndFormat>? DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtExternalCustomerDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtExternalCustomerDetailsController).ToLower()].DisplayNames : null;
            List<string>? ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtExternalCustomerDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtExternalCustomerDetailsController).ToLower()].SkipList : null;
            List<ArtExternalCustomerDetailView> data = _context.ArtExternalCustomerDetailViews.CallData(req).Data.ToList();
            ViewData["title"] = "Data Gear AML External Customer Details";
            ViewData["desc"] = "Presents the external customer details";
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

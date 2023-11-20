using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.DGAML
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

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtExternalCustomerDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtExternalCustomerDetailsController).ToLower()].DisplayNames : new();
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"BranchName".ToLower(),_dropDown           .GetDGExternalCustomerBranchNameDropDown()      .ToDynamicList() },
                    {nameof(ArtExternalCustomerDetailView.CitizenshipCountryName).ToLower(),_dropDown     .GetDGCitizenshipCountryNameDropDown()          .ToDynamicList() },
                    {nameof(ArtExternalCustomerDetailView.ResidenceCountryName).ToLower(),_dropDown       .GetDGresidenceCountryNameDropDown()            .ToDynamicList() },
                   // {"CntryName".ToLower(),_dropDown            .GetDGStreetCountryNameDropDown()               .ToDynamicList() },
                    {"CityName".ToLower(),_dropDown             .GetDGCityNameDropDown()                        .ToDynamicList() },
                    {"IdentTypeDesc".ToLower(),_dropDown        .GetDGCustomerIdentificationTypeDropDown()      .ToDynamicList() },
                    {"ExtCustTypeDesc".ToLower(),_dropDown      .GetDGCustomerTypeDropDown()                    .ToDynamicList() },
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

        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> req)
        {
            IQueryable<ArtExternalCustomerDetailView> data = _context.ArtExternalCustomerDetailViews.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtExternalCustomerDetailView, GenericCsvClassMapper<ArtExternalCustomerDetailView, DGAMLArtExternalCustomerDetailsController>>(req.Req);
            return File(bytes, "test/csv");
        }
        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, GridColumnConfiguration>? DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLArtExternalCustomerDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLArtExternalCustomerDetailsController).ToLower()].DisplayNames : null;
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

using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.ARTDGAML;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLCustomersDetailsController : Controller
    {


        private readonly ArtDgAmlContext _context;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public DGAMLCustomersDetailsController(ArtDgAmlContext _context, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this._context = _context;
            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtDgAmlCustomerDetailView> data = _context.ArtDGAMLCustomerDetailViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCustomersDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCustomersDetailsController).ToLower()].DisplayNames : new();
                List<dynamic> Indlist = new()
                    {
                        "Y","N"
                    };
                //DropDownColumn = new Dictionary<string, List<dynamic>>
                //{
                //    {"CustomerType".ToLower(),_dropDown.GetPartyTypeDropDown().ToDynamicList() },
                //    {"RiskClassification".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
                //    {"NonProfitOrgInd".ToLower(),Indlist.ToDynamicList() },
                //    {"PoliticallyExposedPersonInd".ToLower(),Indlist.ToDynamicList() },
                //    {"CharityDonationsInd".ToLower(),Indlist.ToDynamicList() },
                //    {"ResidenceCountryName".ToLower(),_dropDown.GetResidenceCountryNameDropDown().ToDynamicList() },
                //    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                //    {"IndustryDesc".ToLower(),_dropDown.GetIndustryDescDropDown().ToDynamicList() },
                //    {"CustomerIdentificationType".ToLower(),_dropDown.GetCustomerIdentificationTypeDropDown().ToDynamicList() },
                //    {"OccupationDesc".ToLower(),_dropDown.GetOccupationDescDropDown().ToDynamicList() },
                //    {"CitizenshipCountryName".ToLower(),_dropDown.GetCitizenshipCountryNameDropDown().ToDynamicList() }
                //};
                ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCustomersDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCustomersDetailsController).ToLower()].SkipList : new();
            }


            KendoDataDesc<ArtDgAmlCustomerDetailView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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


        public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        {
            IQueryable<ArtDgAmlCustomerDetailView> data = _context.ArtDGAMLCustomerDetailViews.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtDgAmlCustomerDetailView, GenericCsvClassMapper<ArtAmlCustomersDetailsView, DGAMLCustomersDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat>? DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCustomersDetailsController).ToLower()].DisplayNames : null;
            List<string>? ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCustomersDetailsController).ToLower()].SkipList : null;
            List<ArtDgAmlCustomerDetailView> data = _context.ArtDGAMLCustomerDetailViews.CallData(req).Data.ToList();
            ViewData["title"] = "Customers Details";
            ViewData["desc"] = "Presents all customers details";
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

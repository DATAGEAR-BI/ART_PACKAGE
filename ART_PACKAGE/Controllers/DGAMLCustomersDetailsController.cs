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
    public class DGAMLCustomersDetailsController : Controller
    {


        private readonly AuthContext _context;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public DGAMLCustomersDetailsController(AuthContext _context, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this._context = _context;
            this._dropDown = dropDown;
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
                var Indlist = new List<dynamic>()
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


            var Data = data.CallData<ArtDgAmlCustomerDetailView>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = _context.ArtDGAMLCustomerDetailViews.AsQueryable();
            var bytes = await data.ExportToCSV<ArtDgAmlCustomerDetailView, GenericCsvClassMapper<ArtAmlCustomersDetailsView, DGAMLCustomersDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCustomersDetailsController).ToLower()].DisplayNames : null;
            var ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCustomersDetailsController).ToLower()].SkipList : null;
            var data = _context.ArtDGAMLCustomerDetailViews.CallData<ArtDgAmlCustomerDetailView>(req).Data.ToList();
            ViewData["title"] = "Customers Details";
            ViewData["desc"] = "Presents all customers details";
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

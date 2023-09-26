using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.SASAML
{

    public class CustomersController : Controller
    {
        //dbfcfcore.ModelContext db = new dbfcfcore.ModelContext();
        //dbfcfkc.ModelContext dbfcfkc = new dbfcfkc.ModelContext();

        private readonly SasAmlContext dbfcfcore;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public CustomersController(SasAmlContext dbfcfcore, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this.dbfcfcore = dbfcfcore;
            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtAmlCustomersDetailsView> data = dbfcfcore.ArtAmlCustomersDetailsViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(CustomersController).ToLower()].DisplayNames;
                List<dynamic> Indlist = new()
                    {
                        "Y","N"
                    };
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"CustomerType".ToLower(),_dropDown.GetPartyTypeDropDown().ToDynamicList() },
                    {"RiskClassification".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
                    {"NonProfitOrgInd".ToLower(),Indlist.ToDynamicList() },
                    {"PoliticallyExposedPersonInd".ToLower(),Indlist.ToDynamicList() },
                    {"CharityDonationsInd".ToLower(),Indlist.ToDynamicList() },
                    {"ResidenceCountryName".ToLower(),_dropDown.GetResidenceCountryNameDropDown().ToDynamicList() },
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    {"IndustryDesc".ToLower(),_dropDown.GetIndustryDescDropDown().ToDynamicList() },
                    {"CustomerIdentificationType".ToLower(),_dropDown.GetCustomerIdentificationTypeDropDown().ToDynamicList() },
                    {"OccupationDesc".ToLower(),_dropDown.GetOccupationDescDropDown().ToDynamicList() },
                    {"CitizenshipCountryName".ToLower(),_dropDown.GetCitizenshipCountryNameDropDown().ToDynamicList() }
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(CustomersController).ToLower()].SkipList;
            }


            KendoDataDesc<ArtAmlCustomersDetailsView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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


        //public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        //{
        //    IQueryable<ArtAmlCustomersDetailsView> data = dbfcfcore.ArtAmlCustomersDetailsViews.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtAmlCustomersDetailsView, GenericCsvClassMapper<ArtAmlCustomersDetailsView, CustomersController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(CustomersController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(CustomersController).ToLower()].SkipList;
            List<ArtAmlCustomersDetailsView> data = dbfcfcore.ArtAmlCustomersDetailsViews.CallData(req).Data.ToList();
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

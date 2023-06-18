
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Services.Pdf;

namespace ART_PACKAGE.Controllers
{
    public class HighRiskController : Controller
    {
        private readonly AuthContext dbfcfcore;
        private readonly IMemoryCache _cache;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public HighRiskController(AuthContext dbfcfcore, IMemoryCache cache/*, IDropDownService dropDown*/, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this.dbfcfcore = dbfcfcore;
            _cache = cache;
            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtAmlHighRiskCustView> data = dbfcfcore.ArtAmlHighRiskCustViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(HighRiskController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    {"PartyIdentificationTypeDesc".ToLower(),_dropDown.GetPartyIdentificationTypeDropDown().ToDynamicList() },
                    {"PartyTypeDesc".ToLower(),_dropDown.GetPartyTypeDropDown().ToDynamicList() },
                    {"RiskClassification".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
                    //{"PoliticallyExposedPersonInd".ToLower(),_dropDown.Getpo().ToDynamicList() },
                    {"ResidenceCountryName".ToLower(),_dropDown.GetResidenceCountryNameDropDown().ToDynamicList() },
                    {"CitizenshipCountryName".ToLower(),_dropDown.GetCitizenshipCountryNameDropDown().ToDynamicList() },
                    //{"MailingCityName".ToLower(),_dropDown.().ToDynamicList() },

                };
            }


            var ColumnsToSkip = new List<string>
            {

            };
            var Data = data.CallData<ArtAmlHighRiskCustView>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = dbfcfcore.ArtAmlHighRiskCustViews.AsQueryable();
            var bytes = await data.ExportToCSV<ArtAmlHighRiskCustView, GenericCsvClassMapper<ArtAmlHighRiskCustView, HighRiskController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(HighRiskController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(HighRiskController).ToLower()].SkipList;
            var data = dbfcfcore.ArtAmlHighRiskCustViews.CallData<ArtAmlHighRiskCustView>(req).Data.ToList();
            ViewData["title"] = "System Performance Report";
            ViewData["desc"] = "This report presents all sanction cases with the related information on case level as below";
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


using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;

namespace ART_PACKAGE.Controllers
{

    public class CustomersController : Controller
    {
        //dbfcfcore.ModelContext db = new dbfcfcore.ModelContext();
        //dbfcfkc.ModelContext dbfcfkc = new dbfcfkc.ModelContext();

        private readonly AuthContext dbfcfcore;
        private readonly IMemoryCache _cache;
        private readonly IDropDownService _dropDown;
        public CustomersController(AuthContext dbfcfcore, IMemoryCache cache, IDropDownService dropDown)
        {
            this.dbfcfcore = dbfcfcore;
            _cache = cache;
            this._dropDown = dropDown;
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
                var Indlist = new List<dynamic>()
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


            var Data = data.CallData<ArtAmlCustomersDetailsView>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = dbfcfcore.ArtAmlCustomersDetailsViews.AsQueryable();
            var bytes = await data.ExportToCSV<ArtAmlCustomersDetailsView, GenericCsvClassMapper<ArtAmlCustomersDetailsView, CustomersController>>(para.Req);
            return File(bytes, "text/csv");
        }
        

        public IActionResult Index()
        {
            return View();
        }
    }
}

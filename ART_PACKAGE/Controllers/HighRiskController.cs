
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Services;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;

namespace ART_PACKAGE.Controllers
{
    public class HighRiskController : Controller
    {
        private readonly AuthContext dbfcfcore;
        private readonly IMemoryCache _cache; private readonly IDropDownService _dropDown;
        public HighRiskController(AuthContext dbfcfcore, IMemoryCache cache, IDropDownService dropDown)
        {
            this.dbfcfcore = dbfcfcore;
            _cache = cache; this._dropDown = dropDown;
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
                    //{"BranchName".ToLower(),dgcmgmt.ArtCaseTypesViews.Select(x => x.CaseType).ToDynamicList() },
                    //{"PartyIdentificationTypeDesc".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },
                    //{"PartyTypeDesc".ToLower(),dgcmgmt.ArtCreateUserFilters.Select(m => m.CreateUserId).ToDynamicList() },
                    //{"RiskClassification".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },
                    //{"PoliticallyExposedPersonInd".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },
                    //{"ResidenceCountryName".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },
                    //{"CitizenshipCountryName".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },
                    //{"MailingCityName".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },

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

        public IActionResult Index()
        {
            return View();
        }
    }
}

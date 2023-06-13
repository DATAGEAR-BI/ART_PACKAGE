using DataGear_RV_Ver_1._7.dbfcfkc;
using DataGear_RV_Ver_1._7.dbfcfcore;
using DataGear_RV_Ver_1._7.dbcmcaudit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;

using Microsoft.Extensions.Caching.Memory;
using DataGear_RV_Ver_1._7.Helpers;
using DataGear_RV_Ver_1._7.Helpers.CustomReportHelpers;
using DataGear_RV_Ver_1._7.Services;
using System.Linq.Dynamic.Core;
using DataGear_RV_Ver_1._7.Helpers;
using DataGear_RV_Ver_1._7.Helpers.CustomReportHelpers;
using DataGear_RV_Ver_1._7.Helpers.CSVMAppers;

namespace DataGear_RV_Ver_1._7.Controllers
{
    public class AlertDetailsController : Controller
    {
        private readonly dbfcfkc.ModelContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        public AlertDetailsController(dbfcfkc.ModelContext dbfcfkc, IMemoryCache cache, IDropDownService dropDown)
        {
            this.dbfcfkc = dbfcfkc;

            this._dropDown = dropDown;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<AmlAlertDetailView> data = dbfcfkc.AmlAlertDetailViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].DisplayNames;
                var PEPlist = new List<dynamic>()
                    {
                        "Y","N"
                    };
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"AlertStatus".ToLower(),_dropDown.GetAlertStatusDropDown().ToDynamicList() },
                    {"AlertSubCat".ToLower(),_dropDown.GetCaseSubCategoryDropDown().ToDynamicList() },
                    {"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    {"PartyTypeDesc".ToLower(),_dropDown.GetPartyTypeDropDown().ToDynamicList() },
                    {"PoliticallyExposedPersonInd".ToLower(),PEPlist.ToDynamicList() },
                    {"ScenarioName".ToLower(),_dropDown.GetScenarioNameDropDown().ToDynamicList() }
                };

                ColumnsToSkip = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].SkipList;
            }



            var Data = data.CallData<AmlAlertDetailView>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = dbfcfkc.AmlAlertDetailViews.AsQueryable();
            var bytes = await data.ExportToCSV<AmlAlertDetailView, GenericCsvClassMapper<AmlAlertDetailView, AlertDetailsController>>(req.Req);
            return File(bytes, "test/csv");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

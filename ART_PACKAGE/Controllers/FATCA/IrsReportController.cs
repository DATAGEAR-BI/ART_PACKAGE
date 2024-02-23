using DataGear_RV_Ver_1._7.dbfcfkc;
using DataGear_RV_Ver_1._7.Helpers;
using ART_PACKAGE.Helpers.Csv;
using DataGear_RV_Ver_1._7.Helpers.CustomReportHelpers;
using DataGear_RV_Ver_1._7.Hubs;
using DataGear_RV_Ver_1._7.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

using Data.Services.Grid;
using DataGear_RV_Ver_1._7.dbfagp;

namespace ART_PACKAGE.Controllers.FATCA
{
    public class IrsReportController : Controller
    {
        private readonly dbfagp.ModelContext dbfagp;
        private readonly IDropDownService _dropDown;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly ICsvExport _csvSrv;
        public IrsReportController(dbfagp.ModelContext dbfagp, IMemoryCache cache, IDropDownService dropDown, IHubContext<ExportHub> exportHub, ICsvExport csvSrv)
        {
            this.dbfagp = dbfagp;

            this._dropDown = dropDown;
            _exportHub = exportHub;
            _csvSrv = csvSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<IrsReport> data = dbfagp.IrsReports.AsQueryable();

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(IrsReportController).ToLower()].DisplayNames;
                //var PEPlist = new List<dynamic>()
                //    {
                //        "Y","N"
                //    };
                //DropDownColumn = new Dictionary<string, List<dynamic>>
                //{
                //    {"AlertStatus".ToLower(),_dropDown.GetAlertStatusDropDown().ToDynamicList() },
                //    {"AlertSubCat".ToLower(),_dropDown.GetCaseSubCategoryDropDown().ToDynamicList() },
                //    {"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                //    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                //    {"PartyTypeDesc".ToLower(),_dropDown.GetPartyTypeDropDown().ToDynamicList() },
                //    {"PoliticallyExposedPersonInd".ToLower(),PEPlist.ToDynamicList() },
                //    {"ScenarioName".ToLower(),_dropDown.GetScenarioNameDropDown().ToDynamicList() },
                //    {"StaffFlag".ToLower(),PEPlist.ToDynamicList() },
                //    {"HdbLogicRisk".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
                //};

                ColumnsToSkip = ReportsConfig.CONFIG[nameof(IrsReportController).ToLower()].SkipList;
            }



            var Data = data.CallData<IrsReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

        public IActionResult Index()
        {
            return View();
        }
    }
}

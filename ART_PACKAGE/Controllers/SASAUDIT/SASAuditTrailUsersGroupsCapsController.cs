using DataGear_RV_Ver_1._7.dbcmcaudit;
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
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;

using Data.Services.Grid;

namespace DataGear_RV_Ver_1._7.Controllers
{
    public class SASAuditTrailUsersGroupsCapsController : Controller
    {
        private readonly dbcmcaudit.ModelContext dbcmcaudit;
        private readonly IMemoryCache _cache; private readonly IDropDownService _dropDown;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly ICsvExport _csvSrv;
        public SASAuditTrailUsersGroupsCapsController(dbcmcaudit.ModelContext dbcmcaudit, IMemoryCache cache, IDropDownService dropDown, IHubContext<ExportHub> exportHub, ICsvExport csvSrv)
        {
            this.dbcmcaudit = dbcmcaudit;
            _cache = cache;
            this._dropDown = dropDown;
            _exportHub = exportHub;
            _csvSrv = csvSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListAccessUsersGroupsCap> data = dbcmcaudit.ListAccessUsersGroupsCaps.AsQueryable();

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(SASAuditTrailUsersGroupsCapsController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"UserName".ToLower(),dbcmcaudit.VaPersonInfos.GroupBy(s => s.Name.ToLower()).Select(g => g.Key).OrderBy(s => s).ToDynamicList() },
                    {"Ggroup".ToLower(),_dropDown.GetGroupsDropDown().ToDynamicList() },
                    {"Rrole".ToLower(),_dropDown.GetRolesDropDown().ToDynamicList() },
                    {"Capabilities".ToLower(),_dropDown.GetCapabilityNameDropDown().ToDynamicList() },

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(SASAuditTrailUsersGroupsCapsController).ToLower()].SkipList;
            }


            var Data = data.CallData<ListAccessUsersGroupsCap>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

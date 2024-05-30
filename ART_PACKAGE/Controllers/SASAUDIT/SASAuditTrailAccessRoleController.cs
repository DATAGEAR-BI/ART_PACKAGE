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
using System.Linq;
using System.Linq.Dynamic.Core;

using Data.Services.Grid;

namespace DataGear_RV_Ver_1._7.Controllers
{
    public class SASAuditTrailAccessRoleController : Controller
    {
        private readonly dbcmcaudit.ModelContext dbcmcaudit;
        private readonly IMemoryCache _cache; private readonly IDropDownService _dropDown;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly ICsvExport _csvSrv;
        public SASAuditTrailAccessRoleController(dbcmcaudit.ModelContext dbcmcaudit, IMemoryCache cache, IDropDownService dropDown, IHubContext<ExportHub> exportHub, ICsvExport csvSrv)
        {
            this.dbcmcaudit = dbcmcaudit;
            _cache = cache;
            this._dropDown = dropDown;
            _exportHub = exportHub;
            _csvSrv = csvSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListAccessRightPerRole> data = dbcmcaudit.ListAccessRightPerRoles.AsQueryable();

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(SASAuditTrailAccessRoleController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"Role".ToLower(),_dropDown.GetRolesDropDown().ToDynamicList() },
                    {"CapName".ToLower(),_dropDown.GetCapabilityNameDropDown().ToDynamicList() },
                    {"CapabilitiyGroupName".ToLower(),_dropDown.GetCapabilityGroupDropDown().ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(SASAuditTrailAccessRoleController).ToLower()].SkipList;
            }

            var Data = data.CallData<ListAccessRightPerRole>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

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
    public class SASAuditTrailUsersGroupsRoleController : Controller
    {
        private readonly dbcmcaudit.ModelContext dbcmcaudit;
        private readonly IMemoryCache _cache; private readonly IDropDownService _dropDown;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly ICsvExport _csvSrv;
        public SASAuditTrailUsersGroupsRoleController(dbcmcaudit.ModelContext dbcmcaudit, IMemoryCache cache, IDropDownService dropDown, IHubContext<ExportHub> exportHub, ICsvExport csvSrv)
        {
            this.dbcmcaudit = dbcmcaudit;
            _cache = cache;
            this._dropDown = dropDown;
            _exportHub = exportHub;
            _csvSrv = csvSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListOfUsersAndGroupsRole> data = dbcmcaudit.ListOfUsersAndGroupsRoles.AsQueryable();

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(SASAuditTrailUsersGroupsRoleController).ToLower()].DisplayNames;
                var Indlist = new List<dynamic>()
                    {
                        "Active","Inactive"
                    };
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"UserName".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"MemberOfGroup".ToLower(),_dropDown.GetGroupsDropDown().ToDynamicList() },
                    {"UserRole".ToLower(),_dropDown.GetRolesDropDown().ToDynamicList() },
                    {"Status".ToLower(),Indlist.ToDynamicList() }

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(SASAuditTrailUsersGroupsRoleController).ToLower()].SkipList;
            }

            var Data = data.CallData<ListOfUsersAndGroupsRole>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

using DataGear_RV_Ver_1._7.dbcmcaudit;
using DataGear_RV_Ver_1._7.Helpers;
using DataGear_RV_Ver_1._7.Helpers.CSVMAppers;
using DataGear_RV_Ver_1._7.Helpers.CustomReportHelpers;
using DataGear_RV_Ver_1._7.Hubs;
using DataGear_RV_Ver_1._7.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using ART_PACKAGE.Helpers;
using Data.Services.Grid;

namespace DataGear_RV_Ver_1._7.Controllers
{
    public class SASAuditTrailGroupsRolesSummaryController : Controller
    {
        private readonly dbcmcaudit.ModelContext dbcmcaudit;
        private readonly UsersConnectionIds connections;
        private readonly IMemoryCache _cache; private readonly IDropDownService _dropDown;
        private readonly IHubContext<ExportHub> _exportHub;
        public SASAuditTrailGroupsRolesSummaryController(dbcmcaudit.ModelContext dbcmcaudit, IMemoryCache cache, IDropDownService dropDown, IHubContext<ExportHub> exportHub, UsersConnectionIds connections)
        {
            this.dbcmcaudit = dbcmcaudit;
            _cache = cache;
            this._dropDown = dropDown;
            _exportHub = exportHub;
            this.connections = connections;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListGroupsRolesSummary> data = dbcmcaudit.ListGroupsRolesSummaries.AsQueryable();

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(SASAuditTrailGroupsRolesSummaryController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"Groups".ToLower(),_dropDown.GetGroupsDropDown().ToDynamicList() },
                    {"Role".ToLower(),_dropDown.GetRolesDropDown().ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(SASAuditTrailGroupsRolesSummaryController).ToLower()].SkipList;
            }

            var Data = data.CallData<ListGroupsRolesSummary>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = dbcmcaudit.ListGroupsRolesSummaries.AsQueryable();
            int i = 1;
            foreach (Task<byte[]> item in data.ExportToCSVE<ListGroupsRolesSummary, GenericCsvClassMapper<ListGroupsRolesSummary, SASAuditTrailGroupsRolesSummaryController>>(para.Req))
            {
                try
                {
                    byte[] bytes = await item;
                    string FileName = this.GetType().Name.Replace("Controller", "") + "_" + i + "_" + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
                    await _exportHub.Clients.Clients(connections.GetConnections(User.Identity.Name))
                                .SendAsync("csvRecevied", bytes, FileName);
                    i++;
                }
                catch (Exception ex)
                {
                    await _exportHub.Clients.Clients(connections.GetConnections(User.Identity.Name))
                                .SendAsync("csvErrorRecevied", i);

                }

            }
            return new EmptyResult();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

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
    public class SASAuditTrailActionController : Controller
    {
        private readonly dbcmcaudit.ModelContext dbcmcaudit;
        private readonly IMemoryCache _cache;
        readonly IDropDownService _dropDown;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly ICsvExport _csvSrv;
        public SASAuditTrailActionController(dbcmcaudit.ModelContext dbcmcaudit, IMemoryCache cache, IDropDownService dropDown, IHubContext<ExportHub> exportHub, ICsvExport csvSrv)
        {
            this.dbcmcaudit = dbcmcaudit;
            _cache = cache;
            this._dropDown = dropDown;
            _exportHub = exportHub;
            _csvSrv = csvSrv;
        }
        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<AuditTrailReport> data = dbcmcaudit.AuditTrailReports.AsQueryable();

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(SASAuditTrailActionController).ToLower()].DisplayNames;

                var Actionlist = new List<dynamic>()
                    {
                        "added","Added Member", "deleted", "updated", "Remove Member"
                    };
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"UserId".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"ActionType".ToLower(),Actionlist.ToDynamicList() },
                };
            }


            ColumnsToSkip = ReportsConfig.CONFIG[nameof(SASAuditTrailActionController).ToLower()].SkipList;

            var Data = data.CallData<AuditTrailReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

        //public IActionResult Export(string? actionstartdate, string? actionenddate, string?[] UserId, string?[] actiontype, string[] ColumnsNames, string? ExportedColumns)
        //{
        //    var cr = GetData(actionstartdate, actionenddate, UserId, actiontype, ExportedColumns, 0).Content;
        //    DataTable dt = JsonConvert.DeserializeObject<DataTable>(cr);

        //    //return Json(new { fileName = FileUtils.ExportFile(_env.WebRootPath, dt, "SASAuditTrailAction",Request,ColumnsNames) });
        //    var csvString = FileUtils.ExportFileClientSide(_env.WebRootPath, dt, "SASAuditTrailAction", Request, ColumnsNames);
        //    var data = Encoding.UTF8.GetBytes(csvString); var result = Encoding.UTF8.GetPreamble().Concat(data).ToArray();
        //    return File(result, "text/csv");
        //}
        //public ContentResult GetData(string? actionstartdate, string? actionenddate, string?[] UserId, string?[] actiontype, string? ExportedColumns, int page = 1)
        //{
        //    if (string.IsNullOrEmpty(actionstartdate))
        //    {
        //        actionstartdate = DateTime.Now.AddMonths(-1).ToShortDateString();
        //    }
        //    if (string.IsNullOrEmpty(actionenddate))
        //    {
        //        actionenddate = DateTime.Now.ToShortDateString();
        //    }

        //    //if (string.IsNullOrEmpty(UserId))
        //    //{
        //    //    UserId = "";
        //    //}

        //    //if (string.IsNullOrEmpty(actiontype))
        //    //{
        //    //    actiontype = "";
        //    //}
        //    if (page == 0)
        //    {
        //        var data = db.AuditTrailReports
        //        .Where(a => a.ActionDate.Value.Date.Date >= Convert.ToDateTime(actionstartdate) && a.ActionDate.Value.Date.Date <= Convert.ToDateTime(actionenddate))
        //        .Where(b => UserId.Length == 0 || UserId[0] == null ? true : UserId.Contains(b.UserId))
        //        .Where(c => actiontype.Length == 0 || actiontype[0] == null ? true : actiontype.Contains(c.ActionType))
        //        ;
        //        if (!string.IsNullOrEmpty(ExportedColumns))
        //        {

        //            var expression = FileUtils.DynamicFields<AuditTrailReport>(ExportedColumns.Split(","));
        //            var result = data.Select(expression);
        //            return Content(JsonConvert.SerializeObject(result), "application/json");

        //        }
        //        else
        //        {
        //            var result = data.Select(tags => new
        //            {
        //                tags.UserId,
        //                tags.UserName,
        //                tags.Title,
        //                tags.DateTime,
        //                tags.ActionType,
        //                tags.ActionOn,
        //                tags.ObjectType,
        //                tags.ObjectName,
        //                tags.Description
        //            });

        //            return Content(JsonConvert.SerializeObject(result), "application/json");
        //        }
        //    }
        //    else
        //    {
        //        var result = db.AuditTrailReports
        //     .Where(a => a.ActionDate.Value.Date.Date >= Convert.ToDateTime(actionstartdate) && a.ActionDate.Value.Date.Date <= Convert.ToDateTime(actionenddate))
        //        .Where(b => UserId.Length == 0 || UserId[0] == null ? true : UserId.Contains(b.UserId))
        //        .Where(c => actiontype.Length == 0 || actiontype[0] == null ? true : actiontype.Contains(c.ActionType))
        //     .ToPagedList(page, 600);
        //        return Content(JsonConvert.SerializeObject(result), "application/json");
        //    }

        //}

        //public ContentResult getTotalCount(string? actionstartdate, string? actionenddate, string?[] UserId, string?[] actiontype)
        //{
        //    if (string.IsNullOrEmpty(actionstartdate))
        //    {
        //        actionstartdate = DateTime.Now.AddMonths(-1).ToShortDateString();
        //    }
        //    if (string.IsNullOrEmpty(actionenddate))
        //    {
        //        actionenddate = DateTime.Now.ToShortDateString();
        //    }

        //    //if (string.IsNullOrEmpty(UserId))
        //    //{
        //    //    UserId = "";
        //    //}

        //    //if (string.IsNullOrEmpty(actiontype))
        //    //{
        //    //    actiontype = "";
        //    //}
        //    var result = db.AuditTrailReports
        //        .Where(a => a.ActionDate.Value.Date.Date >= Convert.ToDateTime(actionstartdate) && a.ActionDate.Value.Date.Date <= Convert.ToDateTime(actionenddate))
        //        .Where(b => UserId.Length == 0 || UserId[0] == null ? true : UserId.Contains(b.UserId))
        //        .Where(c => actiontype.Length == 0 || actiontype[0] == null ? true : actiontype.Contains(c.ActionType))
        //        .Count();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");

        //}

        //public ContentResult GetUserNameDropDown()
        //{
        //    var distinct_value = db.VaPersonInfos.GroupBy(s => s.Name).Select(g => g.Key).ToList().OrderBy(s => s);
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}

using DataGear_RV_Ver_1._7.dbfagpdb;
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

namespace ART_PACKAGE.Controllers.FATCA
{
    public class FATCACasesDetailsController : Controller
    {
        private readonly dbfagpdb.ModelContext dbfagpdb;
        private readonly IMemoryCache _cache;
        private readonly IDropDownService _dropDown;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly ICsvExport _csvSrv;
        public FATCACasesDetailsController(dbfagpdb.ModelContext dbfagpdb, IMemoryCache cache, IDropDownService dropDown, IHubContext<ExportHub> exportHub, ICsvExport csvSrv)
        {
            this.dbfagpdb = dbfagpdb;
            _cache = cache;
            this._dropDown = dropDown;
            _exportHub = exportHub;
            _csvSrv = csvSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtFatcaCace> data = dbfagpdb.ArtFatcaCaces.AsQueryable();

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(FATCACasesDetailsController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    //{"CaseType".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() }
                };

                ColumnsToSkip = new List<string>
                {
                    //"CaseRk",
                    //"ValidFromDate",
                };

            }

            var Data = data.CallData<ArtFatcaCace>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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



        //public ContentResult GetData(string? CaseId, string? CustomerId, string? CustomerName,
        //    string? BranchName, string? CaseStatus, string? CaseType, string? startCreateDate, string? endCreateDate,
        //    int page = 1)
        //{
        //    if (string.IsNullOrEmpty(CaseId))
        //    {
        //        CaseId = "";
        //    }
        //    if (string.IsNullOrEmpty(CustomerId))
        //    {
        //        CustomerId = "";
        //    }
        //    if (string.IsNullOrEmpty(CustomerName))
        //    {
        //        CustomerName = "";
        //    }
        //    if (string.IsNullOrEmpty(BranchName))
        //    {
        //        BranchName = "";
        //    }
        //    if (string.IsNullOrEmpty(CaseStatus))
        //    {
        //        CaseStatus = "";
        //    }
        //    if (string.IsNullOrEmpty(CaseType))
        //    {
        //        CaseType = "";
        //    }

        //    if (string.IsNullOrEmpty(startCreateDate))
        //    {
        //        startCreateDate = "2016-01-01";
        //    }
        //    if (string.IsNullOrEmpty(endCreateDate))
        //    {
        //        endCreateDate = DateTime.Now.ToShortDateString();
        //    }

        //    if (string.IsNullOrEmpty(startCreateDate) && string.IsNullOrEmpty(endCreateDate))
        //    {
        //        var result = db.ArtFatcaCaces
        //       .Where(a => a.CaseId.Contains(CaseId))
        //       .Where(c => c.CustomerId.Contains(CustomerId))
        //       .Where(d => d.CustomerName.Contains(CustomerName))
        //       .Where(e => e.BranchName.Contains(BranchName))
        //       .Where(f => f.CaseStatus.Contains(CaseStatus))
        //        .Where(j => j.CaseType.Contains(CaseType))
        //        .ToPagedList(page, 600);
        //        return Content(JsonConvert.SerializeObject(result), "application/json");
        //    }
        //    var result2 = db.ArtFatcaCaces
        //       .Where(a => a.CaseId.Contains(CaseId))
        //       .Where(c => c.CustomerId.Contains(CustomerId))
        //       .Where(d => d.CustomerName.Contains(CustomerName))
        //       .Where(e => e.BranchName.Contains(BranchName))
        //       .Where(f => f.CaseStatus.Contains(CaseStatus))
        //        .Where(j => j.CaseType.Contains(CaseType))
        //        .Where(g => g.CreateDate.Value >= Convert.ToDateTime(startCreateDate).Date.Date && g.CreateDate.Value <= Convert.ToDateTime(endCreateDate).Date.Date)
        //        .ToPagedList(page, 600);
        //    return Content(JsonConvert.SerializeObject(result2), "application/json");
        //}
        //public ContentResult getTotalCount()
        //{
        //    var result = db.ArtFatcaCaces.Count();

        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}

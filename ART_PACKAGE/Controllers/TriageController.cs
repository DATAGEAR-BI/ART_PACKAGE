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
using DataGear_RV_Ver_1._7.Helpers.CSVMAppers;

namespace DataGear_RV_Ver_1._7.Controllers
{
    public class TriageController : Controller
    {
        private readonly dbfcfkc.ModelContext dbfcfkc;
        private readonly IMemoryCache _cache;
        private readonly IDropDownService _dropDown;
        public TriageController(dbfcfkc.ModelContext dbfcfkc, IMemoryCache cache, IDropDownService dropDown)
        {
            this.dbfcfkc = dbfcfkc;
            _cache = cache; this._dropDown = dropDown;
        }


        //private readonly dbfcfkc.ModelContext db = new dbfcfkc.ModelContext();
        //private readonly dbfcfcore.ModelContext dbfcfcore = new dbfcfcore.ModelContext();
        //private readonly dbcmcaudit.ModelContext dbcmcaudit = new dbcmcaudit.ModelContext();

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<AmlTriageView> data = dbfcfkc.AmlTriageViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(TriageController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"BranchName".ToLower(), _dropDown.GetBranchNameDropDown().ToDynamicList() },
                    {"RiskScore".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
                    {"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() }
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(TriageController).ToLower()].SkipList;
            }
            var Data = data.CallData<AmlTriageView>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

        //public IActionResult Export([FromBody] ExportDto<decimal> req)
        //{
        //    var data = dbfcfkc.AmlTriageViews.AsQueryable();
        //    var bytes = data.ExportToCSV<AmlTriageView>(req.Req);
        //    return File(bytes, "test/csv");
        //}

        public async Task<IActionResult> Export([FromBody] ExportDto<string> exportDto)
        {

            var data = dbfcfkc.AmlTriageViews;
            if (exportDto.All)
            {

                var bytes = await data.ExportToCSV<AmlTriageView, GenericCsvClassMapper<AmlTriageView, TriageController>>(exportDto.Req);
                return File(bytes, "text/csv");

            }
            else
            {
                var bytes = await data.Where(x => exportDto.SelectedIdz.Contains(x.AlertedEntityNumber)).ExportToCSV<AmlTriageView, GenericCsvClassMapper<AmlTriageView, TriageController>>(all: false);
                return File(bytes, "text/csv");
            }

        }

        //public ContentResult GetData(string? entityname, string? entitynumber, string? branchnum, string? branchnm, string? riskscor, string? owner, int page = 1)
        //{
        //    if (string.IsNullOrEmpty(entityname))
        //    {
        //        entityname = "";
        //    }
        //    if (string.IsNullOrEmpty(entitynumber))
        //    {
        //        entitynumber = "";
        //    }
        //    if (string.IsNullOrEmpty(branchnum))
        //    {
        //        branchnum = "";
        //    }
        //    if (string.IsNullOrEmpty(branchnm))
        //    {
        //        branchnm = "";
        //    }
        //    if (string.IsNullOrEmpty(riskscor))
        //    {
        //        riskscor = "";
        //    }
        //    if (string.IsNullOrEmpty(owner))
        //    {
        //        owner = "";
        //    }

        //    var result_2 = db.AmlTriageViews
        //       .Where(s => s.AlertedEntityName.Contains(entityname))
        //       .Where(f => f.AlertedEntityNumber.Contains(entitynumber))
        //       .Where(g => g.BranchNumber.Contains(branchnum))
        //       .Where(i => i.BranchName.Contains(branchnm))
        //       .Where(j => j.RiskScore.Contains(riskscor))
        //       .Where(k => k.OwnerUserid.Contains(owner))
        //       .ToPagedList(page, 600);
        //    return Content(JsonConvert.SerializeObject(result_2), "application/json");

        //}

        //public ContentResult getTotalCount()
        //{
        //    var result = db.AmlTriageViews.Count();

        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}

        //public ContentResult GetBranchDropDown()
        //{
        //    var distinct_value = dbfcfcore.FscBranchDims
        //       .Where(a => a.ChangeCurrentInd.Contains("Y"))
        //       .Where(b => b.BranchTypeDesc.Contains("BRANCH"))
        //       .ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetOwnerDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaPersonInfos.GroupBy(s => s.Name).Select(g => g.Key).ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetRiskScoreDropDown()
        //{
        //    var distinct_value = db.FskLovs
        //        .Where(a => a.LovTypeName.StartsWith("RT_RISK_CLASSIFICATION"))
        //        .Where(b => b.LovLanguageDesc.Contains("en"))
        //        .ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}

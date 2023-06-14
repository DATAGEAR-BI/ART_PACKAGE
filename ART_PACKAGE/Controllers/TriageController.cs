
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Services;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;

namespace ART_PACKAGE.Controllers
{
    public class TriageController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IMemoryCache _cache;
        private readonly IDropDownService _dropDown;
        public TriageController(AuthContext dbfcfkc, IMemoryCache cache, IDropDownService dropDown)
        {
            this.dbfcfkc = dbfcfkc;
            _cache = cache; this._dropDown = dropDown;
        }


        //private readonly dbfcfkc.ModelContext db = new dbfcfkc.ModelContext();
        //private readonly dbfcfcore.ModelContext dbfcfcore = new dbfcfcore.ModelContext();
        //private readonly dbcmcaudit.ModelContext dbcmcaudit = new dbcmcaudit.ModelContext();

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtAmlTriageView> data = dbfcfkc.ArtAmlTriageViews.AsQueryable();

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
            var Data = data.CallData<ArtAmlTriageView>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

            var data = dbfcfkc.ArtAmlTriageViews;
            if (exportDto.All)
            {

                var bytes = await data.ExportToCSV<ArtAmlTriageView, GenericCsvClassMapper<ArtAmlTriageView, TriageController>>(exportDto.Req);
                return File(bytes, "text/csv");

            }
            else
            {
                var bytes = await data.Where(x => exportDto.SelectedIdz.Contains(x.AlertedEntityNumber)).ExportToCSV<ArtAmlTriageView, GenericCsvClassMapper<ArtAmlTriageView, TriageController>>(all: false);
                return File(bytes, "text/csv");
            }

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

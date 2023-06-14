
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Services;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;

namespace ART_PACKAGE.Controllers
{
    public class RiskAssessmentController : Controller
    {
        private readonly AuthContext dbfcfcore;
        private readonly IMemoryCache _cache;
        private readonly IDropDownService _dropDown;
        public RiskAssessmentController(AuthContext dbfcfcore, IMemoryCache cache, IDropDownService dropDown)
        {
            this.dbfcfcore = dbfcfcore;
            _cache = cache;
            this._dropDown = dropDown;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtRiskAssessmentView> data = dbfcfcore.ArtRiskAssessmentViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(RiskAssessmentController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    {"AssessmentTypeCd".ToLower(),_dropDown.GetAssessmentTypeDropDown().ToDynamicList() },
                    {"CreateUserId".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"RiskStatus".ToLower(),_dropDown.GetRiskStatusDropDown().ToDynamicList() },
                    {"RiskClass".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
                    {"ProposedRiskClass".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
                    {"OwnerUserLongId".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() }

                };
            }


            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(RiskAssessmentController).ToLower()].SkipList;
            var Data = data.CallData<ArtRiskAssessmentView>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = dbfcfcore.ArtRiskAssessmentViews.AsQueryable();
            var bytes = await data.ExportToCSV<ArtRiskAssessmentView, GenericCsvClassMapper<ArtRiskAssessmentView, RiskAssessmentController>>(req.Req);
            return File(bytes, "test/csv");
        }


       


        public IActionResult Index()
        {
            return View();
        }
    }
}

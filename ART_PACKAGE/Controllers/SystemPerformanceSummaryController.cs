using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Oracle.ManagedDataAccess.Client;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using System.Collections;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using System.Globalization;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    public class SystemPerformanceSummaryController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public SystemPerformanceSummaryController(AuthContext dbfcfkc, IMemoryCache cache, IConfiguration config)
        {
            this.dbfcfkc = dbfcfkc;
            _cache = cache;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStSystemPerfPerDate> chart1data = Enumerable.Empty<ArtStSystemPerfPerDate>().AsQueryable();
            IEnumerable<ArtStSystemPerfPerType> chart2data = Enumerable.Empty<ArtStSystemPerfPerType>().AsQueryable();
            IEnumerable<ArtStSystemPerfPerStatus> chart3data = Enumerable.Empty<ArtStSystemPerfPerStatus>().AsQueryable();


            var chart1Params = para.procFilters.MapToParameters(dbType);
            var chart2Params = para.procFilters.MapToParameters(dbType);
            var chart3Params = para.procFilters.MapToParameters(dbType);
            chart1data = dbfcfkc.ExecuteProc<ArtStSystemPerfPerDate>(ORACLESPName.ST_SYSTEM_PERFORMANCE_PER_DATE, chart1Params.ToArray());
            chart2data = dbfcfkc.ExecuteProc<ArtStSystemPerfPerType>(ORACLESPName.ST_SYSTEM_PERFORMANCE_PER_TYPE, chart2Params.ToArray());
            chart3data = dbfcfkc.ExecuteProc<ArtStSystemPerfPerStatus>(ORACLESPName.ST_SYSTEM_PERFORMANCE_PER_STATUS, chart3Params.ToArray());



            var chartData = new ArrayList {
                new ChartData<dynamic>
                {
                    ChartId = "StAlertsPerDate",
                    Data = chart1data.ToList().Select(x=> new { Month = DateTime.Parse($"15-{x.MONTH}") ,NUMBER_OF_CASES = x.NUMBER_OF_CASES }).ToDynamicList(),
                    Title = "Alerts Per Date",
                    Cat = "MONTH",
                    Val = "NUMBER_OF_CASES"

                },
                new ChartData<ArtStSystemPerfPerType>
                {
                    ChartId = "StAlertsPerType",
                    Data = chart2data.ToList(),
                    Title = "Alerts Per Type",
                    Cat = "CASE_TYPE",
                    Val = "TOTAL_NUMBER_OF_CASES"

                },
                new ChartData<ArtStSystemPerfPerStatus>
                {
                    ChartId = "StAlertPerStatus",
                    Data = chart3data.ToList(),
                    Title = "Alerts Per Status",
                    Cat = "CASE_STATUS",
                    Val = "TOTAL_NUMBER_OF_CASES"
                }
            };


            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(chartData, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                }),

            };



        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

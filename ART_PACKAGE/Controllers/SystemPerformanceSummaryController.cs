using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

using System.Data;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;
using Microsoft.Data.SqlClient;
using Data.Constants.StoredProcs;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using ART_PACKAGE.Helpers.CustomReportHelpers;

namespace ART_PACKAGE.Controllers
{
    [AllowAnonymous]
    public class SystemPerformanceSummaryController : Controller
    {
        private readonly AuthContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IMemoryCache _cache;

        public SystemPerformanceSummaryController(AuthContext _context,Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache)
        {
            this._env = env;
            _cache = cache;
            context = _context;
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtSystemPrefPerDirection> chart3Data = Enumerable.Empty<ArtSystemPrefPerDirection>().AsQueryable();
            IEnumerable<ArtSystemPrefPerStatus> chart1Data = Enumerable.Empty<ArtSystemPrefPerStatus>().AsQueryable();
            IEnumerable<ArtSystemPerfPerType> chart2data = Enumerable.Empty<ArtSystemPerfPerType>().AsQueryable();


            var startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value;
            var endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value;
            //var case_id = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_id".ToLower())?.value ?? "";
            //var case_type = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_type".ToLower())?.value ?? "";
            //var case_status = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_status".ToLower())?.value ?? "";
            var sd = new SqlParameter("@V_START_DATE", SqlDbType.Date)
            {
                Value = startDate
            };
            var ed = new SqlParameter("@V_END_DATE", SqlDbType.Date)
            {
                Value = endDate
            };
            var sd1 = new SqlParameter("@V_START_DATE", SqlDbType.Date)
            {
                Value = startDate
            };
            var ed1 = new SqlParameter("@V_END_DATE", SqlDbType.Date)
            {
                Value = endDate
            };
            var sd3 = new SqlParameter("@V_START_DATE", SqlDbType.Date)
            {
                Value = startDate
            };
            var ed3 = new SqlParameter("@V_END_DATE", SqlDbType.Date)
            {
                Value = endDate
            };

            chart3Data = context.ExecuteProc<ArtSystemPrefPerDirection>(SPNames.ST_SYSTEM_PERF_PER_DIRECTION,sd,ed);
            chart1Data = context.ExecuteProc<ArtSystemPrefPerStatus>(SPNames.ST_SYSTEM_PERF_PER_STATUS, sd1, ed1);
            chart2data = context.ExecuteProc<ArtSystemPerfPerType>(SPNames.ST_SYSTEM_PERF_PER_TYPE, sd3,ed3);


            //var Data = data.CallData<StSystemCasesPerYearMonth>(para.req);
            var chartData = new ArrayList {
                new ChartData<ArtSystemPrefPerStatus>
                {
                    ChartId = "StSystemPerfPerStatus",
                    Data = chart1Data.ToList(),
                    Title = "Cases Per Status",
                    Cat = "case_status",
                    Val = "Total_Number_of_Cases"

                },
                new ChartData<ArtSystemPerfPerType>
                {
                    ChartId = "StSystemPerfPerType",
                    Data = chart2data.ToList(),
                    Title = "Cases Per Type",
                    Cat = "CASE_TYPE",
                    Val = "Total_Number_of_Cases"
                },
                new ChartData<ArtSystemPrefPerDirection>
                {
                    ChartId = "StSystemPerfPerTransDir",
                    Data = chart3Data.ToList(),
                    Title = "Cases Per Trans Deriction",
                    Cat = "TREANSACTION_DIRECTION",
                    Val = "Total_Number_of_Cases"
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

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

namespace DataGear_RV_Ver_1._7.Controllers
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
            IQueryable<ArtSystemPrefPerDirection> chart1Data = Enumerable.Empty<ArtSystemPrefPerDirection>().AsQueryable();
            //IQueryable<StSystemPerfPerType> chart2data = Enumerable.Empty<StSystemPerfPerType>().AsQueryable();


            var startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value;
            var endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value;
            //var case_id = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_id".ToLower())?.value ?? "";
            //var case_type = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_type".ToLower())?.value ?? "";
            //var case_status = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_status".ToLower())?.value ?? "";
            var sd = new SqlParameter("startDate", SqlDbType.VarChar)
            {
                Value = startDate
            };
            var ed = new SqlParameter("endDate", SqlDbType.VarChar)
            {
                Value = endDate
            };
            var sd1 = new SqlParameter("startDate", SqlDbType.Date)
            {
                Value = startDate
            };
            var ed1 = new SqlParameter("endDate", SqlDbType.Date)
            {
                Value = endDate
            };
            var sd3 = new SqlParameter("startDate", SqlDbType.Date)
            {
                Value = startDate
            };
            var ed3 = new SqlParameter("endDate", SqlDbType.Date)
            {
                Value = endDate
            };

            chart3Data = context.ExecuteProc<ArtSystemPrefPerDirection>(SPNames.ST_SYSTEM_PERF_PER_DIRECTION,sd,ed);
            //chart1Data = dbdgcmgmt.ExecuteProc<StSystemPerfPerStatus>("ART_ST_SYSTEM_PERF_PER_STATUS", chart1output, sdch1, edch1/*, cich1, ctch1, csch1*/);
            //chart2data = dbdgcmgmt.ExecuteProc<StSystemPerfPerType>("ART_ST_SYSTEM_PERF_PER_TYPE", chart2output, sdch2, edch2/*, cich2, ctch2, csch2*/);


            //var Data = data.CallData<StSystemCasesPerYearMonth>(para.req);
            var chartData = new ArrayList {
                //new ChartData<StSystemPerfPerStatus>
                //{
                //    ChartId = "StSystemPerfPerStatus",
                //    Data = chart1Data.ToList(),
                //    Title = "Cases Per Status",
                //    Cat = "CASE_STATUS",
                //    Val = "TOTAL_NUMBER_OF_CASES"

                //},
                //new ChartData<StSystemPerfPerType>
                //{
                //    ChartId = "StSystemPerfPerType",
                //    Data = chart2data.ToList(),
                //    Title = "Cases Per Type",
                //    Cat = "CASE_TYPE",
                //    Val = "TOTAL_NUMBER_OF_CASES"
                //},
                new ChartData<ArtSystemPrefPerDirection>
                {
                    ChartId = "StSystemPerfPerTransDir",
                    Data = chart3Data.ToList(),
                    Title = "Cases Per Trans Deriction",
                    Cat = "TREANSACTION_DIRECTION",
                    Val = "TOTAL_NUMBER_OF_CASES"
                }
            };



            //var result = new
            //{
            //    data = Data.Data,
            //    columns = Data.Columns?.Where(x => x.name == "YEAR" || x.name == "TOTAL_NUMBER_OF_CASES"),
            //    grouplist = new List<string> {

            //        "YEAR",
            //        "MONTH"
            //    },
            //    vallist = new List<string>
            //    {
            //        "TOTAL_NUMBER_OF_CASES",
            //        "TOTAL_NUMBER_OF_CASES"
            //    },
            //    total = Data.Total,
            //    chartdata = chartData
            //};
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(chartData, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                }),

            };
        }


        //public ContentResult ArtSystemPerformTransDir(string? createstartdate, string? createenddate)
        //{
        //    if (string.IsNullOrEmpty(createstartdate))
        //    {
        //        createstartdate = DateTime.Now.AddMonths(-1).ToShortDateString();
        //    }
        //    if (string.IsNullOrEmpty(createenddate))
        //    {
        //        createenddate = DateTime.Now.AddDays(1).ToShortDateString();
        //    }

        //    var result = dgcmgmt.ArtSystemPerformTransDirs
        //    .Where(s => s.CreateDate >= DateTime.Parse(createstartdate) && s.CreateDate <= DateTime.Parse(createenddate));

        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        //public ContentResult ArtSystemPerformPerType(string? createstartdate, string? createenddate)
        //{
        //    if (string.IsNullOrEmpty(createstartdate))
        //    {
        //        createstartdate = DateTime.Now.AddMonths(-1).ToShortDateString();
        //    }
        //    if (string.IsNullOrEmpty(createenddate))
        //    {
        //        createenddate = DateTime.Now.AddDays(1).ToShortDateString();
        //    }

        //    var result = dgcmgmt.ArtSystemPerformPerTypes
        //    .Where(s => s.CreateDate >= DateTime.Parse(createstartdate) && s.CreateDate <= DateTime.Parse(createenddate));

        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        //public ContentResult ArtSystemPerformPerStatus(string? createstartdate, string? createenddate)
        //{
        //    if (string.IsNullOrEmpty(createstartdate))
        //    {
        //        createstartdate = DateTime.Now.AddMonths(-1).ToShortDateString();
        //    }
        //    if (string.IsNullOrEmpty(createenddate))
        //    {
        //        createenddate = DateTime.Now.AddDays(1).ToShortDateString();
        //    }

        //    var result = dgcmgmt.ArtSystemPerformPerStatuses
        //    .Where(s => s.CreateDate >= DateTime.Parse(createstartdate) && s.CreateDate <= DateTime.Parse(createenddate));

        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}

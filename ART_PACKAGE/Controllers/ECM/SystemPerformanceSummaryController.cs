using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.ECM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Areas.Identity.Data;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "SystemPerformanceSummary")]
    public class SystemPerformanceSummaryController : Controller
    {
        private readonly EcmContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public SystemPerformanceSummaryController(EcmContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IConfiguration config)
        {
            _env = env;
            _cache = cache;
            context = _context;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtSystemPrefPerDirection> chart3Data = Enumerable.Empty<ArtSystemPrefPerDirection>().AsQueryable();
            IEnumerable<ArtSystemPerfPerDate> chart4Data = Enumerable.Empty<ArtSystemPerfPerDate>().AsQueryable();
            IEnumerable<ArtSystemPrefPerStatus> chart1Data = Enumerable.Empty<ArtSystemPrefPerStatus>().AsQueryable();
            IEnumerable<ArtSystemPerfPerType> chart2data = Enumerable.Empty<ArtSystemPerfPerType>().AsQueryable();


            //var startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value;
            //var endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "enddate".ToLower())?.value;
            ////var case_id = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_id".ToLower())?.value ?? "";
            ////var case_type = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_type".ToLower())?.value ?? "";
            ////var case_status = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_status".ToLower())?.value ?? "";
            //var sd = new SqlParameter("@V_START_DATE", SqlDbType.Date)
            //{
            //    Value = startDate
            //};
            //var ed = new SqlParameter("@V_END_DATE", SqlDbType.Date)
            //{
            //    Value = endDate
            //};
            //var sd1 = new SqlParameter("@V_START_DATE", SqlDbType.Date)
            //{
            //    Value = startDate
            //};
            //var ed1 = new SqlParameter("@V_END_DATE", SqlDbType.Date)
            //{
            //    Value = endDate
            //};
            //var sd3 = new SqlParameter("@V_START_DATE", SqlDbType.Date)
            //{
            //    Value = startDate
            //};
            //var ed3 = new SqlParameter("@V_END_DATE", SqlDbType.Date)
            //{
            //    Value = endDate
            //};
            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart4Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart3Data = context.ExecuteProc<ArtSystemPrefPerDirection>(SQLSERVERSPNames.ST_SYSTEM_PERF_PER_DIRECTION, chart3Params.ToArray());
                chart1Data = context.ExecuteProc<ArtSystemPrefPerStatus>(SQLSERVERSPNames.ST_SYSTEM_PERF_PER_STATUS, chart1Params.ToArray());
                chart2data = context.ExecuteProc<ArtSystemPerfPerType>(SQLSERVERSPNames.ST_SYSTEM_PERF_PER_TYPE, chart2Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = context.ExecuteProc<ArtSystemPrefPerStatus>(ORACLESPName.ST_SYSTEM_PERF_PER_STATUS, chart1Params.ToArray());
                chart2data = context.ExecuteProc<ArtSystemPerfPerType>(ORACLESPName.ST_SYSTEM_PERF_PER_TYPE, chart2Params.ToArray());
                chart4Data = context.ExecuteProc<ArtSystemPerfPerDate>(ORACLESPName.ST_SYSTEM_PERF_PER_DATE, chart4Params.ToArray());
                chart3Data = context.ExecuteProc<ArtSystemPrefPerDirection>(ORACLESPName.ST_SYSTEM_PERF_PER_DIRECTION, chart3Params.ToArray());

            }
            if (dbType == DbTypes.MySql)
            {
                chart1Data = context.ExecuteProc<ArtSystemPrefPerStatus>(MYSQLSPName.ST_SYSTEM_PERF_PER_STATUS, chart1Params.ToArray());
                chart2data = context.ExecuteProc<ArtSystemPerfPerType>(MYSQLSPName.ST_SYSTEM_PERF_PER_TYPE, chart2Params.ToArray());
                chart3Data = context.ExecuteProc<ArtSystemPrefPerDirection>(MYSQLSPName.ST_SYSTEM_PERF_PER_DIRECTION, chart3Params.ToArray());
                chart4Data = context.ExecuteProc<ArtSystemPerfPerDate>(MYSQLSPName.ST_SYSTEM_PERF_PER_DATE, chart4Params.ToArray());

            }

            //var Data = data.CallData<StSystemCasesPerYearMonth>(para.req);
            ArrayList chartData = new()
            {
                new ChartData<ArtSystemPrefPerStatus>
                {
                    ChartId = "StSystemPerfPerStatus",
                    Data = chart1Data.ToList(),
                    Title = "Cases Per Status",
                    Cat = "CASE_STATUS",
                    Val = "TOTAL_NUMBER_OF_CASES",
                    Type = ChartType.donut

                },
                new ChartData<ArtSystemPerfPerType>
                {
                    ChartId = "StSystemPerfPerType",
                    Data = chart2data.ToList(),
                    Title = "Cases Per Type",
                    Cat = "CASE_TYPE",
                    Val = "TOTAL_NUMBER_OF_CASES",
                    Type = ChartType.donut
                },


            };
            if (dbType is DbTypes.Oracle or DbTypes.MySql)
            {
                _ = chartData.Add(new ChartData<ArtSystemPrefPerDirection>
                {
                    ChartId = "StSystemPerfPerTransDir",
                    Data = chart3Data.Select(x =>
                    {
                        x.TRANSACTION_DIRECTION ??= "UNKOWN";
                        return x;
                    }).ToList(),
                    Title = "Cases Per Direction",//Swift
                    Cat = "TRANSACTION_DIRECTION",
                    Val = "TOTAL_NUMBER_OF_CASES",
                    Type = ChartType.donut
                });

                /*_ = chartData.Add(new ChartData<dynamic>
                {
                    ChartId = "StSystemPerfPerDate",
                    //Data = chart4Data.Select(x => new { Date = DateTime.ParseExact($"{x.DAY}-{x.MONTH.Trim()}-{x.YEAR}", "d-MMMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None), CASES = x.NUMBER_OF_CASES }).ToDynamicList(),
                    Data = chart4Data.GroupBy(x => new { x.YEAR, x.MONTH }).Select(x => new { Date = DateTime.ParseExact($"{15}-{x.Key.MONTH.Trim()}-{x.Key.YEAR}", "d-MMM-yyyy", null), CASES = x.Sum(x => x.NUMBER_OF_CASES) }).ToDynamicList(),
                    Title = "Cases Per Trans Direction",
                    Cat = "Date",
                    Val = "CASES",
                    Type = ChartType.curvedline
                });*/
            }
            if (dbType is DbTypes.SqlServer or DbTypes.MySql)
            {
                _ = chartData.Add(new ChartData<ArtSystemPrefPerDirection>
                {
                    ChartId = "StSystemPerfPerTransDir",
                    Data = chart3Data.Select(x =>
                    {
                        x.TRANSACTION_DIRECTION ??= "UNKOWN";
                        return x;
                    }).ToList(),
                    Title = "Swift Cases Per Direction",
                    Cat = "TRANSACTION_DIRECTION",
                    Val = "TOTAL_NUMBER_OF_CASES",
                    Type = ChartType.donut
                });
            }
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

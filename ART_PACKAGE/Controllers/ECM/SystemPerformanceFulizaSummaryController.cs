using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.StoredProcs;
using Data.Data.ECM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.ECM
{

    public class SystemPerformanceFulizaSummaryController : Controller
    {
        private readonly EcmContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;

        public SystemPerformanceFulizaSummaryController(EcmContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IConfiguration config)
        {
            _env = env;
            _cache = cache;
            context = _context;
            _config = config;
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtSystemPerfPerDateFuliza> chart3Data = Enumerable.Empty<ArtSystemPerfPerDateFuliza>().AsQueryable();
            IEnumerable<ArtSystemPrefPerStatusFuliza> chart1Data = Enumerable.Empty<ArtSystemPrefPerStatusFuliza>().AsQueryable();
            IEnumerable<ArtSystemPerfPerTypeFuliza> chart2data = Enumerable.Empty<ArtSystemPerfPerTypeFuliza>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters("ORACLE");
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters("ORACLE");
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters("ORACLE");

            chart1Data = context.ExecuteProc<ArtSystemPrefPerStatusFuliza>(ORACLESPName.ART_ST_SYSTEM_PERF_PER_STATUS_FULIZA, chart1Params.ToArray());
            chart2data = context.ExecuteProc<ArtSystemPerfPerTypeFuliza>(ORACLESPName.ART_ST_SYSTEM_PERF_PER_TYPE_FULIZA, chart2Params.ToArray());
            chart3Data = context.ExecuteProc<ArtSystemPerfPerDateFuliza>(ORACLESPName.ART_ST_SYSTEM_PERF_PER_DATE_FULIZA, chart3Params.ToArray());

            ArrayList chartData = new()
            {
                new ChartData<ArtSystemPrefPerStatusFuliza>
                {
                    ChartId = "StSystemPerfPerStatus",
                    Data = chart1Data.ToList(),
                    Title = "Cases Per Status",
                    Cat = "CASE_STATUS",
                    Val = "TOTAL_NUMBER_OF_CASES"

                },
                new ChartData<ArtSystemPerfPerTypeFuliza>
                {
                    ChartId = "StSystemPerfPerType",
                    Data = chart2data.ToList(),
                    Title = "Cases Per Type",
                    Cat = "CASE_TYPE",
                    Val = "TOTAL_NUMBER_OF_CASES"
                },
                new ChartData<dynamic>
                {
                    ChartId = "StSystemPerfPerDate",
                    //Data = chart4Data.Select(x => new { Date = DateTime.ParseExact($"{x.DAY}-{x.MONTH.Trim()}-{x.YEAR}", "d-MMMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None), CASES = x.NUMBER_OF_CASES }).ToDynamicList(),
                    Data = chart3Data.GroupBy(x => new { x.YEAR, x.MONTH }).Select(x => new { Date = DateTime.ParseExact($"{15}-{x.Key.MONTH.Trim()}-{x.Key.YEAR}", "d-MMM-yyyy", null), CASES = x.Sum(x => x.NUMBER_OF_CASES) }).ToDynamicList(),
                    Title = "Cases Per Month",
                    Cat = "Date",
                    Val = "CASES"
                },


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

using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.StoredProcs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data.DGINTFRAUD;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    //[Authorize(Roles = "SystemPerformanceSummary")]
    public class SystemPerformanceSummaryController : Controller
    {
        private readonly DGINTFRAUDContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public SystemPerformanceSummaryController(DGINTFRAUDContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IConfiguration config)
        {
            _env = env;
            _cache = cache;
            context = _context;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStDgAmlCasePerPriority> chart1Data = Enumerable.Empty<ArtStDgAmlCasePerPriority>().AsQueryable();
            IEnumerable<ArtStDgAmlCasePerType> chart2data = Enumerable.Empty<ArtStDgAmlCasePerType>().AsQueryable();
            IEnumerable<ArtStDgAmlCasePerStatus> chart3Data = Enumerable.Empty<ArtStDgAmlCasePerStatus>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters(dbType);
            
            
            chart1Data = context.ExecuteProc<ArtStDgAmlCasePerPriority>(ORACLESPName.ART_ST_DGAML_CASES_PER_PRIORITY, chart1Params.ToArray());
            chart2data = context.ExecuteProc<ArtStDgAmlCasePerType>(ORACLESPName.ART_ST_DGAML_CASES_PER_TYPE, chart2Params.ToArray());
            chart3Data = context.ExecuteProc<ArtStDgAmlCasePerStatus>(ORACLESPName.ART_ST_DGAML_CASES_PER_STATUS, chart3Params.ToArray());

            ArrayList chartData = new()
            {
                new ChartData<ArtStDgAmlCasePerPriority>
                {
                    ChartId = "StDgAmlCasePerPriority",
                    Data = chart1Data.ToList(),
                    Title = "Cases Per Priority",
                    Cat = "PRIORITY",
                    Val = "TOTAL_NUMBER_OF_CASES",
                    Type = ChartType.donut

                },
                new ChartData<ArtStDgAmlCasePerType>
                {
                    ChartId = "StDgAmlCasePerType",
                    Data = chart2data.ToList(),
                    Title = "Cases Per Type",
                    Cat = "TYPE",
                    Val = "TOTAL_NUMBER_OF_CASES",
                    Type = ChartType.donut
                },
                new ChartData<ArtStDgAmlCasePerStatus>
                {
                    ChartId = "StDgAmlCasePerStatus",
                    Data = chart3Data.ToList(),
                    Title = "Cases Per Status",
                    Cat = "CASE_STATUS",
                    Val = "TOTAL_NUMBER_OF_CASES",
                    Type = ChartType.donut
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

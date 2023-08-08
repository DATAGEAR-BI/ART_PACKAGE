using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections;

namespace ART_PACKAGE.Controllers
{
    public class DGAMLCasesSummaryController : Controller
    {
        private readonly AuthContext _context;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public DGAMLCasesSummaryController(AuthContext _context, IMemoryCache cache, IConfiguration config)
        {
            this._context = _context;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStDgAmlCasesPerStatus> chart1Data = Enumerable.Empty<ArtStDgAmlCasesPerStatus>().AsQueryable();
            IEnumerable<ArtStDgAmlCasesPerCategory> chart2data = Enumerable.Empty<ArtStDgAmlCasesPerCategory>().AsQueryable(); ;
            IEnumerable<ArtStDgAmlCasesPerPriority> chart4Data = Enumerable.Empty<ArtStDgAmlCasesPerPriority>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart4Params = para.procFilters.MapToParameters(dbType);

            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = _context.ExecuteProc<ArtStDgAmlCasesPerStatus>(SQLSERVERSPNames.ART_ST_DGAML_CASES_PER_STATUS, chart1Params.ToArray());
                chart2data = _context.ExecuteProc<ArtStDgAmlCasesPerCategory>(SQLSERVERSPNames.ART_ST_DGAML_CASES_PER_CATEGORY, chart2Params.ToArray());
                chart4Data = _context.ExecuteProc<ArtStDgAmlCasesPerPriority>(SQLSERVERSPNames.ART_ST_DGAML_CASES_PER_PRIORITY, chart4Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                //chart1Data = _context.ExecuteProc<ArtStCasesPerStatus>(ORACLESPName.ART_ST_CASES_PER_STATUS, chart1Params.ToArray());
                //chart2data = _context.ExecuteProc<ArtStCasesPerCategory>(ORACLESPName.ART_ST_CASES_PER_CATEGORY, chart2Params.ToArray());
                //chart3Data = _context.ExecuteProc<ArtStCasesPerSubcat>(ORACLESPName.ART_ST_CASES_PER_SUBCAT, chart3Params.ToArray());
                //chart4Data = _context.ExecuteProc<ArtStCasesPerPriority>(ORACLESPName.ART_ST_CASES_PER_PRIORITY, chart4Params.ToArray());

            }

            ArrayList chartData = new()
            {
                new ChartData<ArtStDgAmlCasesPerStatus>
                {
                    ChartId = "StCasesPerStatus",
                    Data = chart1Data.ToList(),
                    Title = "Cases Per Status",
                    Cat = "CASE_STATUS",
                    Val = "NUMBER_OF_CASES"

                },
                new ChartData<ArtStDgAmlCasesPerCategory>
                {
                    ChartId = "StCasesPerCategory",
                    Data = chart2data.ToList(),
                    Title = "Cases Per Category",
                    Cat = "CASE_CATEGORY",
                    Val = "NUMBER_OF_CASES"
                },

                new ChartData<ArtStDgAmlCasesPerPriority>
                {
                    ChartId = "StCasesPerPriority",
                    Data = chart4Data.ToList(),
                    Title = "Cases Per Priority",
                    Cat = "CASE_PRIORITY",
                    Val = "NUMBER_OF_CASES"
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

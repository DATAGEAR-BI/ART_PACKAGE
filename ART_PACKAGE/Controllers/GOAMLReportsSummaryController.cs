using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Data;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Data.Data.ARTGOAML;

namespace ART_PACKAGE.Controllers
{
    public class GOAMLReportsSummaryController : Controller
    {
        private readonly ArtGoAmlContext _context;
        private readonly string dbType;
        public GOAMLReportsSummaryController(ArtGoAmlContext context, IConfiguration _config)
        {
            _context = context;
            dbType = _config.GetValue<string>("dbType").ToUpper();
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {

            IEnumerable<ArtStGoAmlReportsPerCreator> chart3Data = Enumerable.Empty<ArtStGoAmlReportsPerCreator>();
            IEnumerable<ArtStGoAmlReportsPerType> chart1Data = Enumerable.Empty<ArtStGoAmlReportsPerType>();
            IEnumerable<ArtStGoAmlReportsPerStatus> chart2data = Enumerable.Empty<ArtStGoAmlReportsPerStatus>();

            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters(dbType);

            if (dbType == DbTypes.SqlServer)
            {
                chart3Data = _context.ExecuteProc<ArtStGoAmlReportsPerCreator>(SQLSERVERSPNames.ART_ST_GOAML_REPORTS_PER_CREATOR, chart3Params.ToArray());
                chart1Data = _context.ExecuteProc<ArtStGoAmlReportsPerType>(SQLSERVERSPNames.ART_ST_GOAML_REPORTS_PER_TYPE, chart1Params.ToArray());
                chart2data = _context.ExecuteProc<ArtStGoAmlReportsPerStatus>(SQLSERVERSPNames.ART_ST_GOAML_REPORTS_PER_STATUS, chart2Params.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                chart3Data = _context.ExecuteProc<ArtStGoAmlReportsPerCreator>(ORACLESPName.ART_ST_GOAML_REPORTS_PER_CREATOR, chart3Params.ToArray());
                chart1Data = _context.ExecuteProc<ArtStGoAmlReportsPerType>(ORACLESPName.ART_ST_GOAML_REPORTS_PER_TYPE, chart1Params.ToArray());
                chart2data = _context.ExecuteProc<ArtStGoAmlReportsPerStatus>(ORACLESPName.ART_ST_GOAML_REPORTS_PER_STATUS, chart2Params.ToArray());
            }


            //var Data = data.CallData<StSystemCasesPerYearMonth>(para.req);
            ArrayList chartData = new()
            {
                new ChartData<ArtStGoAmlReportsPerType>
                {
                    ChartId = "StGoamlReportsPerType",
                    Data = chart1Data.ToList(),
                    Title = "Number of Reports Per Type",
                    Cat = "REPORT_TYPE",
                    Val = "NUMBER_OF_REPORTS"

                },
                new ChartData<ArtStGoAmlReportsPerStatus>
                {
                    ChartId = "StGoamlReportsPerStatus",
                    Data = chart2data.ToList(),
                    Title = "Number of Reports Per Status",
                    Cat = "REPORT_STATUS",
                    Val = "NUMBER_OF_REPORTS"
                },
                new ChartData<ArtStGoAmlReportsPerCreator>
                {
                    ChartId = "StGoamlReportsPerCreator",
                    Data = chart3Data.ToList(),
                    Title = "Number of Reports Per Creator",
                    Cat = "CREATED_BY",
                    Val = "NUMBER_OF_REPORTS"
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

        public IActionResult Index()
        {
            return View();
        }
    }
}

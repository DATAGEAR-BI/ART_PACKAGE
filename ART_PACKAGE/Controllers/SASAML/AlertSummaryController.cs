using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.ARTDGAML;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "AlertSummary")]
    public class AlertSummaryController : Controller
    {
        private readonly SasAmlContext dbfcfkc;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public AlertSummaryController(SasAmlContext dbfcfkc, IConfiguration config)
        {
            this.dbfcfkc = dbfcfkc;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStAmlAlertsPerStatus> chart1Data = Enumerable.Empty<ArtStAmlAlertsPerStatus>().AsQueryable();
            IEnumerable<ArtStAmlAlertsPerBranch> chart2data = Enumerable.Empty<ArtStAmlAlertsPerBranch>().AsQueryable();
            IEnumerable<ArtStAmlAlertsPerScenario> chart3data = Enumerable.Empty<ArtStAmlAlertsPerScenario>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerStatus>(SQLSERVERSPNames.ART_ST_AML_ALERTS_PER_STATUS, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerBranch>(SQLSERVERSPNames.ART_ST_AML_ALERTS_PER_BRANCH, chart2Params.ToArray());
                chart3data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerScenario>(SQLSERVERSPNames.ART_ST_AML_ALERTS_PER_SCENARIO, chart2Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {

                chart1Data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerStatus>(ORACLESPName.ART_ST_AML_ALERTS_PER_STATUS, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerBranch>(ORACLESPName.ART_ST_AML_ALERTS_PER_BRANCH, chart2Params.ToArray());
                chart3data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerScenario>(ORACLESPName.ART_ST_AML_ALERTS_PER_SCENARIO, chart2Params.ToArray());


            }


            ArrayList chartData = new()
            {
                new ChartData<ArtStAmlAlertsPerStatus>
                {
                    ChartId = "StAmlAlertsPerStatus",
                    Data = chart1Data.ToList(),
                    Title = "Alerts Per Status",
                    Cat = "ALERT_STATUS",
                    Val = "ALERTS_COUNT",
                    Type = ChartType.donut

                },
                new ChartData<ArtStAmlAlertsPerBranch>
                {
                    ChartId = "StAmlAlertsPerBranch",
                    Data = chart2data.ToList(),
                    Title = "Alerts Per Branch",
                    Cat = "BRANCH_NAME",
                    Val = "ALERTS_COUNT",
                    Type = ChartType.bar

                },
                  new ChartData<ArtStAmlAlertsPerScenario>
                {
                    ChartId = "StAmlAlertsPerScenario",
                    Data = chart3data.ToList(),
                    Title = "Alerts Per Scenario",
                    Cat = "SCENARIO_NAME",
                    Val = "ALERTS_COUNT",
                    Type = ChartType.bar

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

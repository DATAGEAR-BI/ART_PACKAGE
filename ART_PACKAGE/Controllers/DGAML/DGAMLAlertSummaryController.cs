using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using ART_PACKAGE.Areas.Identity.Data;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLAlertSummaryController : Controller
    {
        private readonly ArtDgAmlContext _context;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public DGAMLAlertSummaryController(ArtDgAmlContext _context, IConfiguration config)
        {
            this._context = _context;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStDgAmlAlertsPerStatus> chart1Data = Enumerable.Empty<ArtStDgAmlAlertsPerStatus>().AsQueryable();
            IEnumerable<ArtStDgAmlAlertPerOwner> chart2data = Enumerable.Empty<ArtStDgAmlAlertPerOwner>().AsQueryable();
            IEnumerable<ArtStDgAmlAlertsPerBranch> chart3data = Enumerable.Empty<ArtStDgAmlAlertsPerBranch>().AsQueryable();
            IEnumerable<ArtStDgAmlAlertsPerScenario> chart4data = Enumerable.Empty<ArtStDgAmlAlertsPerScenario>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart4Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = _context.ExecuteProc<ArtStDgAmlAlertsPerStatus>(SQLSERVERSPNames.ART_ST_DGAML_ALERTS_PER_STATUS, chart1Params.ToArray());
                chart2data = _context.ExecuteProc<ArtStDgAmlAlertPerOwner>(SQLSERVERSPNames.ART_ST_DGAML_ALERT_PER_OWNER, chart2Params.ToArray());
                chart3data = _context.ExecuteProc<ArtStDgAmlAlertsPerBranch>(SQLSERVERSPNames.ART_ST_DGAML_ALERTS_PER_BRANCH, chart3Params.ToArray());
                chart4data = _context.ExecuteProc<ArtStDgAmlAlertsPerScenario>(SQLSERVERSPNames.ART_ST_DGAML_ALERTS_PER_SCENARIO, chart4Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = _context.ExecuteProc<ArtStDgAmlAlertsPerStatus>(ORACLESPName.ART_ST_DGAML_ALERTS_PER_STATUS, chart1Params.ToArray());
                chart2data = _context.ExecuteProc<ArtStDgAmlAlertPerOwner>(ORACLESPName.ART_ST_DGAML_ALERT_PER_OWNER, chart2Params.ToArray());
                chart3data = _context.ExecuteProc<ArtStDgAmlAlertsPerBranch>(ORACLESPName.ART_ST_DGAML_ALERTS_PER_BRANCH, chart3Params.ToArray());
                chart4data = _context.ExecuteProc<ArtStDgAmlAlertsPerScenario>(ORACLESPName.ART_ST_DGAML_ALERTS_PER_SCENARIO, chart4Params.ToArray());
              

            }
            if (dbType == DbTypes.MySql)
            {

                chart1Data = _context.ExecuteProc<ArtStDgAmlAlertsPerStatus>(MYSQLSPName.ART_ST_DGAML_ALERTS_PER_STATUS, chart1Params.ToArray());
                chart2data = _context.ExecuteProc<ArtStDgAmlAlertPerOwner>(MYSQLSPName.ART_ST_DGAML_ALERT_PER_OWNER, chart2Params.ToArray());
                chart3data = _context.ExecuteProc<ArtStDgAmlAlertsPerBranch>(MYSQLSPName.ART_ST_DGAML_ALERTS_PER_BRANCH, chart3Params.ToArray());
                chart4data = _context.ExecuteProc<ArtStDgAmlAlertsPerScenario>(MYSQLSPName.ART_ST_DGAML_ALERTS_PER_SCENARIO, chart4Params.ToArray());

            }

            ArrayList chartData = new()
            {
                new ChartData<ArtStDgAmlAlertsPerStatus>
                {
                    ChartId = "StAlertsPerStatus",
                    Data = chart1Data.ToList(),
                    Title = "Alerts Per Status",
                    Cat = "ALERT_STATUS",
                    Val = "ALERTS_COUNT",
                    Type = ChartType.donut
                },
                new ChartData<ArtStDgAmlAlertPerOwner>
                {
                    ChartId = "StAlertPerOwner",
                    Data = chart2data.ToList(),
                    Title = "Alerts Per Owner",
                    Cat = "OWNER_QUEUE",
                    Val = "ALERTS_CNT_SUM",
                    Type = ChartType.donut
                },
                new ChartData<ArtStDgAmlAlertsPerBranch>
                {
                    ChartId = "StAlertPerBranch",
                    Data = chart3data.ToList(),
                    Title = "Alerts Per Branch",
                    Cat = "BRANCH_NAME",
                    Val = "ALERTS_COUNT",
                    Type = ChartType.bar
                },
                new ChartData<ArtStDgAmlAlertsPerScenario>
                {
                    ChartId = "StAlertPerScenario",
                    Data = chart4data.ToList(),
                    Title = "Alerts Per Scenario",
                    Cat = "SCENARIO_NAME",
                    Val = "ALERTS_COUNT",
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

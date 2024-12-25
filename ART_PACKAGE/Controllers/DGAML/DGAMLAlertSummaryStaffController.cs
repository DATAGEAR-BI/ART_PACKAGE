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
    public class DGAMLAlertSummaryStaffController : Controller
    {
        private readonly ArtDgAmlContext _context;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public DGAMLAlertSummaryStaffController(ArtDgAmlContext _context, IConfiguration config)
        {
            this._context = _context;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStDgAmlAlertsPerStatusStaff> chart1Data = Enumerable.Empty<ArtStDgAmlAlertsPerStatusStaff>().AsQueryable();
            IEnumerable<ArtStDgAmlAlertPerOwnerStaff> chart2data = Enumerable.Empty<ArtStDgAmlAlertPerOwnerStaff>().AsQueryable();
            IEnumerable<ArtStDgAmlAlertsPerBranchStaff> chart3data = Enumerable.Empty<ArtStDgAmlAlertsPerBranchStaff>().AsQueryable();
            IEnumerable<ArtStDgAmlAlertsPerScenarioStaff> chart4data = Enumerable.Empty<ArtStDgAmlAlertsPerScenarioStaff>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart4Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = _context.ExecuteProc<ArtStDgAmlAlertsPerStatusStaff>(SQLSERVERSPNames.ART_ST_DGAML_ALERTS_PER_STATUS_STAFF, chart1Params.ToArray());
                chart2data = _context.ExecuteProc<ArtStDgAmlAlertPerOwnerStaff>(SQLSERVERSPNames.ART_ST_DGAML_ALERT_PER_OWNER_STAFF, chart2Params.ToArray());
                chart3data = _context.ExecuteProc<ArtStDgAmlAlertsPerBranchStaff>(SQLSERVERSPNames.ART_ST_DGAML_ALERTS_PER_BRANCH_STAFF, chart3Params.ToArray());
                chart4data = _context.ExecuteProc<ArtStDgAmlAlertsPerScenarioStaff>(SQLSERVERSPNames.ART_ST_DGAML_ALERTS_PER_SCENARIO_STAFF, chart4Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = _context.ExecuteProc<ArtStDgAmlAlertsPerStatusStaff>(ORACLESPName.ART_ST_DGAML_ALERTS_PER_STATUS_STAFF, chart1Params.ToArray());
                chart2data = _context.ExecuteProc<ArtStDgAmlAlertPerOwnerStaff>(ORACLESPName.ART_ST_DGAML_ALERT_PER_OWNER_STAFF, chart2Params.ToArray());
                chart3data = _context.ExecuteProc<ArtStDgAmlAlertsPerBranchStaff>(ORACLESPName.ART_ST_DGAML_ALERTS_PER_BRANCH_STAFF, chart3Params.ToArray());
                chart4data = _context.ExecuteProc<ArtStDgAmlAlertsPerScenarioStaff>(ORACLESPName.ART_ST_DGAML_ALERTS_PER_SCENARIO_STAFF, chart4Params.ToArray());

            }
            if (dbType == DbTypes.MySql)
            {

                chart1Data = _context.ExecuteProc<ArtStDgAmlAlertsPerStatusStaff>(MYSQLSPName.ART_ST_DGAML_ALERTS_PER_STATUS_STAFF, chart1Params.ToArray());
                chart2data = _context.ExecuteProc<ArtStDgAmlAlertPerOwnerStaff>(MYSQLSPName.ART_ST_DGAML_ALERT_PER_OWNER_STAFF, chart2Params.ToArray());
                chart3data = _context.ExecuteProc<ArtStDgAmlAlertsPerBranchStaff>(MYSQLSPName.ART_ST_DGAML_ALERTS_PER_BRANCH_STAFF, chart3Params.ToArray());
                chart4data = _context.ExecuteProc<ArtStDgAmlAlertsPerScenarioStaff>(MYSQLSPName.ART_ST_DGAML_ALERTS_PER_SCENARIO_STAFF, chart4Params.ToArray());

            }

            ArrayList chartData = new()
            {
                new ChartData<ArtStDgAmlAlertsPerStatusStaff>
                {
                    ChartId = "StAlertsPerStatus",
                    Data = chart1Data.ToList(),
                    Title = "Alerts Per Status",
                    Cat = "ALERT_STATUS",
                    Val = "ALERTS_COUNT",
                    Type = ChartType.donut
                },
                new ChartData<ArtStDgAmlAlertsPerScenarioStaff>
                {
                    ChartId = "StAlertPerScenario",
                    Data = chart4data.ToList(),
                    Title = "Alerts Per Scenario",
                    Cat = "SCENARIO_NAME",
                    Val = "ALERTS_COUNT",
                    Type = ChartType.bar
                },
                new ChartData<ArtStDgAmlAlertPerOwnerStaff>
                {
                    ChartId = "StAlertPerOwner",
                    Data = chart2data.ToList(),
                    Title = "Alerts Per Owner",
                    Cat = "OWNER_QUEUE",
                    Val = "ALERTS_CNT_SUM",
                    Type = ChartType.bar
                },
                new ChartData<ArtStDgAmlAlertsPerBranchStaff>
                {
                    ChartId = "StAlertPerBranch",
                    Data = chart3data.ToList(),
                    Title = "Alerts Per Branch",
                    Cat = "BRANCH_NAME",
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

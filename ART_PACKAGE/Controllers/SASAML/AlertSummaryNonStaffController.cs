using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "AlertSummaryNonStaff")]
    public class AlertSummaryNonStaffController : Controller
    {
        private readonly SasAmlContext dbfcfkc;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public AlertSummaryNonStaffController(SasAmlContext dbfcfkc, IConfiguration config)
        {
            this.dbfcfkc = dbfcfkc;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStAmlAlertsPerStatusNonStaff> chart1Data = Enumerable.Empty<ArtStAmlAlertsPerStatusNonStaff>().AsQueryable();
            IEnumerable<ArtStAmlAlertsPerScenarioNonStaff> chart2data = Enumerable.Empty<ArtStAmlAlertsPerScenarioNonStaff>().AsQueryable();
            IEnumerable<ArtStAmlAlertPerOwnerNonStaff> chart3data = Enumerable.Empty<ArtStAmlAlertPerOwnerNonStaff>().AsQueryable();
            IEnumerable<ArtStAmlAlertsPerBranchNonStaff> chart4data = Enumerable.Empty<ArtStAmlAlertsPerBranchNonStaff>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart4Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerStatusNonStaff>(SQLSERVERSPNames.ART_ST_AML_ALERTS_PER_STATUS_NON_STAFF, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerScenarioNonStaff>(SQLSERVERSPNames.ART_ST_AML_ALERTS_PER_SCENARIO_NON_STAFF, chart2Params.ToArray());
                chart3data = dbfcfkc.ExecuteProc<ArtStAmlAlertPerOwnerNonStaff>(SQLSERVERSPNames.ART_ST_AML_ALERT_PER_OWNER_NON_STAFF, chart3Params.ToArray());
                chart4data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerBranchNonStaff>(SQLSERVERSPNames.ART_ST_AML_ALERTS_PER_BRANCH_NON_STAFF, chart4Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerStatusNonStaff>(ORACLESPName.ART_ST_AML_ALERTS_PER_STATUS_NON_STAFF, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerScenarioNonStaff>(ORACLESPName.ART_ST_AML_ALERTS_PER_SCENARIO_NON_STAFF, chart2Params.ToArray());
                chart3data = dbfcfkc.ExecuteProc<ArtStAmlAlertPerOwnerNonStaff>(ORACLESPName.ART_ST_AML_ALERT_PER_OWNER_NON_STAFF, chart3Params.ToArray());
                chart4data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerBranchNonStaff>(ORACLESPName.ART_ST_AML_ALERTS_PER_BRANCH_NON_STAFF, chart4Params.ToArray());

            }
            if (dbType == DbTypes.MySql)
            {
                chart1Data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerStatusNonStaff>(MYSQLSPName.ART_ST_AML_ALERTS_PER_STATUS_NON_STAFF, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerScenarioNonStaff>(MYSQLSPName.ART_ST_AML_ALERTS_PER_SCENARIO_NON_STAFF, chart2Params.ToArray());
                chart3data = dbfcfkc.ExecuteProc<ArtStAmlAlertPerOwnerNonStaff>(MYSQLSPName.ART_ST_AML_ALERT_PER_OWNER_NON_STAFF, chart3Params.ToArray());
                chart4data = dbfcfkc.ExecuteProc<ArtStAmlAlertsPerBranchNonStaff>(MYSQLSPName.ART_ST_AML_ALERTS_PER_BRANCH_NON_STAFF, chart4Params.ToArray());

            }

            ArrayList chartData = new()
            {
                new ChartData<ArtStAmlAlertsPerStatusNonStaff>
                {
                    ChartId = "ArtStAmlAlertsPerStatusNonStaff",
                    Data = chart1Data.ToList(),
                    Title = "Alerts Per Status",
                    Cat = "ALERT_STATUS",
                    Val = "ALERTS_COUNT",
                    Type = ChartType.donut

                },
                new ChartData<ArtStAmlAlertsPerScenarioNonStaff>
                {
                    ChartId = "ArtStAmlAlertsPerScenarioNonStaff",
                    Data = chart2data.ToList(),
                    Title = "Alerts Per Scenario",
                    Cat = "SCENARIO_NAME",
                    Val = "ALERTS_COUNT",
                    Type = ChartType.donut
                },
                new ChartData<ArtStAmlAlertPerOwnerNonStaff>
                {
                    ChartId = "ArtStAmlAlertPerOwnerNonStaff",
                    Data = chart3data.ToList(),
                    Title = "Alerts Per Owner",
                    Cat = "OWNER_USERID",
                    Val = "ALERTS_CNT_SUM",
                    Type = ChartType.donut
                }
                ,
                new ChartData<ArtStAmlAlertsPerBranchNonStaff>
                {
                    ChartId = "ArtStAmlAlertsPerBranchNonStaff",
                    Data = chart4data.ToList(),
                    Title = "Alerts Per Branch",
                    Cat = "BRANCH_NAME",
                    Val = "ALERTS_COUNT",
                    Type = ChartType.donut
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

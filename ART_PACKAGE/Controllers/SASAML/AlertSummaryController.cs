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
    ////[Authorize(Roles = "AlertSummary")]
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


            IEnumerable<ArtStAlertsPerStatus> chart1Data = Enumerable.Empty<ArtStAlertsPerStatus>().AsQueryable();
            IEnumerable<ArtStAlertPerOwner> chart2data = Enumerable.Empty<ArtStAlertPerOwner>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = dbfcfkc.ExecuteProc<ArtStAlertsPerStatus>(SQLSERVERSPNames.ART_ST_ALERTS_PER_STATUS, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStAlertPerOwner>(SQLSERVERSPNames.ART_ST_ALERT_PER_OWNER, chart2Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = dbfcfkc.ExecuteProc<ArtStAlertsPerStatus>(ORACLESPName.ART_ST_ALERTS_PER_STATUS, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStAlertPerOwner>(ORACLESPName.ART_ST_ALERT_PER_OWNER, chart2Params.ToArray());

            }


            ArrayList chartData = new()
            {
                new ChartData<ArtStAlertsPerStatus>
                {
                    ChartId = "StAlertsPerStatus",
                    Data = chart1Data.ToList(),
                    Title = "Alerts Per Status",
                    Cat = "ALERT_STATUS",
                    Val = "ALERTS_COUNT"

                },
                new ChartData<ArtStAlertPerOwner>
                {
                    ChartId = "StAlertPerOwner",
                    Data = chart2data.ToList(),
                    Title = "Alerts Per Owner",
                    Cat = "OWNER_USERID",
                    Val = "ALERTS_CNT_SUM"
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

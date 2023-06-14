using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
//using MimeKit;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Oracle.ManagedDataAccess.Client;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using System.Collections;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using System.Globalization;

namespace ART_PACKAGE.Controllers
{
    public class AlertSummaryController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public AlertSummaryController(AuthContext dbfcfkc, IMemoryCache cache, IConfiguration config)
        {
            this.dbfcfkc = dbfcfkc;
            _cache = cache;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStAlertsPerStatus> chart1Data = Enumerable.Empty<ArtStAlertsPerStatus>().AsQueryable();
            IEnumerable<ArtStAlertPerOwner> chart2data = Enumerable.Empty<ArtStAlertPerOwner>().AsQueryable();


            var chart1Params = para.procFilters.MapToParameters(dbType);
            var chart2Params = para.procFilters.MapToParameters(dbType);
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


            var chartData = new ArrayList {
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

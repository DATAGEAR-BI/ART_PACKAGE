﻿using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;

namespace ART_PACKAGE.Controllers
{
    public class DGAMLAlertSummaryController : Controller
    {
        private readonly AuthContext _context;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public DGAMLAlertSummaryController(AuthContext _context, IConfiguration config)
        {
            this._context = _context;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStDgAmlAlertsPerStatus> chart1Data = Enumerable.Empty<ArtStDgAmlAlertsPerStatus>().AsQueryable();
            IEnumerable<ArtStDgAmlAlertPerOwner> chart2data = Enumerable.Empty<ArtStDgAmlAlertPerOwner>().AsQueryable();


            var chart1Params = para.procFilters.MapToParameters(dbType);
            var chart2Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = _context.ExecuteProc<ArtStDgAmlAlertsPerStatus>(SQLSERVERSPNames.ART_ST_DGAML_ALERTS_PER_STATUS, chart1Params.ToArray());
                chart2data = _context.ExecuteProc<ArtStDgAmlAlertPerOwner>(SQLSERVERSPNames.ART_ST_DGAML_ALERT_PER_OWNER, chart2Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                //chart1Data = _context.ExecuteProc<ArtStAlertsPerStatus>(ORACLESPName.ART_ST_ALERTS_PER_STATUS, chart1Params.ToArray());
                //chart2data = _context.ExecuteProc<ArtStAlertPerOwner>(ORACLESPName.ART_ST_ALERT_PER_OWNER, chart2Params.ToArray());

            }


            var chartData = new ArrayList {
                new ChartData<ArtStDgAmlAlertsPerStatus>
                {
                    ChartId = "StAlertsPerStatus",
                    Data = chart1Data.ToList(),
                    Title = "Alerts Per Status",
                    Cat = "ALERT_STATUS",
                    Val = "ALERTS_COUNT"

                },
                new ChartData<ArtStDgAmlAlertPerOwner>
                {
                    ChartId = "StAlertPerOwner",
                    Data = chart2data.ToList(),
                    Title = "Alerts Per Owner",
                    Cat = "OWNER_QUEUE",
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
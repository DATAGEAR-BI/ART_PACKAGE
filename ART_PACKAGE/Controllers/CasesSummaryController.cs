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
using OracleInternal.SqlAndPlsqlParser.LocalParsing;

namespace ART_PACKAGE.Controllers
{
    public class CasesSummaryController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public CasesSummaryController(AuthContext dbfcfkc, IMemoryCache cache, IConfiguration config)
        {
            this.dbfcfkc = dbfcfkc;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStCasesPerStatus> chart1Data = Enumerable.Empty<ArtStCasesPerStatus>().AsQueryable();
            IEnumerable<ArtStCasesPerCategory> chart2data = Enumerable.Empty<ArtStCasesPerCategory>().AsQueryable();
            IEnumerable<ArtStCasesPerSubcat> chart3Data = Enumerable.Empty<ArtStCasesPerSubcat>().AsQueryable();
            IEnumerable<ArtStCasesPerPriority> chart4Data = Enumerable.Empty<ArtStCasesPerPriority>().AsQueryable();


            var chart1Params = para.procFilters.MapToParameters(dbType);
            var chart2Params = para.procFilters.MapToParameters(dbType);
            var chart3Params = para.procFilters.MapToParameters(dbType);
            var chart4Params = para.procFilters.MapToParameters(dbType);

            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = dbfcfkc.ExecuteProc<ArtStCasesPerStatus>(SQLSERVERSPNames.ART_ST_CASES_PER_STATUS, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStCasesPerCategory>(SQLSERVERSPNames.ART_ST_CASES_PER_CATEGORY, chart2Params.ToArray());
                chart3Data = dbfcfkc.ExecuteProc<ArtStCasesPerSubcat>(SQLSERVERSPNames.ART_ST_CASES_PER_SUBCAT, chart3Params.ToArray());
                chart4Data = dbfcfkc.ExecuteProc<ArtStCasesPerPriority>(SQLSERVERSPNames.ART_ST_CASES_PER_PRIORITY, chart4Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = dbfcfkc.ExecuteProc<ArtStCasesPerStatus>(ORACLESPName.ART_ST_CASES_PER_STATUS, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStCasesPerCategory>(ORACLESPName.ART_ST_CASES_PER_CATEGORY, chart2Params.ToArray());
                chart3Data = dbfcfkc.ExecuteProc<ArtStCasesPerSubcat>(ORACLESPName.ART_ST_CASES_PER_SUBCAT, chart3Params.ToArray());
                chart4Data = dbfcfkc.ExecuteProc<ArtStCasesPerPriority>(ORACLESPName.ART_ST_CASES_PER_PRIORITY, chart4Params.ToArray());

            }

            var chartData = new ArrayList {
                new ChartData<ArtStCasesPerStatus>
                {
                    ChartId = "StCasesPerStatus",
                    Data = chart1Data.ToList(),
                    Title = "Cases Per Status",
                    Cat = "CASE_STATUS",
                    Val = "NUMBER_OF_CASES"

                },
                new ChartData<ArtStCasesPerCategory>
                {
                    ChartId = "StCasesPerCategory",
                    Data = chart2data.ToList(),
                    Title = "Cases Per Category",
                    Cat = "CASE_CATEGORY",
                    Val = "NUMBER_OF_CASES"
                },
                new ChartData<ArtStCasesPerSubcat>
                {
                    ChartId = "StCasesPerSubCategory",
                    Data = chart3Data.ToList(),
                    Title = "Cases Per Sub Category",
                    Cat = "CASE_SUBCATEGORY",
                    Val = "NUMBER_OF_CASES"
                },
                new ChartData<ArtStCasesPerPriority>
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

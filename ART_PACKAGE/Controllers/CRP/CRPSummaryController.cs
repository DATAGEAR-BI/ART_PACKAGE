using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.CRP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections;

namespace ART_PACKAGE.Controllers.CRP
{
    public class CRPSummaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        private readonly CRPContext _crp;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;
        private readonly string dbType;
        public CRPSummaryController(CRPContext crp, IMemoryCache cache, IConfiguration config)
        {
            _crp = crp;
            _cache = cache;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {

            IEnumerable<ART_ST_CRP_PER_RISK> chart1Data = Enumerable.Empty<ART_ST_CRP_PER_RISK>().AsQueryable();
            IEnumerable<ART_ST_CRP_CASES_PER_STATUS> chart2data = Enumerable.Empty<ART_ST_CRP_CASES_PER_STATUS>().AsQueryable();
            IEnumerable<ART_ST_CRP_CUST_PER_PROP_RISK> chart3data = Enumerable.Empty<ART_ST_CRP_CUST_PER_PROP_RISK>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = _crp.ExecuteProc<ART_ST_CRP_PER_RISK>(SQLSERVERSPNames.ART_ST_CRP_CUST_PER_RISK, chart1Params.ToArray());
                chart2data = _crp.ExecuteProc<ART_ST_CRP_CASES_PER_STATUS>(SQLSERVERSPNames.ART_ST_CRP_CASES_PER_STATUS, chart2Params.ToArray());
                chart3data = _crp.ExecuteProc<ART_ST_CRP_CUST_PER_PROP_RISK>(SQLSERVERSPNames.ART_ST_CRP_CUST_PER_PROP_RISK, chart3Params.ToArray());
            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = _crp.ExecuteProc<ART_ST_CRP_PER_RISK>(ORACLESPName.ART_ST_CRP_CUST_PER_RISK, chart1Params.ToArray());
                chart2data = _crp.ExecuteProc<ART_ST_CRP_CASES_PER_STATUS>(ORACLESPName.ART_ST_CRP_CASES_PER_STATUS, chart2Params.ToArray());
                chart3data = _crp.ExecuteProc<ART_ST_CRP_CUST_PER_PROP_RISK>(ORACLESPName.ART_ST_CRP_CUST_PER_PROP_RISK, chart3Params.ToArray());
            }
            if (dbType == DbTypes.MySql) 
            {
                chart1Data = _crp.ExecuteProc<ART_ST_CRP_PER_RISK>(MYSQLSPName.ART_ST_CRP_CUST_PER_RISK, chart1Params.ToArray());
                chart2data = _crp.ExecuteProc<ART_ST_CRP_CASES_PER_STATUS>(MYSQLSPName.ART_ST_CRP_CASES_PER_STATUS, chart2Params.ToArray());
                chart3data = _crp.ExecuteProc<ART_ST_CRP_CUST_PER_PROP_RISK>(MYSQLSPName.ART_ST_CRP_CUST_PER_PROP_RISK, chart3Params.ToArray());
            }
            ArrayList chartData = new()
            {
                new ChartData<ART_ST_CRP_CASES_PER_STATUS>
                {
                    ChartId = "ART_ST_CRP_CASES_PER_STATUS",
                    Data = chart2data.ToList(),
                    Title = "CRP CASES PER STATUS",
                    Cat = "CASE_STATUS",
                    Val = "TOTAL_NUMBER_OF_CASES",

                    Type=ChartType.bar
                },
                new ChartData<ART_ST_CRP_CUST_PER_PROP_RISK>
                {
                    ChartId = "ART_ST_CRP_CUST_PER_PROP_RISK",
                    Data =chart3data.ToList(),
                    Title = "CUSTOMERS PER PROP RISK CLASSIFICATION",
                    Cat = "PROP_RISK_CLASSIFICATION",
                    Val = "NUMBER_OF_CUSTOMERS",
                    Type = ChartType.donut

                },
                new ChartData<ART_ST_CRP_PER_RISK>
                {
                    ChartId = "ART_ST_CRP_PER_RISK",
                    Data = chart1Data.ToList(),
                    Title = "CUSTOMERS PER RISK CLASSIFICATION",
                    Cat = "RISK_CLASSIFICATION",
                    Val = "NUMBER_OF_CUSTOMERS",
                    Type = ChartType.donut
                }
            };

            /*if (dbType is DbTypes.Oracle or DbTypes.SqlServer)
            {
                _ = chartData.Add(new ChartData<ART_ST_CRP_PER_RISK>
                {
                    ChartId = "ART_ST_CRP_PER_RISK",
                    Data = chart1Data.ToList(),
                    Title = "CUSTOMERS PER RISK CLASSIFICATION",
                    Cat = "RISK_CLASSIFICATION",
                    Val = "NUMBER_OF_CUSTOMERS",
                    Type = ChartType.donut
                });
            }*/



            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(chartData, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                }),

            };
        }
    }
}

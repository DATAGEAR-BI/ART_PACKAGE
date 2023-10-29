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
            IEnumerable<ART_ST_CRP_PER_STATUS> chart2data = Enumerable.Empty<ART_ST_CRP_PER_STATUS>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = _crp.ExecuteProc<ART_ST_CRP_PER_RISK>(SQLSERVERSPNames.ART_ST_CRP_PER_RISK, chart1Params.ToArray());
                chart2data = _crp.ExecuteProc<ART_ST_CRP_PER_STATUS>(SQLSERVERSPNames.ART_ST_CRP_PER_STATUS, chart2Params.ToArray());
            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = _crp.ExecuteProc<ART_ST_CRP_PER_RISK>(ORACLESPName.ART_ST_CRP_PER_RISK, chart1Params.ToArray());
                chart2data = _crp.ExecuteProc<ART_ST_CRP_PER_STATUS>(ORACLESPName.ART_ST_CRP_PER_STATUS, chart2Params.ToArray());

            }

            ArrayList chartData = new()
            {
                new ChartData<ART_ST_CRP_PER_RISK>
                {
                    ChartId = "ART_ST_CRP_PER_RISK",
                    Data = chart1Data.ToList(),
                    Title = "Number OF CRP Cases Per Risk Classification",
                    Cat = "risk_classification",
                    Val = "Number_Of_Cases"

                },
                new ChartData<ART_ST_CRP_PER_STATUS>
                {
                    ChartId = "ART_ST_CRP_PER_STATUS",
                    Data = chart2data.ToList(),
                    Title = "Number OF CRP Cases Per Status",
                    Cat = "Case_Status",
                    Val = "Number_Of_Cases"
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
    }
}

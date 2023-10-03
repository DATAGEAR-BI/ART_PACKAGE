//using MimeKit;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections;

namespace ART_PACKAGE.Controllers.SASAML
{

    ////[Authorize(Roles = "RiskSummary")]
    public class RiskSummaryController : Controller
    {
        private readonly SasAmlContext dbfcfcore;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;
        private readonly string dbType;
        public RiskSummaryController(SasAmlContext dbfcfcore, IMemoryCache cache, IConfiguration config)
        {
            this.dbfcfcore = dbfcfcore;
            _cache = cache;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {

            IEnumerable<ArtStAmlRiskClass> chart1Data = Enumerable.Empty<ArtStAmlRiskClass>().AsQueryable();
            IEnumerable<ArtStAmlPropRiskClass> chart2data = Enumerable.Empty<ArtStAmlPropRiskClass>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = dbfcfcore.ExecuteProc<ArtStAmlRiskClass>(SQLSERVERSPNames.ART_ST_AML_RISK_CLASS, chart1Params.ToArray());
                chart2data = dbfcfcore.ExecuteProc<ArtStAmlPropRiskClass>(SQLSERVERSPNames.ART_ST_AML_PROP_RISK_CLASS, chart2Params.ToArray());
            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = dbfcfcore.ExecuteProc<ArtStAmlRiskClass>(ORACLESPName.ART_ST_AML_RISK_CLASS, chart1Params.ToArray());
                chart2data = dbfcfcore.ExecuteProc<ArtStAmlPropRiskClass>(ORACLESPName.ART_ST_AML_PROP_RISK_CLASS, chart2Params.ToArray());

            }

            ArrayList chartData = new()
            {
                new ChartData<ArtStAmlRiskClass>
                {
                    ChartId = "StRiskClassSummary",
                    Data = chart1Data.ToList(),
                    Title = "Number OF Customers Per Risk Classification",
                    Cat = "RISK_CLASSIFICATION",
                    Val = "NUMBER_OF_CUSTOMERS"

                },
                new ChartData<ArtStAmlPropRiskClass>
                {
                    ChartId = "StPropRiskClassSummary",
                    Data = chart2data.ToList(),
                    Title = "Number OF Customers Per Proposed Risk Classification",
                    Cat = "PROPOSED_RISK_CLASS",
                    Val = "NUMBER_OF_CUSTOMERS"
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

        //public ContentResult RiskClassSummary()
        //{
        //    var result = dbfcfcore.AmlRiskClassSummaries.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        //public ContentResult PropRiskClassSummary()
        //{
        //    var result = dbfcfcore.AmlPropRiskClassSummaries.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}

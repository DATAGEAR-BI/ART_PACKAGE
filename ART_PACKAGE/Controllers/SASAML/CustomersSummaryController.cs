using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Linq.Dynamic.Core;
using Data.Services.Grid;
using ART_PACKAGE.Areas.Identity.Data;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "CustomersSummary")]
    public class CustomersSummaryController : Controller
    {

        private readonly SasAmlContext dbfcfcore;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public CustomersSummaryController(SasAmlContext dbfcfcore, IMemoryCache cache, IConfiguration config)
        {
            this.dbfcfcore = dbfcfcore;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStCustPerType> chart1Data = Enumerable.Empty<ArtStCustPerType>().AsQueryable();
            IEnumerable<ArtStCustPerRisk> chart2data = Enumerable.Empty<ArtStCustPerRisk>().AsQueryable();
            IEnumerable<ArtStCustPerBranch> chart3Data = Enumerable.Empty<ArtStCustPerBranch>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters(dbType);

            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = dbfcfcore.ExecuteProc<ArtStCustPerType>(SQLSERVERSPNames.ART_ST_CUST_PER_TYPE, chart1Params.ToArray());
                chart2data = dbfcfcore.ExecuteProc<ArtStCustPerRisk>(SQLSERVERSPNames.ART_ST_CUST_PER_RISK, chart2Params.ToArray());
                chart3Data = dbfcfcore.ExecuteProc<ArtStCustPerBranch>(SQLSERVERSPNames.ART_ST_CUST_PER_BRANCH, chart3Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = dbfcfcore.ExecuteProc<ArtStCustPerType>(ORACLESPName.ART_ST_CUST_PER_TYPE, chart1Params.ToArray());
                chart2data = dbfcfcore.ExecuteProc<ArtStCustPerRisk>(ORACLESPName.ART_ST_CUST_PER_RISK, chart2Params.ToArray());
                chart3Data = dbfcfcore.ExecuteProc<ArtStCustPerBranch>(ORACLESPName.ART_ST_CUST_PER_BRANCH, chart3Params.ToArray());

            }

            ArrayList chartData = new()
            {
                new ChartData<ArtStCustPerType>
                {
                    ChartId = "StCustomerPerType",
                    Data = chart1Data.ToList(),
                    Title = "Customer Per Type",
                    Cat = "CUSTOMER_TYPE",
                    Val = "NUMBER_OF_CUSTOMERS",
                    Type = ChartType.donut
                },
                new ChartData<ArtStCustPerRisk>
                {
                    ChartId = "StCustomerPerRiskClass",
                    Data = chart2data.ToList(),
                    Title = "Customer Per Risk Classification",
                    Cat = "RISK_CLASSIFICATION",
                    Val = "NUMBER_OF_CUSTOMERS",
                    Type = ChartType.donut
                },
                new ChartData<ArtStCustPerBranch>
                {
                    ChartId = "StCustomerPerBranch",
                    Data = chart3Data.OrderBy(x=>x.NUMBER_OF_CUSTOMERS).ToList(),
                    Title = "Customer Per Branch",
                    Cat = "BRANCH_NAME",
                    Val = "NUMBER_OF_CUSTOMERS",
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

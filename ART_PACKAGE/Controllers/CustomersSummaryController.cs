using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Microsoft.Extensions.Caching.Memory;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using System.Collections;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;
using Data.Constants.db;
using Data.Constants.StoredProcs;

namespace ART_PACKAGE.Controllers
{
    public class CustomersSummaryController : Controller
    {

        private readonly AuthContext dbfcfcore;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public CustomersSummaryController(AuthContext dbfcfcore, IMemoryCache cache, IConfiguration config)
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

            var chart1Params = para.procFilters.MapToParameters(dbType);
            var chart2Params = para.procFilters.MapToParameters(dbType);
            var chart3Params = para.procFilters.MapToParameters(dbType);

            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = dbfcfcore.ExecuteProc<ArtStCustPerType>(SQLSERVERSPNames.ART_ST_CUST_PER_TYPE, chart1Params.ToArray());
                chart2data = dbfcfcore.ExecuteProc<ArtStCustPerRisk>(SQLSERVERSPNames.ART_ST_CUST_PER_RISK, chart2Params.ToArray());
                chart3Data = dbfcfcore.ExecuteProc<ArtStCustPerBranch>(SQLSERVERSPNames.ART_ST_CUST_PER_BRANCH, chart3Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = dbfcfcore.ExecuteProc<ArtStCustPerType>(ORACLESPName.ART_ST_CASES_PER_STATUS, chart1Params.ToArray());
                chart2data = dbfcfcore.ExecuteProc<ArtStCustPerRisk>(ORACLESPName.ART_ST_CASES_PER_CATEGORY, chart2Params.ToArray());
                chart3Data = dbfcfcore.ExecuteProc<ArtStCustPerBranch>(ORACLESPName.ART_ST_CASES_PER_SUBCAT, chart3Params.ToArray());

            }

            var chartData = new ArrayList {
                new ChartData<ArtStCustPerType>
                {
                    ChartId = "StCustomerPerType",
                    Data = chart1Data.ToList(),
                    Title = "Customer Per Type",
                    Cat = "CUSTOMER_TYPE",
                    Val = "NUMBER_OF_CUSTOMERS"
                },
                new ChartData<ArtStCustPerRisk>
                {
                    ChartId = "StCustomerPerRiskClass",
                    Data = chart2data.ToList(),
                    Title = "Customer Per Risk Classification",
                    Cat = "RISK_CLASSIFICATION",
                    Val = "NUMBER_OF_CUSTOMERS"
                },
                new ChartData<ArtStCustPerBranch>
                {
                    ChartId = "StCustomerPerBranch",
                    Data = chart3Data.OrderBy(x=>x.NUMBER_OF_CUSTOMERS).ToList(),
                    Title = "Customer Per Branch",
                    Cat = "BRANCH_NAME",
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

        public IActionResult Index()
        {
            return View();
        }
    }
}

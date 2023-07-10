using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections;

namespace ART_PACKAGE.Controllers
{
    public class DGAMLExternalCustomerSummaryController : Controller
    {

        private readonly AuthContext _context;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public DGAMLExternalCustomerSummaryController(AuthContext _context, IMemoryCache cache, IConfiguration config)
        {
            this._context = _context;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStDgAmlExternalCustomerPerBranch> chart1Data = Enumerable.Empty<ArtStDgAmlExternalCustomerPerBranch>().AsQueryable();
            IEnumerable<ArtStDgAmlExternalCustomerPerType> chart3Data = Enumerable.Empty<ArtStDgAmlExternalCustomerPerType>().AsQueryable();

            var chart1Params = para.procFilters.MapToParameters(dbType);
            var chart3Params = para.procFilters.MapToParameters(dbType);

            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = _context.ExecuteProc<ArtStDgAmlExternalCustomerPerBranch>(SQLSERVERSPNames.ART_ST_DGAML_EXTERNAL_CUSTOMER_PER_BRANCH, chart1Params.ToArray());
                chart3Data = _context.ExecuteProc<ArtStDgAmlExternalCustomerPerType>(SQLSERVERSPNames.ART_ST_DGAML_EXTERNAL_CUSTOMER_PER_TYPE, chart3Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                //chart1Data = _context.ExecuteProc<ArtStCustPerType>(ORACLESPName.ART_ST_CASES_PER_STATUS, chart1Params.ToArray());
                //chart2data = _context.ExecuteProc<ArtStCustPerRisk>(ORACLESPName.ART_ST_CASES_PER_CATEGORY, chart2Params.ToArray());
                //chart3Data = _context.ExecuteProc<ArtStCustPerBranch>(ORACLESPName.ART_ST_CASES_PER_SUBCAT, chart3Params.ToArray());

            }

            var chartData = new ArrayList {
                new ChartData<ArtStDgAmlExternalCustomerPerType>
                {
                    ChartId = "StCustomerPerType",
                    Data = chart3Data.ToList(),
                    Title = "External Customer Per Type",
                    Cat = "CUSTOMER_TYPE",
                    Val = "NUMBER_OF_CUSTOMERS"
                },

                new ChartData<ArtStDgAmlExternalCustomerPerBranch>
                {
                    ChartId = "StCustomerPerBranch",
                    Data = chart1Data.OrderBy(x=>x.NUMBER_OF_CUSTOMERS).ToList(),
                    Title = "External Customer Per Branch",
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

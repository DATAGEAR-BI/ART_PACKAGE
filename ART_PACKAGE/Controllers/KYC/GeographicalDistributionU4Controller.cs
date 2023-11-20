using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.KYC;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;

namespace ART_PACKAGE.Controllers.KYC
{
    public class GeographicalDistributionU4Controller : Controller
    {
        private readonly KYCContext dbfcfkc;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public GeographicalDistributionU4Controller(KYCContext dbfcfkc, IConfiguration config)
        {
            this.dbfcfkc = dbfcfkc;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<StCustomersPerCityU4> chart1Data = Enumerable.Empty<StCustomersPerCityU4>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = dbfcfkc.ExecuteProc<StCustomersPerCityU4>(SQLSERVERSPNames.ART_ST_CUSTOMERS_PER_CITY_U4, chart1Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = dbfcfkc.ExecuteProc<StCustomersPerCityU4>(ORACLESPName.ART_ST_CUSTOMERS_PER_CITY_U4, chart1Params.ToArray());
            }


            ArrayList chartData = new()
            {
                new ChartData<StCustomersPerCityU4>
                {
                    ChartId = "StCustomersPerCityU4",
                    Data = chart1Data.ToList(),
                    Title = "Geographical Distribution U4",
                    Cat = "city_name",
                    Val = "number_of_cutomers"

                },
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

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
    public class CustomersRenewalPerMonthU1Controller : Controller
    {
        private readonly KYCContext dbfcfkc;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public CustomersRenewalPerMonthU1Controller(KYCContext dbfcfkc, IConfiguration config)
        {
            this.dbfcfkc = dbfcfkc;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<StCustomersRenewalPerMonthU1> chart1Data = Enumerable.Empty<StCustomersRenewalPerMonthU1>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = dbfcfkc.ExecuteProc<StCustomersRenewalPerMonthU1>(SQLSERVERSPNames.ART_ST_CUSTOMERS_RENEWAL_PER_MONTH_U1, chart1Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = dbfcfkc.ExecuteProc<StCustomersRenewalPerMonthU1>(ORACLESPName.ART_ST_CUSTOMERS_RENEWAL_PER_MONTH_U1, chart1Params.ToArray());
            }
            List<Dictionary<string, object>> chartDictList = new();
            foreach (IGrouping<string?, StCustomersRenewalPerMonthU1>? chartResult in chart1Data.GroupBy(x => x.party_type).ToList())
            {
                Dictionary<string, object> result = new()
                {
                    { "PARTY_TYPE", chartResult.Key }
                };
                foreach (StCustomersRenewalPerMonthU1? list in chartResult)
                {
                    result.Add(list.month_year, list.NUMBER_OF_CUSTOMERS);
                }
                chartDictList.Add(result);
            };

            ArrayList chartData = new()
            {
                new ChartData<Dictionary<string,object>>
                {
                    ChartId = "StCustomersRenewalPerMonthU1",
                    Data = chartDictList,
                    Title = "Customers renewal per month",
                    Cat = "PARTY_TYPE",
                    Val = "month_year"
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

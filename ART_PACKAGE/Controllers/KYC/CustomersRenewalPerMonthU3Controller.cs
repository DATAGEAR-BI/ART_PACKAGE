﻿using ART_PACKAGE.Extentions.DbContextExtentions;
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
    public class CustomersRenewalPerMonthU3Controller : Controller
    {
        private readonly KYCContext dbfcfkc;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public CustomersRenewalPerMonthU3Controller(KYCContext dbfcfkc, IConfiguration config)
        {
            this.dbfcfkc = dbfcfkc;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<StCustomersRenewalPerMonthU3> chart1Data = Enumerable.Empty<StCustomersRenewalPerMonthU3>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = dbfcfkc.ExecuteProc<StCustomersRenewalPerMonthU3>(SQLSERVERSPNames.ART_ST_CUSTOMERS_RENEWAL_PER_MONTH_U3, chart1Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = dbfcfkc.ExecuteProc<StCustomersRenewalPerMonthU3>(ORACLESPName.ART_ST_CUSTOMERS_RENEWAL_PER_MONTH_U3, chart1Params.ToArray());
            }
            List<Dictionary<string, object>> chartDictList = new();
            foreach (IGrouping<string?, StCustomersRenewalPerMonthU3>? chartResult in chart1Data.GroupBy(x => x.party_type).ToList())
            {
                Dictionary<string, object> result = new()
                {
                    { "PARTY_TYPE", chartResult.Key }
                };
                foreach (StCustomersRenewalPerMonthU3? list in chartResult)
                {
                    result.Add(list.month_year, list.NUMBER_OF_CUSTOMERS);
                }
                chartDictList.Add(result);
            };

            ArrayList chartData = new()
            {
                new ChartData<Dictionary<string,object>>
                {
                    ChartId = "StCustomersRenewalPerMonthU3",
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
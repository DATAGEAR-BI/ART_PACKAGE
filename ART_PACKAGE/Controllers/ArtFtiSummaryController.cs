using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.FTI;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers
{
    [Authorize(Roles = "ArtFtiSummary")]

    public class ArtFtiSummaryController : Controller
    {
        private readonly FTIContext fti;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public ArtFtiSummaryController(FTIContext fti, IMemoryCache cache, IConfiguration config)
        {
            this.fti = fti;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }
        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStCasesPerDate> chartCasesPerDate = Enumerable.Empty<ArtStCasesPerDate>().AsQueryable();
            IEnumerable<ArtStCasesYearToYear> chartCasesYearToYearData = Enumerable.Empty<ArtStCasesYearToYear>().AsQueryable();
            IEnumerable<ArtStCasesPerType> chartCasesPerTypeData = Enumerable.Empty<ArtStCasesPerType>().AsQueryable();
            IEnumerable<ArtStCasesPerStatus> chartCasesPerStatusData = Enumerable.Empty<ArtStCasesPerStatus>().AsQueryable();
            IEnumerable<ArtStCasesPerProduct> chartCasesPerProductData = Enumerable.Empty<ArtStCasesPerProduct>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart0Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart4Params = para.procFilters.MapToParameters(dbType);

            if (dbType == DbTypes.SqlServer)
            {

                chartCasesPerDate = fti.ExecuteProc<ArtStCasesPerDate>(SQLSERVERSPNames.ART_ST_CASES_PER_DATE, chart0Params.ToArray());


                chartCasesYearToYearData = fti.ExecuteProc<ArtStCasesYearToYear>(SQLSERVERSPNames.ART_ST_CASES_YEAR_TO_YEAR, chart1Params.ToArray());
                chartCasesPerTypeData = fti.ExecuteProc<ArtStCasesPerType>(SQLSERVERSPNames.ART_ST_CASES_PER_TYPE, chart2Params.ToArray());
                chartCasesPerStatusData = fti.ExecuteProc<ArtStCasesPerStatus>(SQLSERVERSPNames.ART_ST_CASES_PER_STATUS, chart3Params.ToArray());
                chartCasesPerProductData = fti.ExecuteProc<ArtStCasesPerProduct>(SQLSERVERSPNames.ART_ST_CASES_PER_PRODUCT, chart4Params.ToArray());
            }

            if (dbType == DbTypes.Oracle)
            {
                chartCasesPerDate = fti.ExecuteProc<ArtStCasesPerDate>(ORACLESPName.ART_ST_CASES_PER_DATE, chart0Params.ToArray());

                chartCasesYearToYearData = fti.ExecuteProc<ArtStCasesYearToYear>(ORACLESPName.ART_ST_CASES_YEAR_TO_YEAR, chart1Params.ToArray());
                chartCasesPerTypeData = fti.ExecuteProc<ArtStCasesPerType>(ORACLESPName.ART_ST_CASES_PER_TYPE, chart2Params.ToArray());
                chartCasesPerStatusData = fti.ExecuteProc<ArtStCasesPerStatus>(ORACLESPName.ART_ST_CASES_PER_STATUS, chart3Params.ToArray());
                chartCasesPerProductData = fti.ExecuteProc<ArtStCasesPerProduct>(ORACLESPName.ART_ST_CASES_PER_PRODUCT, chart4Params.ToArray());
            }
            var dateData = chartCasesPerDate.ToList().GroupBy(x => x.Year).Select(x => new
            {
                year = x.Key.ToString(),
                value = x.Sum(x => x.NUMBER_OF_CASES),
                monthData = x.GroupBy(m => m.Month).Select(m => new
                {
                    Month = m.Key.ToString(),
                    value = m.Sum(x => x.NUMBER_OF_CASES)
                })
            });
            List<object> chartData = new()
            {
                new ChartData<ArtStCasesYearToYear>
                {
                    ChartId = "StCasesYearToYear",
                    Data = chartCasesYearToYearData.ToList(),
                    Title = "Cases Per Year",
                    Cat = "Month",
                    Val = "NUMBER_OF_CASES"

                },
                new ChartData<ArtStCasesPerProduct>
                {
                    ChartId = "StCasesPerProduct",
                    Data = chartCasesPerProductData.ToList(),
                    Title = "Cases Per Product",
                    Cat = "PRODUCT",
                    Val = "NUMBER_OF_CASES"

                },
                new ChartData<ArtStCasesPerStatus>
                {
                    ChartId = "StCasesPerStatus",
                    Data = chartCasesPerStatusData.ToList(),
                    Title = "Cases Per Status",
                    Cat = "CASE_STATUS",
                    Val = "NUMBER_OF_CASES"

                },
                new ChartData<ArtStCasesPerType>
                {
                    ChartId = "StCasesPerType",
                    Data = chartCasesPerTypeData.ToList(),
                    Title = "Volume Distribution",
                    Cat = "CASE_TYPE",
                    Val = "NUMBER_OF_CASES"
                },
                new{//"date", "year", "value", "month", "value", "monthData", "Cases Per Year & Month"
                data=dateData,
                divId="StCasesPerDate",
                cat="year",
                val="value",
                subcat="month",
                subval="value",
                subListKey = "monthData",
                ctitle = "Cases Per Year & Month"
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

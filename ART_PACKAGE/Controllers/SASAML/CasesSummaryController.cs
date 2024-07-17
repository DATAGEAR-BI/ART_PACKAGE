using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections;
using ART_PACKAGE.Areas.Identity.Data;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "CasesSummary")]
    public class CasesSummaryController : Controller
    {
        private readonly SasAmlContext dbfcfkc;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public CasesSummaryController(SasAmlContext dbfcfkc, IMemoryCache cache, IConfiguration config)
        {
            this.dbfcfkc = dbfcfkc;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            //IEnumerable<ArtStCasesPerStatus> chart1Data = Enumerable.Empty<ArtStCasesPerStatus>().AsQueryable();
            IEnumerable<ArtStCasesPerCategory> chart2data = Enumerable.Empty<ArtStCasesPerCategory>().AsQueryable();
            IEnumerable<ArtStCasesPerSubcat> chart3Data = Enumerable.Empty<ArtStCasesPerSubcat>().AsQueryable();
            IEnumerable<ArtStCasesPerPriority> chart4Data = Enumerable.Empty<ArtStCasesPerPriority>().AsQueryable();
            IEnumerable<ArtStCasesPerBranch> chart5Data = Enumerable.Empty<ArtStCasesPerBranch>().AsQueryable();
            IEnumerable<ArtStCasesPerDate> chart6Data = Enumerable.Empty<ArtStCasesPerDate>().AsQueryable();


            //IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart4Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart5Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart6Params = para.procFilters.MapToParameters(dbType);

            if (dbType == DbTypes.SqlServer)
            {

                //chart1Data = dbfcfkc.ExecuteProc<ArtStCasesPerStatus>(SQLSERVERSPNames.ART_ST_CASES_PER_STATUS, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStCasesPerCategory>(SQLSERVERSPNames.ART_ST_CASES_PER_CATEGORY, chart2Params.ToArray());
                chart3Data = dbfcfkc.ExecuteProc<ArtStCasesPerSubcat>(SQLSERVERSPNames.ART_ST_CASES_PER_SUBCAT, chart3Params.ToArray());
                chart4Data = dbfcfkc.ExecuteProc<ArtStCasesPerPriority>(SQLSERVERSPNames.ART_ST_CASES_PER_PRIORITY, chart4Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                //chart1Data = dbfcfkc.ExecuteProc<ArtStCasesPerStatus>(ORACLESPName.ART_ST_CASES_PER_STATUS, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStCasesPerCategory>(ORACLESPName.ART_ST_CASES_PER_CATEGORY, chart2Params.ToArray());
                chart3Data = dbfcfkc.ExecuteProc<ArtStCasesPerSubcat>(ORACLESPName.ART_ST_CASES_PER_SUBCAT, chart3Params.ToArray());
                chart4Data = dbfcfkc.ExecuteProc<ArtStCasesPerPriority>(ORACLESPName.ART_ST_CASES_PER_PRIORITY, chart4Params.ToArray());
                chart5Data = dbfcfkc.ExecuteProc<ArtStCasesPerBranch>(ORACLESPName.ART_ST_CASES_PER_BRANCH, chart5Params.ToArray());
                chart6Data = dbfcfkc.ExecuteProc<ArtStCasesPerDate>(ORACLESPName.ART_ST_CASES_STATUS_PER_MONTH, chart6Params.ToArray());

            }
            if (dbType == DbTypes.MySql)
            {
                //chart1Data = dbfcfkc.ExecuteProc<ArtStCasesPerStatus>(MYSQLSPName.ART_ST_CASES_PER_STATUS, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStCasesPerCategory>(MYSQLSPName.ART_ST_CASES_PER_CATEGORY, chart2Params.ToArray());
                chart3Data = dbfcfkc.ExecuteProc<ArtStCasesPerSubcat>(MYSQLSPName.ART_ST_CASES_PER_SUBCAT, chart3Params.ToArray());
                chart4Data = dbfcfkc.ExecuteProc<ArtStCasesPerPriority>(MYSQLSPName.ART_ST_CASES_PER_PRIORITY, chart4Params.ToArray());
            }
            ArrayList chartData = new()
            {
                //new ChartData<ArtStCasesPerStatus>
                //{
                //    ChartId = "StCasesPerStatus",
                //    Data = chart1Data.ToList(),
                //    Title = "Cases Per Status",
                //    Cat = "CASE_STATUS",
                //    Val = "NUMBER_OF_CASES",
                //    Type = ChartType.donut

                //},
                new ChartData<ArtStCasesPerCategory>
                {
                    ChartId = "StCasesPerCategory",
                    Data = chart2data.ToList(),
                    Title = "Cases Per Category",
                    Cat = "CASE_CATEGORY",
                    Val = "NUMBER_OF_CASES",
                    Type = ChartType.donut
                },
                new ChartData<ArtStCasesPerSubcat>
                {
                    ChartId = "StCasesPerSubCategory",
                    Data = chart3Data.ToList(),
                    Title = "Cases Per Sub Category",
                    Cat = "CASE_SUBCATEGORY",
                    Val = "NUMBER_OF_CASES",
                    Type = ChartType.donut
                },
                new ChartData<ArtStCasesPerPriority>
                {
                    ChartId = "StCasesPerPriority",
                    Data = chart4Data.ToList(),
                    Title = "Cases Per Priority",
                    Cat = "CASE_PRIORITY",
                    Val = "NUMBER_OF_CASES",
                    Type = ChartType.donut
                },
                new ChartData<ArtStCasesPerBranch>
                {
                    ChartId = "StCasesPerBranch",
                    Data = chart5Data.ToList(),
                    Title = "Cases Per Branch",
                    Cat = "BRANCH_NAME",
                    Val = "NUMBER_OF_CASES",
                    Type = ChartType.bar
                },
                new ChartData<ArtStCasesPerDate>
                {
                    ChartId = "StCasesPerDate",
                    Data = chart6Data.ToList(),
                    Title = "Cases Per Date",
                    Cat = "MONTH",
                    Val = "NUMBER_OF_CASES",
                    Type = ChartType.curvedline
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

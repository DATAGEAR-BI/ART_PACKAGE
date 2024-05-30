using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using Data.Data.DGINTFRAUD;
using ART_PACKAGE.Extentions.DbContextExtentions;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    //////[Authorize(Roles = "EmpSummary")]
    public class EmpSummaryController : Controller
    {
        private readonly DGINTFRAUDContext dbfcfkc;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public EmpSummaryController(DGINTFRAUDContext dbfcfkc, IConfiguration config)
        {
            this.dbfcfkc = dbfcfkc;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStDgamlAllTransAmountVsDivision> chart1Data = Enumerable.Empty<ArtStDgamlAllTransAmountVsDivision>().AsQueryable();
            IEnumerable<ArtStDgamlAllTransVsCased> chart2data = Enumerable.Empty<ArtStDgamlAllTransVsCased>().AsQueryable();


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = dbfcfkc.ExecuteProc<ArtStDgamlAllTransAmountVsDivision>(SQLSERVERSPNames.ART_ST_DGAML_ALL_TRANSACTIONS_AMOUNT_VS_DIVISION, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStDgamlAllTransVsCased>(SQLSERVERSPNames.ART_ST_DGAML_ALL_TRANSACTIONS_VS_CASED, chart2Params.ToArray());

            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = dbfcfkc.ExecuteProc<ArtStDgamlAllTransAmountVsDivision>(ORACLESPName.ART_ST_DGAML_ALL_TRANSACTIONS_AMOUNT_VS_DIVISION, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStDgamlAllTransVsCased>(ORACLESPName.ART_ST_DGAML_ALL_TRANSACTIONS_VS_CASED, chart2Params.ToArray());

            }
            if (dbType == DbTypes.MySql)
            {
                chart1Data = dbfcfkc.ExecuteProc<ArtStDgamlAllTransAmountVsDivision>(MYSQLSPName.ART_ST_DGAML_ALL_TRANSACTIONS_AMOUNT_VS_DIVISION, chart1Params.ToArray());
                chart2data = dbfcfkc.ExecuteProc<ArtStDgamlAllTransVsCased>(MYSQLSPName.ART_ST_DGAML_ALL_TRANSACTIONS_VS_CASED, chart2Params.ToArray());

            }

            ArrayList chartData = new()
            {
                new ChartData<ArtStDgamlAllTransAmountVsDivision>
                {
                    ChartId = "StDgamlAllTransAmountVsDivision",
                    Data = chart1Data.ToList(),
                    Title = "Emp Trans Vs division",
                    Cat = "customer_division",
                    Val = "trans_amount",
                    Type = ChartType.donut,
                     LeggendLabelTemplate="(Customer Division ,{name}) : (Transaction Amount ,{value})"

                },
                new ChartData<ArtStDgamlAllTransVsCased>
                {
                    ChartId = "StDgamlAllTransVsCased",
                    Data = chart2data.ToList(),
                    Title = "Emp Trans VS Cased",
                    Cat = "Cased_Transactions",
                    Val = "Transactions_count",
                    Type = ChartType.donut,
                    LeggendLabelTemplate="(Cased Transactions ,{name}) : (Transaction Count ,{value})"
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

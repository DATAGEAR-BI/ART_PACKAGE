using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.ARTGOAML;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data.ARTDGSupport;

namespace ART_PACKAGE.Controllers.DGSUPPORT
{
    public class TicketsSummaryController : Controller
    {
        private readonly ARTDGSupportContext _context;
        private readonly string dbType;
        public TicketsSummaryController(ARTDGSupportContext context, IConfiguration _config)
        {
            _context = context;
            dbType = _config.GetValue<string>("dbType").ToUpper();
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {
            /* modelBuilder.Entity<ArtStTicketsPerAge>().HasNoKey().ToView(null);
modelBuilder.Entity<ArtStTicketsPerModule>().HasNoKey().ToView(null);
modelBuilder.Entity<ArtStTicketsPerProduct>().HasNoKey().ToView(null);
modelBuilder.Entity<ArtStTicketsPerStatus>().HasNoKey().ToView(null);
modelBuilder.Entity<ArtStTicketsPerClient>().HasNoKey().ToView(null);*/

            IEnumerable<ArtStTicketsPerAge> chart1Data = Enumerable.Empty<ArtStTicketsPerAge>();
            IEnumerable<ArtStTicketsPerClient> chart2Data = Enumerable.Empty<ArtStTicketsPerClient>();
            IEnumerable<ArtStTicketsPerModule> chart3Data = Enumerable.Empty<ArtStTicketsPerModule>();
            IEnumerable<ArtStTicketsPerProduct> chart4Data = Enumerable.Empty<ArtStTicketsPerProduct>();
            IEnumerable<ArtStTicketsPerStatus> chart5Data = Enumerable.Empty<ArtStTicketsPerStatus>();

            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart4Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart5Params = para.procFilters.MapToParameters(dbType);

            if (dbType == DbTypes.SqlServer)
            {
                chart1Data = _context.ExecuteProc<ArtStTicketsPerAge>(SQLSERVERSPNames.ART_ST_TICKETS_PER_AGE, chart1Params.ToArray());
                chart2Data = _context.ExecuteProc<ArtStTicketsPerClient>(SQLSERVERSPNames. ART_ST_TICKETS_PER_CLIENT  , chart2Params.ToArray());
                chart3Data = _context.ExecuteProc<ArtStTicketsPerModule>(SQLSERVERSPNames. ART_ST_TICKETS_PER_MODULE  , chart3Params.ToArray());
                chart4Data = _context.ExecuteProc<ArtStTicketsPerProduct>(SQLSERVERSPNames.ART_ST_TICKETS_PER_PRODUCT , chart4Params.ToArray());
                chart5Data = _context.ExecuteProc<ArtStTicketsPerStatus>(SQLSERVERSPNames. ART_ST_TICKETS_PER_STATUS  , chart5Params.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                chart1Data = _context.ExecuteProc<ArtStTicketsPerAge>(ORACLESPName.ART_ST_TICKETS_PER_AGE, chart1Params.ToArray());
                chart2Data = _context.ExecuteProc<ArtStTicketsPerClient>(ORACLESPName. ART_ST_TICKETS_PER_CLIENT  , chart2Params.ToArray());
                chart3Data = _context.ExecuteProc<ArtStTicketsPerModule>(ORACLESPName. ART_ST_TICKETS_PER_MODULE  , chart3Params.ToArray());
                chart4Data = _context.ExecuteProc<ArtStTicketsPerProduct>(ORACLESPName.ART_ST_TICKETS_PER_PRODUCT , chart4Params.ToArray());
                chart5Data = _context.ExecuteProc<ArtStTicketsPerStatus>(ORACLESPName. ART_ST_TICKETS_PER_STATUS  , chart5Params.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                chart1Data = _context.ExecuteProc<ArtStTicketsPerAge>(MYSQLSPName.     ART_ST_TICKETS_PER_AGE     , chart1Params.ToArray());
                chart2Data = _context.ExecuteProc<ArtStTicketsPerClient>(MYSQLSPName.  ART_ST_TICKETS_PER_CLIENT  , chart2Params.ToArray());
                chart3Data = _context.ExecuteProc<ArtStTicketsPerModule>(MYSQLSPName.  ART_ST_TICKETS_PER_MODULE  , chart3Params.ToArray());
                chart4Data = _context.ExecuteProc<ArtStTicketsPerProduct>(MYSQLSPName. ART_ST_TICKETS_PER_PRODUCT , chart4Params.ToArray());
                chart5Data = _context.ExecuteProc<ArtStTicketsPerStatus>(MYSQLSPName.ART_ST_TICKETS_PER_STATUS, chart5Params.ToArray());
            }


            //var Data = data.CallData<StSystemCasesPerYearMonth>(para.req);
            ArrayList chartData = new()
            {
                new ChartData<ArtStTicketsPerAge>
                {
                    ChartId = "StTicketsPerAge",
                    Data = chart1Data.ToList(),
                    Title = "Number of Tickets Per Age",
                    Cat = "DAY_BUCKET",
                    Val = "TOTAL",
                    Type = ChartType.donut

                },
                new ChartData<ArtStTicketsPerClient>
                {
                    ChartId = "StTicketsPerClient",
                    Data = chart2Data.ToList(),
                    Title = "Number of Tickets Per Client",
                    Cat = "CLIENT_NAME",
                    Val = "NUMBER_OF_TICKETS",
                    Type = ChartType.donut
                },
                new ChartData<ArtStTicketsPerModule>
                {
                    ChartId = "StTicketsPerModule",
                    Data = chart3Data.ToList(),
                    Title = "Number of Tickets Per Module",
                    Cat = "MODULE_NAME",
                    Val = "NUMBER_OF_TICKETS",
                    Type = ChartType.donut
                },
                new ChartData<ArtStTicketsPerProduct>
                {
                    ChartId = "StTicketsPerProduct",
                    Data = chart4Data.ToList(),
                    Title = "Number of Tickets Per Product",
                    Cat = "PRODUCT_NAME",
                    Val = "NUMBER_OF_TICKETS",
                    Type = ChartType.donut
                },
                new ChartData<ArtStTicketsPerStatus>
                {
                    ChartId = "StTicketsPerStatus",
                    Data = chart5Data.ToList(),
                    Title = "Number of Tickets Per Status",
                    Cat = "STATUS",
                    Val = "NUMBER_OF_TICKETS",
                    Type = ChartType.donut
                }
            };



            //var result = new
            //{
            //    data = Data.Data,
            //    columns = Data.Columns?.Where(x => x.name == "YEAR" || x.name == "TOTAL_NUMBER_OF_CASES"),
            //    grouplist = new List<string> {

            //        "YEAR",
            //        "MONTH"
            //    },
            //    vallist = new List<string>
            //    {
            //        "TOTAL_NUMBER_OF_CASES",
            //        "TOTAL_NUMBER_OF_CASES"
            //    },
            //    total = Data.Total,
            //    chartdata = chartData
            //};
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

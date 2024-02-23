using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.FATCA;
using Data.DATA.FATCA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections;

namespace ART_PACKAGE.Controllers.ECM
{
    [AllowAnonymous]

    //[Authorize(Roles = "SystemPerformanceSummary")]
    public class FATCASummaryController : Controller
    {
        private readonly FATCAContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;
        private readonly string dbType;

        public FATCASummaryController(FATCAContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IConfiguration config)
        {
            _env = env;
            _cache = cache;
            context = _context;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {
            IEnumerable<ART_ST_FATCA_ALERTS_PER_BRANCH> chart1Data = Enumerable.Empty<ART_ST_FATCA_ALERTS_PER_BRANCH>().AsQueryable();
            IEnumerable<ART_ST_FATCA_ALERTS_PER_TYPE> chart2Data = Enumerable.Empty<ART_ST_FATCA_ALERTS_PER_TYPE>().AsQueryable();
            IEnumerable<ART_ST_FATCA_CASES_PER_BRANCH> chart3Data = Enumerable.Empty<ART_ST_FATCA_CASES_PER_BRANCH>().AsQueryable();
            IEnumerable<ART_ST_FATCA_CASES_PER_TYPE> chart4Data = Enumerable.Empty<ART_ST_FATCA_CASES_PER_TYPE>().AsQueryable();
            IEnumerable<ART_ST_FATCA_CASES_PER_STATUS> chart5Data = Enumerable.Empty<ART_ST_FATCA_CASES_PER_STATUS>().AsQueryable();
            IEnumerable<ART_ST_FATCA_CUSTS_PER_NATION> chart6Data = Enumerable.Empty<ART_ST_FATCA_CUSTS_PER_NATION>().AsQueryable();




            //var startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value;
            //var endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "enddate".ToLower())?.value;
            ////var case_id = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_id".ToLower())?.value ?? "";
            ////var case_type = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_type".ToLower())?.value ?? "";
            ////var case_status = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_status".ToLower())?.value ?? "";
            //var sd = new SqlParameter("@V_START_DATE", SqlDbType.Date)
            //{
            //    Value = startDate
            //};
            //var ed = new SqlParameter("@V_END_DATE", SqlDbType.Date)
            //{
            //    Value = endDate
            //};
            //var sd1 = new SqlParameter("@V_START_DATE", SqlDbType.Date)
            //{
            //    Value = startDate
            //};
            //var ed1 = new SqlParameter("@V_END_DATE", SqlDbType.Date)
            //{
            //    Value = endDate
            //};
            //var sd3 = new SqlParameter("@V_START_DATE", SqlDbType.Date)
            //{
            //    Value = startDate
            //};
            //var ed3 = new SqlParameter("@V_END_DATE", SqlDbType.Date)
            //{
            //    Value = endDate
            //};
            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart2Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart3Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart4Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart5Params = para.procFilters.MapToParameters(dbType);
            IEnumerable<System.Data.Common.DbParameter> chart6Params = para.procFilters.MapToParameters(dbType);


            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = context.ExecuteProc<ART_ST_FATCA_ALERTS_PER_BRANCH>(SQLSERVERSPNames.ART_ST_FATCA_ALERTS_PER_BRANCH, chart1Params.ToArray());
                chart2Data = context.ExecuteProc<ART_ST_FATCA_ALERTS_PER_TYPE>(SQLSERVERSPNames.ART_ST_FATCA_ALERTS_PER_TYPE, chart2Params.ToArray());
                chart3Data = context.ExecuteProc<ART_ST_FATCA_CASES_PER_BRANCH>(SQLSERVERSPNames.ART_ST_FATCA_CASES_PER_BRANCH, chart3Params.ToArray());
                chart4Data = context.ExecuteProc<ART_ST_FATCA_CASES_PER_TYPE>(SQLSERVERSPNames.ART_ST_FATCA_CASES_PER_TYPE, chart4Params.ToArray());
                chart5Data = context.ExecuteProc<ART_ST_FATCA_CASES_PER_STATUS>(SQLSERVERSPNames.ART_ST_FATCA_CASES_PER_STATUS, chart5Params.ToArray());
                chart6Data = context.ExecuteProc<ART_ST_FATCA_CUSTS_PER_NATION>(SQLSERVERSPNames.ART_ST_FATCA_CUSTS_PER_NATION, chart6Params.ToArray());


            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = context.ExecuteProc<ART_ST_FATCA_ALERTS_PER_BRANCH>(ORACLESPName.ART_ST_FATCA_ALERTS_PER_BRANCH, chart1Params.ToArray());
                chart2Data = context.ExecuteProc<ART_ST_FATCA_ALERTS_PER_TYPE>(ORACLESPName.ART_ST_FATCA_ALERTS_PER_TYPE, chart2Params.ToArray());
                chart3Data = context.ExecuteProc<ART_ST_FATCA_CASES_PER_BRANCH>(ORACLESPName.ART_ST_FATCA_CASES_PER_BRANCH, chart3Params.ToArray());
                chart4Data = context.ExecuteProc<ART_ST_FATCA_CASES_PER_TYPE>(ORACLESPName.ART_ST_FATCA_CASES_PER_TYPE, chart4Params.ToArray());
                chart5Data = context.ExecuteProc<ART_ST_FATCA_CASES_PER_STATUS>(ORACLESPName.ART_ST_FATCA_CASES_PER_STATUS, chart5Params.ToArray());
                chart6Data = context.ExecuteProc<ART_ST_FATCA_CUSTS_PER_NATION>(ORACLESPName.ART_ST_FATCA_CUSTS_PER_NATION, chart6Params.ToArray());


            }
            ArrayList chartData = new()
            {
                new ChartData<ART_ST_FATCA_ALERTS_PER_BRANCH>
                {
                    ChartId = "StFatcaAlertsPerBranch",
                    Data = chart1Data.ToList(),
                    Title = "Alerts Per Branch",
                    Cat = "BRANCH_NAME",
                    Val = "NUMBER_OF_ALERTS"

                },
                new ChartData<ART_ST_FATCA_ALERTS_PER_TYPE>
                {
                    ChartId = "StFatcaAlertsPerType",
                    Data = chart2Data.ToList(),
                    Title = "Alerts Per Type",
                    Cat = "TYPE",
                    Val = "NUMBER_OF_ALERTS"
                },
                new ChartData<ART_ST_FATCA_CASES_PER_BRANCH>
                {
                    ChartId = "StFatcaCasesPerBranch",
                    Data = chart3Data.ToList(),
                    Title = "Cases Per Branch",
                    Cat = "BRANCH_NAME",
                    Val = "NUMBER_OF_CASES"
                },
                new ChartData<ART_ST_FATCA_CASES_PER_TYPE>
                {
                    ChartId = "StFatcaCasesPerType",
                    Data = chart4Data.ToList(),
                    Title = "Cases Per Type",
                    Cat = "CASE_TYPE",
                    Val = "NUMBER_OF_CASES"

                },
                new ChartData<ART_ST_FATCA_CASES_PER_STATUS>
                {
                    ChartId = "StFatcaCasesPerStatus",
                    Data = chart5Data.ToList(),
                    Title = "Cases Per Status",
                    Cat = "CASE_STATUS",
                    Val = "NUMBER_OF_CASES"

                },
                new ChartData<ART_ST_FATCA_CUSTS_PER_NATION>
                {
                    ChartId = "StFatcaCustsPerNation",
                    Data = chart6Data.ToList(),
                    Title = "Customers Per Nationality",
                    Cat = "MAIN_NATIONALITY",
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




/*//using MimeKit;
using DataGear_RV_Ver_1._7.Helpers;
using DataGear_RV_Ver_1._7.Helpers.StoredProcsHelpers;
using DataGear_RV_Ver_1._7.StoredProcBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Collections;
using System.Data;
using System.Linq;


using Data.Services.Grid;

namespace DataGear_RV_Ver_1._7.Controllers
{
    public class FATCASummaryController : Controller
    {

        private readonly dbfagpdb.ModelContext dbfagpdb;
        private readonly IMemoryCache _cache;

        public FATCASummaryController(dbfagpdb.ModelContext dbfagpdb, IMemoryCache cache)
        {
            this.dbfagpdb = dbfagpdb;
            _cache = cache;
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {

            IQueryable<StFatcaAlertsPerBranch> chart1Data = Enumerable.Empty<StFatcaAlertsPerBranch>().AsQueryable();
            IQueryable<StFatcaAlertsPerType> chart2Data = Enumerable.Empty<StFatcaAlertsPerType>().AsQueryable();
            IQueryable<StFatcaCasesPerBranch> chart3Data = Enumerable.Empty<StFatcaCasesPerBranch>().AsQueryable();
            IQueryable<StFatcaCasesPerType> chart4Data = Enumerable.Empty<StFatcaCasesPerType>().AsQueryable();
            IQueryable<StFatcaCasesPerStatus> chart5Data = Enumerable.Empty<StFatcaCasesPerStatus>().AsQueryable();
            IQueryable<StFatcaCustsPerNation> chart6Data = Enumerable.Empty<StFatcaCustsPerNation>().AsQueryable();


            var startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value;
            var endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value;
            var sdch1 = new OracleParameter("startDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = startDate
            };
            var edch1 = new OracleParameter("endDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = endDate
            };
            var sdch2 = new OracleParameter("startDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = startDate
            };
            var edch2 = new OracleParameter("endDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = endDate
            };
            var sdch3 = new OracleParameter("startDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = startDate
            };
            var edch3 = new OracleParameter("endDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = endDate
            }; var sdch4 = new OracleParameter("startDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = startDate
            };
            var edch4 = new OracleParameter("endDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = endDate
            }; var sdch5 = new OracleParameter("startDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = startDate
            };
            var edch5 = new OracleParameter("endDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = endDate
            }; var sdch6 = new OracleParameter("startDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = startDate
            };
            var edch6 = new OracleParameter("endDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = endDate
            };

            var chart1output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            }; var chart2output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            };
            var chart3output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            };
            var chart4output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            };
            var chart5output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            };
            var chart6output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            };

            chart1Data = dbfagpdb.ExecuteProc<StFatcaAlertsPerBranch>("ART_ST_FATCA_ALERTS_PER_BRANCH", chart1output, sdch1, edch1*//*, cich1, ctch1, csch1*//*);
            chart2Data = dbfagpdb.ExecuteProc<StFatcaAlertsPerType>("ART_ST_FATCA_ALERTS_PER_TYPE", chart2output, sdch2, edch2*//*, cich2, ctch2, csch2*//*);
            chart3Data = dbfagpdb.ExecuteProc<StFatcaCasesPerBranch>("ART_ST_FATCA_CASES_PER_BRANCH", chart3output, sdch3, edch3*//*, ci, ct, cs*//*);
            chart4Data = dbfagpdb.ExecuteProc<StFatcaCasesPerType>("ART_ST_FATCA_CASES_PER_TYPE", chart4output, sdch4, edch4*//*, ci, ct, cs*//*);
            chart5Data = dbfagpdb.ExecuteProc<StFatcaCasesPerStatus>("ART_ST_FATCA_CASES_PER_STATUS", chart5output, sdch5, edch5*//*, ci, ct, cs*//*);
            chart6Data = dbfagpdb.ExecuteProc<StFatcaCustsPerNation>("ART_ST_FATCA_CUSTS_PER_NATION", chart6output, sdch6, edch6*//*, ci, ct, cs*//*);



            //var Data = data.CallData<StSystemCasesPerYearMonth>(para.req);
            var chartData = new ArrayList {
                new ChartData<StFatcaAlertsPerBranch>
                {
                    ChartId = "StFatcaAlertsPerBranch",
                    Data = chart1Data.ToList(),
                    Title = "Alerts Per Branch",
                    Cat = "BRANCH_NAME",
                    Val = "NUMBER_OF_ALERTS"

                },
                new ChartData<StFatcaAlertsPerType>
                {
                    ChartId = "StFatcaAlertsPerType",
                    Data = chart2Data.ToList(),
                    Title = "Alerts Per Type",
                    Cat = "TYPE",
                    Val = "NUMBER_OF_ALERTS"
                },
                new ChartData<StFatcaCasesPerBranch>
                {
                    ChartId = "StFatcaCasesPerBranch",
                    Data = chart3Data.ToList(),
                    Title = "Cases Per Branch",
                    Cat = "BRANCH_NAME",
                    Val = "NUMBER_OF_CASES"
                },
                new ChartData<StFatcaCasesPerType>
                {
                    ChartId = "StFatcaCasesPerType",
                    Data = chart4Data.ToList(),
                    Title = "Cases Per Type",
                    Cat = "CASE_TYPE",
                    Val = "NUMBER_OF_CASES"

                },
                new ChartData<StFatcaCasesPerStatus>
                {
                    ChartId = "StFatcaCasesPerStatus",
                    Data = chart5Data.ToList(),
                    Title = "Cases Per Status",
                    Cat = "CASE_STATUS",
                    Val = "NUMBER_OF_CASES"

                },
                new ChartData<StFatcaCustsPerNation>
                {
                    ChartId = "StFatcaCustsPerNation",
                    Data = chart6Data.ToList(),
                    Title = "Customers Per Nationality",
                    Cat = "MAIN_NATIONALITY",
                    Val = "NUMBER_OF_CUSTOMERS"

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

        //public ContentResult ArtFatcaAlertsPerBranches()
        //{
        //    var result = db.ArtFatcaAlertsPerBranches.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        //public ContentResult ArtFatcaAlertsPerTypes()
        //{
        //    var result = db.ArtFatcaAlertsPerTypes.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        //public ContentResult ArtFatcaCasesPerBranches()
        //{
        //    var result = db.ArtFatcaCasesPerBranches.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        //public ContentResult ArtFatcaCasesPerTypes()
        //{
        //    var result = db.ArtFatcaCasesPerTypes.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        //public ContentResult ArtFatcaCasesPerStatuses()
        //{
        //    var result = db.ArtFatcaCasesPerStatuses.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        //public ContentResult ArtFatcaCustsPerNations()
        //{
        //    var result = db.ArtFatcaCustsPerNations.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
*/
using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.KYC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtAccountsOpenedClosedWithin6MonthsController : Controller
    {

        private readonly IMemoryCache _cache;
        private readonly KYCContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IConfiguration _config;
        private readonly string dbType;



        public ArtAccountsOpenedClosedWithin6MonthsController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, KYCContext context, IConfiguration config)
        {
            _env = env;
            _cache = cache;
            _pdfSrv = pdfSrv;
            this.context = context;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {
            IEnumerable<ArtStAccountsOpenedClosedWithin6Months> data = Enumerable.Empty<ArtStAccountsOpenedClosedWithin6Months>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStAccountsOpenedClosedWithin6Months>(SQLSERVERSPNames.ART_ST_ACCOUNTS_OPENED_CLOSED_WITHIN_6_MONTHS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStAccountsOpenedClosedWithin6Months>(ORACLESPName.ART_ST_ACCOUNTS_OPENED_CLOSED_WITHIN_6_MONTHS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStAccountsOpenedClosedWithin6Months>(MYSQLSPName.ART_ST_ACCOUNTS_OPENED_CLOSED_WITHIN_6_MONTHS, summaryParams.ToArray());
            }

            KendoDataDesc<ArtStAccountsOpenedClosedWithin6Months> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "AccountsOpenedClosedWithin6Months"
            };
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                }),

            };
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Export([FromBody] StoredReq para)
        {
            IEnumerable<ArtStAccountsOpenedClosedWithin6Months> data = Enumerable.Empty<ArtStAccountsOpenedClosedWithin6Months>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStAccountsOpenedClosedWithin6Months>(SQLSERVERSPNames.ART_ST_ACCOUNTS_OPENED_CLOSED_WITHIN_6_MONTHS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStAccountsOpenedClosedWithin6Months>(ORACLESPName.ART_ST_ACCOUNTS_OPENED_CLOSED_WITHIN_6_MONTHS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStAccountsOpenedClosedWithin6Months>(MYSQLSPName.ART_ST_ACCOUNTS_OPENED_CLOSED_WITHIN_6_MONTHS, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtStAccountsOpenedClosedWithin6Months> data = Enumerable.Empty<ArtStAccountsOpenedClosedWithin6Months>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStAccountsOpenedClosedWithin6Months>(SQLSERVERSPNames.ART_ST_ACCOUNTS_OPENED_CLOSED_WITHIN_6_MONTHS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStAccountsOpenedClosedWithin6Months>(ORACLESPName.ART_ST_ACCOUNTS_OPENED_CLOSED_WITHIN_6_MONTHS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStAccountsOpenedClosedWithin6Months>(MYSQLSPName.ART_ST_ACCOUNTS_OPENED_CLOSED_WITHIN_6_MONTHS, summaryParams.ToArray());
            }
            ViewData["title"] = "Accounts Opened Closed With in 6 Months Report";
            ViewData["desc"] = "";
            byte[] bytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }
    }
}

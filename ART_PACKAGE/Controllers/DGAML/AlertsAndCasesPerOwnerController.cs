using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.ARTDGAML;
using Data.Data.ECM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.DGAML
{
    //[Authorize(Roles = "AlertsAndCasesPerOwner")]
    public class AlertsAndCasesPerOwnerController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly ArtDgAmlContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IConfiguration _config;
        private readonly string dbType;



        public AlertsAndCasesPerOwnerController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, ArtDgAmlContext context, IConfiguration config)
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
            IEnumerable<ArtDgAmlAlertsAndCasesPerOwner> data = Enumerable.Empty<ArtDgAmlAlertsAndCasesPerOwner>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgAmlAlertsAndCasesPerOwner>(SQLSERVERSPNames.ART_ST_DGAML_ALERTS_OR_CASES_PER_OWNER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgAmlAlertsAndCasesPerOwner>(ORACLESPName.ART_ST_DGAML_ALERTS_OR_CASES_PER_OWNER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgAmlAlertsAndCasesPerOwner>(MYSQLSPName.ART_ST_DGAML_ALERTS_OR_CASES_PER_OWNER, summaryParams.ToArray());
            }

            KendoDataDesc<ArtDgAmlAlertsAndCasesPerOwner> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "ArtDgAmlAlertsAndCasesPerOwner"
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
            IEnumerable<ArtDgAmlAlertsAndCasesPerOwner> data = Enumerable.Empty<ArtDgAmlAlertsAndCasesPerOwner>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgAmlAlertsAndCasesPerOwner>(SQLSERVERSPNames.ART_ST_DGAML_ALERTS_OR_CASES_PER_OWNER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgAmlAlertsAndCasesPerOwner>(ORACLESPName.ART_ST_DGAML_ALERTS_OR_CASES_PER_OWNER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgAmlAlertsAndCasesPerOwner>(MYSQLSPName.ART_ST_DGAML_ALERTS_OR_CASES_PER_OWNER, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtDgAmlAlertsAndCasesPerOwner> data = Enumerable.Empty<ArtDgAmlAlertsAndCasesPerOwner>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgAmlAlertsAndCasesPerOwner>(SQLSERVERSPNames.ART_ST_DGAML_ALERTS_OR_CASES_PER_OWNER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgAmlAlertsAndCasesPerOwner>(ORACLESPName.ART_ST_DGAML_ALERTS_OR_CASES_PER_OWNER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgAmlAlertsAndCasesPerOwner>(MYSQLSPName.ART_ST_DGAML_ALERTS_OR_CASES_PER_OWNER, summaryParams.ToArray());
            }
            ViewData["title"] = "Alerts/Cases Per Owner Report";
            ViewData["desc"] = "Shows the total number of alerts or Cases per owner";
            byte[] bytes = await _pdfSrv.ExportToPdf(data.AsQueryable(),para.req, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }
    }
}

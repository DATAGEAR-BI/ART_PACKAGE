using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.ARTDGAML;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "AlertAgeSummery")]
    public class AlertAgeSummaryController : Controller/* BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, ArtStAmlAlertAgeSummery>, SasAmlContext, ArtStAmlAlertAgeSummery>, IBaseRepo<SasAmlContext, ArtStAmlAlertAgeSummery>, SasAmlContext, ArtStAmlAlertAgeSummery>*/
    {
        /*public AlertAgeSummeryController(IGridConstructor<IBaseRepo<SasAmlContext, ArtStAmlAlertAgeSummery>, SasAmlContext, ArtStAmlAlertAgeSummery> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }*/

        private readonly IMemoryCache _cache;
        private readonly SasAmlContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IConfiguration _config;
        private readonly string dbType;



        public AlertAgeSummaryController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, SasAmlContext context, IConfiguration config)
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
            IEnumerable<ArtStAmlAlertAgeSummery> data = Enumerable.Empty<ArtStAmlAlertAgeSummery>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStAmlAlertAgeSummery>(SQLSERVERSPNames.ART_ST_AML_ALERT_AGE_SUMMARY, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                //data = context.ExecuteProc<ArtStAmlAlertAgeSummery>(ORACLESPName.ART_ST_AML_ALERT_AGE_SUMMARY, summaryParams.ToArray());
            }

            KendoDataDesc<ArtStAmlAlertAgeSummery> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data.OrderBy(s => s.Total),
                columns = Data.Columns,
                total = Data.Total,
                reportname = "AlertAgeSummery"
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
            para.req.Sort = new List<SortOptions>() { new() { field = "total", dir = "asc" } };
            IEnumerable<ArtStAmlAlertAgeSummery> data = Enumerable.Empty<ArtStAmlAlertAgeSummery>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStAmlAlertAgeSummery>(SQLSERVERSPNames.ART_ST_AML_ALERT_AGE_SUMMARY, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStAmlAlertAgeSummery>(ORACLESPName.ART_ST_AML_ALERT_AGE_SUMMARY, summaryParams.ToArray());
            }
            if (para.req.Sort == null)
            {
                para.req.Sort = new List<SortOptions> { new SortOptions { field = "Total", dir = "asc" } };
            }
            para.req.IsExport = true;
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtStAmlAlertAgeSummery> data = Enumerable.Empty<ArtStAmlAlertAgeSummery>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStAmlAlertAgeSummery>(SQLSERVERSPNames.ART_ST_AML_ALERT_AGE_SUMMARY, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStAmlAlertAgeSummery>(ORACLESPName.ART_ST_AML_ALERT_AGE_SUMMARY, summaryParams.ToArray());
            }
            ViewData["title"] = "Alert Age Summery Report";
            ViewData["desc"] = "";

            if (para.req.Sort == null)
            {
                para.req.Sort = new List<SortOptions> { new SortOptions { field = "Total", dir = "asc" } };
            }
            byte[] bytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData, ControllerContext, 5
                                        , User.Identity.Name);
            return File(bytes, "text/csv");
        }
    }
}

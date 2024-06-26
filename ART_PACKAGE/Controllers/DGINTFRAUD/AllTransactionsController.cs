using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.DGINTFRAUD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    //[Authorize(Roles = "AllTransactions")]
    public class AllTransactionsController : Controller//BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlCasesTransactions>, DGINTFRAUDContext, ArtDgamlCasesTransactions>, IBaseRepo<DGINTFRAUDContext, ArtDgamlCasesTransactions>, DGINTFRAUDContext, ArtDgamlCasesTransactions>
    {

        private readonly IMemoryCache _cache;
        private readonly DGINTFRAUDContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IConfiguration _config;
        private readonly string dbType;



        public AllTransactionsController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, DGINTFRAUDContext context, IConfiguration config)
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
            IEnumerable<ArtDgamlAllTransaction> data = Enumerable.Empty<ArtDgamlAllTransaction>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgamlAllTransaction>(SQLSERVERSPNames.ART_ST_DGAML_ALL_TRANSACTIONS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgamlAllTransaction>(ORACLESPName.ART_ST_DGAML_ALL_TRANSACTIONS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgamlAllTransaction>(MYSQLSPName.ART_ST_DGAML_ALL_TRANSACTIONS, summaryParams.ToArray());
            }

            KendoDataDesc<ArtDgamlAllTransaction> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "All Transactions"
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
            IEnumerable<ArtDgamlAllTransaction> data = Enumerable.Empty<ArtDgamlAllTransaction>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgamlAllTransaction>(SQLSERVERSPNames.ART_ST_DGAML_ALL_TRANSACTIONS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgamlAllTransaction>(ORACLESPName.ART_ST_DGAML_ALL_TRANSACTIONS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgamlAllTransaction>(MYSQLSPName.ART_ST_DGAML_ALL_TRANSACTIONS, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtDgamlAllTransaction> data = Enumerable.Empty<ArtDgamlAllTransaction>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgamlAllTransaction>(SQLSERVERSPNames.ART_ST_DGAML_ALL_TRANSACTIONS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgamlAllTransaction>(ORACLESPName.ART_ST_DGAML_ALL_TRANSACTIONS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgamlAllTransaction>(MYSQLSPName.ART_ST_DGAML_ALL_TRANSACTIONS, summaryParams.ToArray());
            }
            ViewData["title"] = "All Transactions";
            ViewData["desc"] = "presents all transactions for only one staff with the related information as below";
            byte[] bytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }
    }
}

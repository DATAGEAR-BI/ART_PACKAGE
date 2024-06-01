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
    public class CasesTransactionsDetailController : Controller //BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlCasesTransactionsDetail>, DGINTFRAUDContext, ArtDgamlCasesTransactionsDetail>, IBaseRepo<DGINTFRAUDContext, ArtDgamlCasesTransactionsDetail>, DGINTFRAUDContext, ArtDgamlCasesTransactionsDetail>
    {
        private readonly IMemoryCache _cache;
        private readonly DGINTFRAUDContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IConfiguration _config;
        private readonly string dbType;



        public CasesTransactionsDetailController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, DGINTFRAUDContext context, IConfiguration config)
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
            IEnumerable<ArtDgamlCasesTransactionsDetail> data = Enumerable.Empty<ArtDgamlCasesTransactionsDetail>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgamlCasesTransactionsDetail>(SQLSERVERSPNames.ART_ST_DGAML_CASES_TRANSACTIONS_DETAIL, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgamlCasesTransactionsDetail>(ORACLESPName.ART_ST_DGAML_CASES_TRANSACTIONS_DETAIL, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgamlCasesTransactionsDetail>(MYSQLSPName.ART_ST_DGAML_CASES_TRANSACTIONS_DETAIL, summaryParams.ToArray());
            }

            KendoDataDesc<ArtDgamlCasesTransactionsDetail> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "Cases Transactions Detail"
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
            IEnumerable<ArtDgamlCasesTransactionsDetail> data = Enumerable.Empty<ArtDgamlCasesTransactionsDetail>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgamlCasesTransactionsDetail>(SQLSERVERSPNames.ART_ST_DGAML_CASES_TRANSACTIONS_DETAIL, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgamlCasesTransactionsDetail>(ORACLESPName.ART_ST_DGAML_CASES_TRANSACTIONS_DETAIL, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgamlCasesTransactionsDetail>(MYSQLSPName.ART_ST_DGAML_CASES_TRANSACTIONS_DETAIL, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtDgamlCasesTransactionsDetail> data = Enumerable.Empty<ArtDgamlCasesTransactionsDetail>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgamlCasesTransactionsDetail>(SQLSERVERSPNames.ART_ST_DGAML_CASES_TRANSACTIONS_DETAIL, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgamlCasesTransactionsDetail>(ORACLESPName.ART_ST_DGAML_CASES_TRANSACTIONS_DETAIL, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgamlCasesTransactionsDetail>(MYSQLSPName.ART_ST_DGAML_CASES_TRANSACTIONS_DETAIL, summaryParams.ToArray());
            }
            ViewData["title"] = "Cases Transactions Detail";
            ViewData["desc"] = "Presents all credit transactions for specific staff for only created cases with the related information as below";
            byte[] bytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }

    }
}

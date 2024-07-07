using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.DGINTFRAUD;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    //public class HierarchicalTransactionController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlHierarchicalTransaction>, DGINTFRAUDContext, ArtDgamlHierarchicalTransaction>, IBaseRepo<DGINTFRAUDContext, ArtDgamlHierarchicalTransaction>, DGINTFRAUDContext, ArtDgamlHierarchicalTransaction>
    //{
    //    public HierarchicalTransactionController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlHierarchicalTransaction>, DGINTFRAUDContext, ArtDgamlHierarchicalTransaction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
    //    {
    //    }

    //    public override IActionResult Index()
    //    {
    //        return View();
    //    }

    //}
    public class HierarchicalTransactionController : BaseController//BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlCasesTransactions>, DGINTFRAUDContext, ArtDgamlCasesTransactions>, IBaseRepo<DGINTFRAUDContext, ArtDgamlCasesTransactions>, DGINTFRAUDContext, ArtDgamlCasesTransactions>
    {

        private readonly IMemoryCache _cache;
        private readonly DGINTFRAUDContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IConfiguration _config;
        private readonly string dbType;



        public HierarchicalTransactionController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, DGINTFRAUDContext context, IConfiguration config, UserManager<AppUser> um) : base(um)
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
            IEnumerable<ArtDgamlHierarchicalTransaction> data = Enumerable.Empty<ArtDgamlHierarchicalTransaction>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgamlHierarchicalTransaction>(SQLSERVERSPNames.ART_ST_DGAML_HIERARCHICAL_TRANSACTIONS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgamlHierarchicalTransaction>(ORACLESPName.ART_ST_DGAML_HIERARCHICAL_TRANSACTIONS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgamlHierarchicalTransaction>(MYSQLSPName.ART_ST_DGAML_HIERARCHICAL_TRANSACTIONS, summaryParams.ToArray());
            }

            KendoDataDesc<ArtDgamlHierarchicalTransaction> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total
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
        public async Task<IActionResult> Index()
        {
            AppUser currentUser = await GetUser();
            ViewBag.currentDgUserID = (currentUser != null && currentUser.DgUserId != null) ? currentUser.DgUserId.ToString() : "0";
            return View();
        }


        public async Task<IActionResult> Export([FromBody] StoredReq para)
        {
            IEnumerable<ArtDgamlHierarchicalTransaction> data = Enumerable.Empty<ArtDgamlHierarchicalTransaction>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgamlHierarchicalTransaction>(SQLSERVERSPNames.ART_ST_DGAML_HIERARCHICAL_TRANSACTIONS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgamlHierarchicalTransaction>(ORACLESPName.ART_ST_DGAML_HIERARCHICAL_TRANSACTIONS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgamlHierarchicalTransaction>(MYSQLSPName.ART_ST_DGAML_HIERARCHICAL_TRANSACTIONS, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtDgamlHierarchicalTransaction> data = Enumerable.Empty<ArtDgamlHierarchicalTransaction>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgamlHierarchicalTransaction>(SQLSERVERSPNames.ART_ST_DGAML_HIERARCHICAL_TRANSACTIONS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgamlHierarchicalTransaction>(ORACLESPName.ART_ST_DGAML_HIERARCHICAL_TRANSACTIONS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgamlHierarchicalTransaction>(MYSQLSPName.ART_ST_DGAML_HIERARCHICAL_TRANSACTIONS, summaryParams.ToArray());
            }
            ViewData["title"] = " Hierarchical Transaction";
            ViewData["desc"] = "presents all transactions with staff hierarchy i.e. (subordinates not have access to managers transactions) whereas Regional Delegate can not excluded any staff, Group Head not have access to see Regional Delegate, Head of Support not have the access to see the accounts by Heads of Retail,SMEs and Corporate, Group Head, and Regional Delegate, and Branch Manager not have the access to see the accounts Heads of Retail,SMEs and Corporate, Group Head, Regional Delegate, and Head Of support as below";
            byte[] bytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }
    }
}

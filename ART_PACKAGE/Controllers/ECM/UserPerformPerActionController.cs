using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Grid;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "UserPerformPerAction")]
    public class UserPerformPerActionController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtUserPerformPerAction>, EcmContext, ArtUserPerformPerAction>, IBaseRepo<EcmContext, ArtUserPerformPerAction>, EcmContext, ArtUserPerformPerAction>
    {
        public UserPerformPerActionController(IGridConstructor<IBaseRepo<EcmContext, ArtUserPerformPerAction>, EcmContext, ArtUserPerformPerAction>gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
/*
        private readonly IMemoryCache _cache;
        private readonly EcmContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IConfiguration _config;
        private readonly string dbType;



        public UserPerformPerActionController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, EcmContext context, IConfiguration config)
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
            IEnumerable<ArtUserPerformPerAction> data = Enumerable.Empty<ArtUserPerformPerAction>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtUserPerformPerAction>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtUserPerformPerAction>(ORACLESPName.ST_USER_PERFORMANCE_PER_ACTION, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtUserPerformPerAction>(MYSQLSPName.ART_ST_USER_PERFORMANCE_PER_ACTION, summaryParams.ToArray());
            }

            KendoDataDesc<ArtUserPerformPerAction> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "UserPerformPerAction"
            };
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                }),

            };
        }*/

        public override IActionResult Index()
        {
            return View();
        }

/*
        public async Task<IActionResult> Export([FromBody] StoredReq para)
        {
            IEnumerable<ArtUserPerformPerAction> data = Enumerable.Empty<ArtUserPerformPerAction>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtUserPerformPerAction>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtUserPerformPerAction>(ORACLESPName.ST_USER_PERFORMANCE_PER_ACTION, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtUserPerformPerAction>(MYSQLSPName.ART_ST_USER_PERFORMANCE_PER_ACTION, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtUserPerformPerAction> data = Enumerable.Empty<ArtUserPerformPerAction>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtUserPerformPerAction>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtUserPerformPerAction>(ORACLESPName.ST_USER_PERFORMANCE_PER_ACTION, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtUserPerformPerAction>(MYSQLSPName.ART_ST_USER_PERFORMANCE_PER_ACTION, summaryParams.ToArray());
            }
            ViewData["title"] = "User Performance Per Action Report";
            ViewData["desc"] = "";
            byte[] bytes = await _pdfSrv.ExportToPdf(data.AsQueryable(),para.req, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }*/
    }
}

using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Grid;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.ARTDGAML;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.DGAML
{
    //[Authorize(Roles = "UserPerformancePerUserAndAction")]
    public class DGAMLUserPerformancePerUserAndActionController : /*Controller*/ BaseReportController<IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgAmlUserPerformPerUserAndAction>, ArtDgAmlContext, ArtDgAmlUserPerformPerUserAndAction>, IBaseRepo<ArtDgAmlContext, ArtDgAmlUserPerformPerUserAndAction>, ArtDgAmlContext, ArtDgAmlUserPerformPerUserAndAction>
    {
        public DGAMLUserPerformancePerUserAndActionController(IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgAmlUserPerformPerUserAndAction>, ArtDgAmlContext, ArtDgAmlUserPerformPerUserAndAction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();

        }

        /*
                private readonly IMemoryCache _cache;
                private readonly ArtDgAmlContext context;
                private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
                private readonly IPdfService _pdfSrv;
                private readonly IConfiguration _config;
                private readonly string dbType;



                public UserPerformancePerUserAndActionController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, ArtDgAmlContext context, IConfiguration config)
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
                    IEnumerable<ArtDgAmlUserPerformPerUserAndAction> data = Enumerable.Empty<ArtDgAmlUserPerformPerUserAndAction>().AsQueryable();

                    IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
                    if (dbType == DbTypes.SqlServer)
                    {
                        data = context.ExecuteProc<ArtDgAmlUserPerformPerUserAndAction>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_USER_AND_ACTION, summaryParams.ToArray());
                    }
                    else if (dbType == DbTypes.Oracle)
                    {
                        data = context.ExecuteProc<ArtDgAmlUserPerformPerUserAndAction>(ORACLESPName.ST_USER_PERFORMANCE_PER_USER_AND_ACTION, summaryParams.ToArray());
                    }
                    else if (dbType == DbTypes.MySql)
                    {
                        data = context.ExecuteProc<ArtDgAmlUserPerformPerUserAndAction>(MYSQLSPName.ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION, summaryParams.ToArray());
                    }

                    KendoDataDesc<ArtDgAmlUserPerformPerUserAndAction> Data = data.AsQueryable().CallData(para.req);


                    var result = new
                    {
                        data = Data.Data,
                        columns = Data.Columns,
                        total = Data.Total,
                        reportname = "UserPerformancePerUserAndAction"
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
                    IEnumerable<ArtDgAmlUserPerformPerUserAndAction> data = Enumerable.Empty<ArtDgAmlUserPerformPerUserAndAction>().AsQueryable();

                    IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
                    if (dbType == DbTypes.SqlServer)
                    {
                        data = context.ExecuteProc<ArtDgAmlUserPerformPerUserAndAction>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_USER_AND_ACTION, summaryParams.ToArray());
                    }
                    else if (dbType == DbTypes.Oracle)
                    {
                        data = context.ExecuteProc<ArtDgAmlUserPerformPerUserAndAction>(ORACLESPName.ST_USER_PERFORMANCE_PER_USER_AND_ACTION, summaryParams.ToArray());
                    }
                    else if (dbType == DbTypes.MySql)
                    {
                        data = context.ExecuteProc<ArtDgAmlUserPerformPerUserAndAction>(MYSQLSPName.ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION, summaryParams.ToArray());
                    }
                    para.req.IsExport = true;
                    byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
                    return File(bytes, "text/csv");
                }

                public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
                {
                    IEnumerable<ArtDgAmlUserPerformPerUserAndAction> data = Enumerable.Empty<ArtDgAmlUserPerformPerUserAndAction>().AsQueryable();

                    IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
                    if (dbType == DbTypes.SqlServer)
                    {
                        data = context.ExecuteProc<ArtDgAmlUserPerformPerUserAndAction>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_USER_AND_ACTION, summaryParams.ToArray());
                    }
                    else if (dbType == DbTypes.Oracle)
                    {
                        data = context.ExecuteProc<ArtDgAmlUserPerformPerUserAndAction>(ORACLESPName.ST_USER_PERFORMANCE_PER_USER_AND_ACTION, summaryParams.ToArray());
                    }
                    else if (dbType == DbTypes.MySql)
                    {
                        data = context.ExecuteProc<ArtDgAmlUserPerformPerUserAndAction>(MYSQLSPName.ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION, summaryParams.ToArray());
                    }
                    ViewData["title"] = "User Performance Per User and Action Report";
                    ViewData["desc"] = "";
                    byte[] bytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData, ControllerContext, 5
                                                            , User.Identity.Name);
                    return File(bytes, "text/csv");
                }*/
    }
}

using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Constants.StoredProcs;
using Newtonsoft.Json;
using ART_PACKAGE.Helpers.DropDown;
using Data.Services.Grid;
using Data.Data.ECM;
using ART_PACKAGE.Extentions.DbContextExtentions;

namespace ART_PACKAGE.Controllers.ECM
{
    public class ListUpdateController : Controller
    {

        private readonly IMemoryCache _cache;
        private readonly EcmContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IConfiguration _config;
        private readonly string dbType;
        private readonly IDropDownService _dropDown;



        public ListUpdateController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, EcmContext context, IConfiguration config,IDropDownService dropDown)
        {
            _env = env;
            _cache = cache;
            _pdfSrv = pdfSrv;
            this.context = context;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();
            _dropDown = dropDown;
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {
            IEnumerable<ArtStSanctionListUpdate> data = Enumerable.Empty<ArtStSanctionListUpdate>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStSanctionListUpdate>(SQLSERVERSPNames.ART_ST_SANCTION_LIST_UPDATE, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStSanctionListUpdate>(ORACLESPName.ART_ST_SANCTION_LIST_UPDATE, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStSanctionListUpdate>(MYSQLSPName.ART_ST_SANCTION_LIST_UPDATE, summaryParams.ToArray());
            }

            KendoDataDesc<ArtStSanctionListUpdate> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "ListUpdateReport"
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
        public IActionResult GetWatchListNameDropDown()
        {


            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(_dropDown.GetWatchListNameDropDown(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public IActionResult GetTypeDropDown()
        {
            List<SelectItem> Result = new()
            {
                    new SelectItem(){ text="ORGANIZATION" , value="ORGANIZATION" },
                    new SelectItem(){ text="INDIVIDUAL" , value="INDIVIDUAL" },
            };
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(Result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public IActionResult GetStatusDropDown()
        {
            List<SelectItem> Result = new()
            {
                    new SelectItem(){ text="ADDED" , value="ADDED" },
                    new SelectItem(){ text="UPDATED" , value="UPDATED" },
                    new SelectItem(){ text="REMOVED" , value="REMOVED" },
            };
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(Result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public async Task<IActionResult> Export([FromBody] StoredReq para)
        {
            IEnumerable<ArtStSanctionListUpdate> data = Enumerable.Empty<ArtStSanctionListUpdate>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStSanctionListUpdate>(SQLSERVERSPNames.ART_ST_SANCTION_LIST_UPDATE, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStSanctionListUpdate>(ORACLESPName.ART_ST_SANCTION_LIST_UPDATE, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStSanctionListUpdate>(MYSQLSPName.ART_ST_SANCTION_LIST_UPDATE, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtStSanctionListUpdate> data = Enumerable.Empty<ArtStSanctionListUpdate>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStSanctionListUpdate>(SQLSERVERSPNames.ART_ST_SANCTION_LIST_UPDATE, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStSanctionListUpdate>(ORACLESPName.ART_ST_SANCTION_LIST_UPDATE, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStSanctionListUpdate>(MYSQLSPName.ART_ST_SANCTION_LIST_UPDATE, summaryParams.ToArray());
            }
            ViewData["title"] = "List Update Report";
            ViewData["desc"] = "";
            byte[] bytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }
    }
}

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
    public class ScreeningStatusController : Controller
    {

        private readonly IMemoryCache _cache;
        private readonly EcmContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IConfiguration _config;
        private readonly string dbType;
        private readonly IDropDownService _dropDown;



        public ScreeningStatusController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, EcmContext context, IConfiguration config,IDropDownService dropDown)
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
            IEnumerable<ArtStSanctionScreeningStatus> data = Enumerable.Empty<ArtStSanctionScreeningStatus>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStSanctionScreeningStatus>(SQLSERVERSPNames.ART_ST_SANCTION_SCREENING_STATUS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStSanctionScreeningStatus>(ORACLESPName.ART_ST_SANCTION_SCREENING_STATUS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStSanctionScreeningStatus>(MYSQLSPName.ART_ST_SANCTION_SCREENING_STATUS, summaryParams.ToArray());
            }

            KendoDataDesc<ArtStSanctionScreeningStatus> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "ScreeningStatusReport"
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
        public IActionResult GetSourceTypeDropDown()
        {


            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(_dropDown.GetSourceTypeDropDown(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public IActionResult GetSearchMatchDropDown()
        {
            List<SelectItem> Result = new()
            {
                    new SelectItem(){ text="Found" , value="Found" },
                    new SelectItem(){ text="Not Found" , value="Not Found" },
            };
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(Result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public async Task<IActionResult> Export([FromBody] StoredReq para)
        {
            IEnumerable<ArtStSanctionScreeningStatus> data = Enumerable.Empty<ArtStSanctionScreeningStatus>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStSanctionScreeningStatus>(SQLSERVERSPNames.ART_ST_SANCTION_SCREENING_STATUS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStSanctionScreeningStatus>(ORACLESPName.ART_ST_SANCTION_SCREENING_STATUS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStSanctionScreeningStatus>(MYSQLSPName.ART_ST_SANCTION_SCREENING_STATUS, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtStSanctionScreeningStatus> data = Enumerable.Empty<ArtStSanctionScreeningStatus>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStSanctionScreeningStatus>(SQLSERVERSPNames.ART_ST_SANCTION_SCREENING_STATUS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStSanctionScreeningStatus>(ORACLESPName.ART_ST_SANCTION_SCREENING_STATUS, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStSanctionScreeningStatus>(MYSQLSPName.ART_ST_SANCTION_SCREENING_STATUS, summaryParams.ToArray());
            }
            ViewData["title"] = "Screening Status Report";
            ViewData["desc"] = "";
            byte[] bytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }
    }
}

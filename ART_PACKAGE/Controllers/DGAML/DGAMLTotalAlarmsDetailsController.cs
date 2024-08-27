using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;

using Data.Constants.StoredProcs;
using Newtonsoft.Json;
using ART_PACKAGE.Helpers.DropDown;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLTotalAlarmsDetailsController : Controller
    {

        private readonly IMemoryCache _cache;
        private readonly ArtDgAmlContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IConfiguration _config;
        private readonly string dbType;
        private readonly IDropDownService _dropDown;



        public DGAMLTotalAlarmsDetailsController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, ArtDgAmlContext context, IConfiguration config,IDropDownService dropDown)
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
            IEnumerable<ArtStDgAmlTotalAlarmsDetail> data = Enumerable.Empty<ArtStDgAmlTotalAlarmsDetail>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStDgAmlTotalAlarmsDetail>(SQLSERVERSPNames.ART_ST_DGAML_TOTAL_ALARMS_DETAIL, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStDgAmlTotalAlarmsDetail>(ORACLESPName.ART_ST_DGAML_TOTAL_ALARMS_DETAIL, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStDgAmlTotalAlarmsDetail>(MYSQLSPName.ART_ST_DGAML_TOTAL_ALARMS_DETAIL, summaryParams.ToArray());
            }

            KendoDataDesc<ArtStDgAmlTotalAlarmsDetail> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "DGAMLTotalAlarmsDetails"
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

        public IActionResult GetRoutineNameDropDown()
        {


            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(_dropDown.GetRoutineNameDropDown(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public IActionResult GetAlarmStatusDropDown()
        {


            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(_dropDown.GetAlarmStatusDropDown(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public async Task<IActionResult> Export([FromBody] StoredReq para)
        {
            IEnumerable<ArtStDgAmlTotalAlarmsDetail> data = Enumerable.Empty<ArtStDgAmlTotalAlarmsDetail>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStDgAmlTotalAlarmsDetail>(SQLSERVERSPNames.ART_ST_DGAML_TOTAL_ALARMS_DETAIL, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStDgAmlTotalAlarmsDetail>(ORACLESPName.ART_ST_DGAML_TOTAL_ALARMS_DETAIL, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStDgAmlTotalAlarmsDetail>(MYSQLSPName.ART_ST_DGAML_TOTAL_ALARMS_DETAIL, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtStDgAmlTotalAlarmsDetail> data = Enumerable.Empty<ArtStDgAmlTotalAlarmsDetail>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStDgAmlTotalAlarmsDetail>(SQLSERVERSPNames.ART_ST_DGAML_TOTAL_ALARMS_DETAIL, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStDgAmlTotalAlarmsDetail>(ORACLESPName.ART_ST_DGAML_TOTAL_ALARMS_DETAIL, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStDgAmlTotalAlarmsDetail>(MYSQLSPName.ART_ST_DGAML_TOTAL_ALARMS_DETAIL, summaryParams.ToArray());
            }
            ViewData["title"] = "Total Alarm Detail";
            ViewData["desc"] = "";
            byte[] bytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }
    }
}

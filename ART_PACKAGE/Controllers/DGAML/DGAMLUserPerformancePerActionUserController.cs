using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Grid;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.ARTDGAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.DGAML
{
    //[Authorize(Roles = "DGAMLUserPerformancePerActionUser")]
    public class DGAMLUserPerformancePerActionUserController : /*Controller*/ BaseReportController<IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgAmlUserPerformancePerActionUser>, ArtDgAmlContext, ArtDgAmlUserPerformancePerActionUser>, IBaseRepo<ArtDgAmlContext, ArtDgAmlUserPerformancePerActionUser>, ArtDgAmlContext, ArtDgAmlUserPerformancePerActionUser>
    {
        public DGAMLUserPerformancePerActionUserController(IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgAmlUserPerformancePerActionUser>, ArtDgAmlContext, ArtDgAmlUserPerformancePerActionUser> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        /*private readonly ArtDgAmlContext context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;
        private readonly ICsvExport _csvSrv;
        private readonly string dbType;
        private readonly IConfiguration _config;

        public DGAMLUserPerformancePerActionUserController(ArtDgAmlContext context, IPdfService pdfSrv, IDropDownService dropSrv, ICsvExport csvSrv, IConfiguration config)
        {
            this.context = context;
            _pdfSrv = pdfSrv;
            _dropSrv = dropSrv;
            _csvSrv = csvSrv;
            _config = config;
            dbType = config.GetValue<string>("dbType").ToUpper();

        }
        public IActionResult GetData([FromBody] StoredReq para)
        {
            IEnumerable<ArtDgAmlUserPerformancePerActionUser> data = Enumerable.Empty<ArtDgAmlUserPerformancePerActionUser>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgAmlUserPerformancePerActionUser>(SQLSERVERSPNames.ART_ST_USER_PERFORMANCE_PER_USER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgAmlUserPerformancePerActionUser>(ORACLESPName.ART_ST_USER_PERFORMANCE_PER_USER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgAmlUserPerformancePerActionUser>(MYSQLSPName.ART_ST_USER_PERFORMANCE_PER_USER, summaryParams.ToArray());
            }


            KendoDataDesc<ArtDgAmlUserPerformancePerActionUser> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "AmlUserPerformancePerActionUser"
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

        public async Task<IActionResult> Export([FromBody] StoredReq para)
        {
            IEnumerable<ArtDgAmlUserPerformancePerActionUser> data = Enumerable.Empty<ArtDgAmlUserPerformancePerActionUser>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgAmlUserPerformancePerActionUser>(SQLSERVERSPNames.ART_ST_USER_PERFORMANCE_PER_USER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgAmlUserPerformancePerActionUser>(ORACLESPName.ART_ST_USER_PERFORMANCE_PER_USER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgAmlUserPerformancePerActionUser>(MYSQLSPName.ART_ST_USER_PERFORMANCE_PER_USER, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtDgAmlUserPerformancePerActionUser> data = Enumerable.Empty<ArtDgAmlUserPerformancePerActionUser>().AsQueryable();

            string startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
            string endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtDgAmlUserPerformancePerActionUser>(SQLSERVERSPNames.ART_ST_USER_PERFORMANCE_PER_USER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtDgAmlUserPerformancePerActionUser>(ORACLESPName.ART_ST_USER_PERFORMANCE_PER_USER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtDgAmlUserPerformancePerActionUser>(MYSQLSPName.ART_ST_USER_PERFORMANCE_PER_USER, summaryParams.ToArray());
            }
            ViewData["title"] = "User Performance Per Action User Report";
            ViewData["desc"] = "";
            byte[] bytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "application/pdf");
        }
*/




        public override IActionResult Index()
        {
            return View();
        }


    }
}

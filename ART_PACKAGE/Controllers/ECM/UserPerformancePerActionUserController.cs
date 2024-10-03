using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.ECM;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "UserPerformancePerActionUser")]
    public class UserPerformancePerActionUserController : Controller /*BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtUserPerformancePerActionUser>, EcmContext, ArtUserPerformancePerActionUser>, IBaseRepo<EcmContext, ArtUserPerformancePerActionUser>, EcmContext, ArtUserPerformancePerActionUser>
    {
        public UserPerformancePerActionUserController(IGridConstructor<IBaseRepo<EcmContext, ArtUserPerformancePerActionUser>, EcmContext, ArtUserPerformancePerActionUser> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }*/
    {
        private readonly EcmContext context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;
        private readonly ICsvExport _csvSrv;
        private readonly string dbType;
        private readonly IConfiguration _config;

        public UserPerformancePerActionUserController(EcmContext context, IPdfService pdfSrv, IDropDownService dropSrv, ICsvExport csvSrv, IConfiguration config)
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
            IEnumerable<ArtUserPerformancePerActionUser> data = Enumerable.Empty<ArtUserPerformancePerActionUser>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtUserPerformancePerActionUser>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION_USER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtUserPerformancePerActionUser>(ORACLESPName.ST_USER_PERFORMANCE_PER_ACTION_USER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtUserPerformancePerActionUser>(MYSQLSPName.ART_ST_USER_PERFORMANCE_PER_ACTION_USER, summaryParams.ToArray());
            }


            KendoDataDesc<ArtUserPerformancePerActionUser> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "UserPerformancePerActionUser"
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
            IEnumerable<ArtUserPerformancePerActionUser> data = Enumerable.Empty<ArtUserPerformancePerActionUser>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtUserPerformancePerActionUser>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION_USER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtUserPerformancePerActionUser>(ORACLESPName.ST_USER_PERFORMANCE_PER_ACTION_USER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtUserPerformancePerActionUser>(MYSQLSPName.ART_ST_USER_PERFORMANCE_PER_ACTION_USER, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtUserPerformancePerActionUser> data = Enumerable.Empty<ArtUserPerformancePerActionUser>().AsQueryable();

            string startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
            string endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtUserPerformancePerActionUser>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION_USER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtUserPerformancePerActionUser>(ORACLESPName.ST_USER_PERFORMANCE_PER_ACTION_USER, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtUserPerformancePerActionUser>(MYSQLSPName.ART_ST_USER_PERFORMANCE_PER_ACTION_USER, summaryParams.ToArray());
            }
            ViewData["title"] = "User Performance Per Action User Report";
            ViewData["desc"] = "presents all sanction closed and terminated cases without the manually closed cases with the related information as below";
            byte[] bytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "application/pdf");
        }





        public IActionResult Index()
        {
            return View();
        }


    }
}

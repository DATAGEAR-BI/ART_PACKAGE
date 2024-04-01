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
            dbType = _config.GetValue<string>("dbType").ToUpper();

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
            ViewData["title"] = "User Performance Per Action User Report";
            ViewData["desc"] = "";
            byte[] bytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "application/pdf");
        }





        public IActionResult Index()
        {
            return View();
        }


    }
}

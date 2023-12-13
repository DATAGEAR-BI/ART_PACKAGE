using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "UserPerformancePerActionUser")]
    public class UserPerformancePerActionUserController : BaseReportController<EcmContext, ArtUserPerformancePerActionUser>
    {
        public UserPerformancePerActionUserController(IGridConstructor<EcmContext, ArtUserPerformancePerActionUser> gridConstructor) : base(gridConstructor)
        {
        }


        //public async Task<IActionResult> Export([FromBody] StoredReq para)
        //{
        //    IEnumerable<ArtUserPerformancePerActionUser> data = Enumerable.Empty<ArtUserPerformancePerActionUser>().AsQueryable();

        //    IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
        //    if (dbType == DbTypes.SqlServer)
        //    {
        //        data = context.ExecuteProc<ArtUserPerformancePerActionUser>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION_USER, summaryParams.ToArray());
        //    }
        //    else if (dbType == DbTypes.Oracle)
        //    {
        //        data = context.ExecuteProc<ArtUserPerformancePerActionUser>(ORACLESPName.ST_USER_PERFORMANCE_PER_ACTION_USER, summaryParams.ToArray());
        //    }
        //    byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
        //    return File(bytes, "text/csv");
        //}


        //public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        //{
        //    IEnumerable<ArtUserPerformancePerActionUser> data = Enumerable.Empty<ArtUserPerformancePerActionUser>().AsQueryable();

        //    string startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
        //    string endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";

        //    IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
        //    if (dbType == DbTypes.SqlServer)
        //    {
        //        data = context.ExecuteProc<ArtUserPerformancePerActionUser>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION_USER, summaryParams.ToArray());
        //    }
        //    else if (dbType == DbTypes.Oracle)
        //    {
        //        data = context.ExecuteProc<ArtUserPerformancePerActionUser>(ORACLESPName.ST_USER_PERFORMANCE_PER_ACTION_USER, summaryParams.ToArray());
        //    }
        //    ViewData["title"] = "User Performance Per Action User Report";
        //    ViewData["desc"] = "";
        //    byte[] bytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
        //                                            , User.Identity.Name);
        //    return File(bytes, "application/pdf");
        //}





        public override IActionResult Index()
        {
            return View();
        }


    }
}

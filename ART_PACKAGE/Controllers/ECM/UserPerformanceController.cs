using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "UserPerformance")]
    public class UserPerformanceController : BaseReportController<IBaseRepo<EcmContext, ArtUserPerformance>, EcmContext, ArtUserPerformance>
    {
        public UserPerformanceController(IGridConstructor<IBaseRepo<EcmContext, ArtUserPerformance>, EcmContext, ArtUserPerformance> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtUserPerformance> data = context.ArtUserPerformances.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            {"CaseTypeCd".ToLower()              , _dropSrv.GetCaseTypeDropDown()    .ToDynamicList()     },
        //            {"CaseStatus".ToLower()             , _dropSrv.GetUserCaseStatusDropDown()    .ToDynamicList()     },
        //            {"Priority".ToLower()               ,  _dropSrv.GetPriorityDropDown()     .ToDynamicList()     },

        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].SkipList;
        //    }


        //    KendoDataDesc<ArtUserPerformance> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //    };

        //    return new ContentResult
        //    {
        //        ContentType = "application/json",
        //        Content = JsonConvert.SerializeObject(result)
        //    };
        //}
        //public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        //{
        //    Microsoft.EntityFrameworkCore.DbSet<ArtUserPerformance> data = context.ArtUserPerformances;
        //    byte[] bytes = await data.ExportToCSV<ArtUserPerformance, GenericCsvClassMapper<ArtUserPerformance, UserPerformanceController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].SkipList;
        //    List<ArtUserPerformance> data = context.ArtUserPerformances.CallData(req).Data.ToList();
        //    ViewData["title"] = "User Performance Report";
        //    ViewData["desc"] = "This report presents all sanction closed and terminated cases without the manually closed cases with the related information on user level as below";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}

        public override IActionResult Index()
        {
            return View();
        }
    }
}

using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "SystemPerformance")]
    public class SystemPerformanceController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtSystemPerformance>, EcmContext, ArtSystemPerformance>, IBaseRepo<EcmContext, ArtSystemPerformance>, EcmContext, ArtSystemPerformance>
    {
        public SystemPerformanceController(IGridConstructor<IBaseRepo<EcmContext, ArtSystemPerformance>, EcmContext, ArtSystemPerformance> gridConstructor/*, UserManager<AppUser> um*/) : base(gridConstructor)
        {
        }







        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtSystemPerformance> data = context.ArtSystemPerformances.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].DisplayNames;

        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            { "CaseType".ToLower()              , _dropSrv.GetCaseTypeDropDown()      .ToDynamicList()     },
        //            {"CaseStatus".ToLower()             , _dropSrv.GetSystemCaseStatusDropDown()    .ToDynamicList()     },
        //            {"Priority".ToLower()               ,  _dropSrv.GetPriorityDropDown()     .ToDynamicList()     },
        //            {"TransactionDirection".ToLower()   ,_dropSrv.GetTransDirectionDropDown() .ToDynamicList()     },
        //            {"TransactionType".ToLower()        ,_dropSrv.GetTransTypeDropDown()      .ToDynamicList()     },
        //            {"UpdateUserId".ToLower()           ,_dropSrv.GetUpdateUserIdDropDown()          .ToDynamicList()     },
        //            {"InvestrUserId".ToLower()          ,_dropSrv.GetInvestagtorDropDown()          .ToDynamicList()     },
        //        };
        //    }
        //    ColumnsToSkip = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].SkipList;

        //    KendoDataDesc<ArtSystemPerformance> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

        //public IActionResult Export([FromBody] ExportDto<decimal> para)
        //{
        //    Microsoft.EntityFrameworkCore.DbSet<ArtSystemPerformance> data = context.ArtSystemPerformances;
        //    _csvSrv.ExportAllCsv<ArtSystemPerformance, SystemPerformanceController, decimal>(data, User.Identity.Name, para);
        //    return new EmptyResult();
        //}


        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].SkipList;
        //    List<ArtSystemPerformance> data = context.ArtSystemPerformances.CallData(req).Data.ToList();
        //    ViewData["title"] = "System Performance Report";
        //    ViewData["desc"] = "This report presents all sanction cases with the related information on case level as below";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}


        public override IActionResult Index()
        {
            return View();
        }
    }
}

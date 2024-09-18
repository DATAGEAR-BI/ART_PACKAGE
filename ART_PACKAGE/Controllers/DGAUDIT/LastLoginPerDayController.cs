using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.Audit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAUDIT
{

    public class LastLoginPerDayController : BaseReportController<IGridConstructor<IBaseRepo<ArtAuditContext, LastLoginPerDayView>, ArtAuditContext, LastLoginPerDayView>, IBaseRepo<ArtAuditContext, LastLoginPerDayView>, ArtAuditContext, LastLoginPerDayView>
    {
        public LastLoginPerDayController(IGridConstructor<IBaseRepo<ArtAuditContext, LastLoginPerDayView>, ArtAuditContext, LastLoginPerDayView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //private readonly ArtAuditContext context;
        //private readonly IPdfService _pdfSrv;
        //private readonly IDropDownService _dropSrv;
        //public LastLoginPerDayController(ArtAuditContext context, IPdfService pdfSrv, IDropDownService dropSrv)
        //{
        //    this.context = context;
        //    _pdfSrv = pdfSrv;
        //    _dropSrv = dropSrv;
        //}

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<LastLoginPerDayView> data = context.LastLoginPerDayViews.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(LastLoginPerDayController).ToLower()].DisplayNames;

        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            {nameof(LastLoginPerDayView.AppName)        .ToLower()    , _dropSrv.GetAppNameDropDown().ToDynamicList() },
        //            {nameof(LastLoginPerDayView.DeviceName)     .ToLower()    , _dropSrv.GetDeviceNameDropDown().ToDynamicList() },
        //            {nameof(LastLoginPerDayView.DeviceType)     .ToLower()    , _dropSrv.GetDeviceTypeDropDown().ToDynamicList() },
        //            {nameof(LastLoginPerDayView.UserName)       .ToLower()    , _dropSrv.GetRoleAudNameDropDown().ToDynamicList() },
        //        };
        //    }
        //    ColumnsToSkip = ReportsConfig.CONFIG[nameof(LastLoginPerDayController).ToLower()].SkipList;

        //    KendoDataDesc<LastLoginPerDayView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    Microsoft.EntityFrameworkCore.DbSet<LastLoginPerDayView> data = context.LastLoginPerDayViews;
        //    byte[] bytes = await data.ExportToCSV<LastLoginPerDayView, GenericCsvClassMapper<LastLoginPerDayView, LastLoginPerDayController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}


        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(LastLoginPerDayController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(LastLoginPerDayController).ToLower()].SkipList;
        //    List<LastLoginPerDayView> data = context.LastLoginPerDayViews.CallData(req).Data.ToList();
        //    ViewData["title"] = "User Last Login Per Day Report";
        //    ViewData["desc"] = "This Report presents each user with last login dateime for each day";
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

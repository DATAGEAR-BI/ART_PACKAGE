using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.Audit;
using Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAUDIT
{

    public class AuditRolesController : BaseReportController<IGridConstructor<IBaseRepo<ArtAuditContext, ArtRolesAuditView>, ArtAuditContext, ArtRolesAuditView>, IBaseRepo<ArtAuditContext, ArtRolesAuditView>, ArtAuditContext, ArtRolesAuditView>
    {
        public AuditRolesController(IGridConstructor<IBaseRepo<ArtAuditContext, ArtRolesAuditView>, ArtAuditContext, ArtRolesAuditView> gridConstructor) : base(gridConstructor)
        {
        }

        //private readonly ArtAuditContext context;
        //private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        //private readonly IPdfService _pdfSrv;
        //private readonly IDropDownService _dropSrv;


        //public AuditRolesController(ArtAuditContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, IDropDownService dropSrv)
        //{
        //    _env = env; _pdfSrv = pdfSrv; context = _context;
        //    _dropSrv = dropSrv;
        //}

        ////private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtRolesAuditView> data = context.ArtRolesAuditViews.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(AuditRolesController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            {nameof(ArtRolesAuditView.GroupNames)       .ToLower()    , _dropSrv.GetGroupAudNameDropDown().ToDynamicList() },
        //            {nameof(ArtRolesAuditView.CreatedBy)        .ToLower()    , _dropSrv.GetUserAudNameDropDown().ToDynamicList() },
        //            {nameof(ArtRolesAuditView.LastUpdatedBy)    .ToLower()        , _dropSrv.GetUserAudNameDropDown().ToDynamicList() },
        //            {nameof(ArtRolesAuditView.Action)           .ToLower()        , new List<string> { "Add", "Update", "Delete" }.ToDynamicList() },
        //            {nameof(ArtRolesAuditView.RoleName)         .ToLower()    , _dropSrv.GetRoleAudNameDropDown().ToDynamicList() },
        //            {nameof(ArtRolesAuditView.MemberUsers)      .ToLower()    , _dropSrv.GetMemberUsersDropDown().ToDynamicList() },

        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].SkipList;
        //    }


        //    KendoDataDesc<ArtRolesAuditView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    Microsoft.EntityFrameworkCore.DbSet<ArtRolesAuditView> data = context.ArtRolesAuditViews;
        //    byte[] bytes = await data.ExportToCSV<ArtRolesAuditView, GenericCsvClassMapper<ArtRolesAuditView, AuditRolesController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(AuditRolesController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AuditRolesController).ToLower()].SkipList;
        //    List<ArtRolesAuditView> data = context.ArtRolesAuditViews.CallData(req).Data.ToList();
        //    ViewData["title"] = "ART Role Audit Report";
        //    ViewData["desc"] = "This report Presents all events of roles with the related information as below";
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

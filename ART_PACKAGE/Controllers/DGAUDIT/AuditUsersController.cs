using ART_PACKAGE.Helpers.Grid;
using Data.Data.Audit;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAUDIT
{

    public class AuditUsersController : BaseReportController<IBaseRepo<ArtAuditContext, ArtUsersAuditView>, ArtAuditContext, ArtUsersAuditView>
    {
        public AuditUsersController(IGridConstructor<IBaseRepo<ArtAuditContext, ArtUsersAuditView>, ArtAuditContext, ArtUsersAuditView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //private readonly ArtAuditContext context;
        //private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        //private readonly IPdfService _pdfSrv;
        //private readonly IDropDownService _dropSrv;

        //public AuditUsersController(ArtAuditContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, IDropDownService dropSrv)
        //{
        //    _env = env; _pdfSrv = pdfSrv; context = _context;
        //    _dropSrv = dropSrv;
        //}

        ////private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtUsersAuditView> data = context.ArtUsersAuditViews.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(AuditUsersController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            {nameof(ArtUsersAuditView.GroupNames)      .ToLower()     , _dropSrv.GetGroupAudNameDropDown().ToDynamicList() },
        //            {nameof(ArtUsersAuditView.CreatedBy)       .ToLower()     , _dropSrv.GetUserAudNameDropDown().ToDynamicList() },
        //            {nameof(ArtUsersAuditView.LastUpdatedBy)   .ToLower()         , _dropSrv.GetUserAudNameDropDown().ToDynamicList() },
        //            {nameof(ArtUsersAuditView.RoleNames)       .ToLower()     , _dropSrv.GetRoleAudNameDropDown().ToDynamicList() },
        //            {nameof(ArtUsersAuditView.DomainAccounts)  .ToLower()         , _dropSrv.GetMemberUsersDropDown().ToDynamicList() },
        //            {nameof(ArtUsersAuditView.Action)          .ToLower()     , new List<string> { "Add", "Update", "Delete" }.ToDynamicList() },
        //            {nameof(ArtUsersAuditView.UserName)        .ToLower()     , _dropSrv.GetRoleAudNameDropDown().ToDynamicList() },

        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].SkipList;
        //    }


        //    KendoDataDesc<ArtUsersAuditView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    Microsoft.EntityFrameworkCore.DbSet<ArtUsersAuditView> data = context.ArtUsersAuditViews;
        //    byte[] bytes = await data.ExportToCSV<ArtUsersAuditView, GenericCsvClassMapper<ArtUsersAuditView, AuditUsersController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(AuditUsersController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AuditUsersController).ToLower()].SkipList;
        //    List<ArtUsersAuditView> data = context.ArtUsersAuditViews.CallData(req).Data.ToList();
        //    ViewData["title"] = "ART User Audit Report";
        //    ViewData["desc"] = "This report Presents all events of users with the related information as below";
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

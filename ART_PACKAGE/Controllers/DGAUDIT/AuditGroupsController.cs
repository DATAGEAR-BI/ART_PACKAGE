using ART_PACKAGE.Helpers.Grid;
using Data.Data.Audit;
using Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAUDIT
{

    public class AuditGroupsController : BaseReportController<IGridConstructor<IBaseRepo<ArtAuditContext, ArtGroupsAuditView>, ArtAuditContext, ArtGroupsAuditView>, IBaseRepo<ArtAuditContext, ArtGroupsAuditView>, ArtAuditContext, ArtGroupsAuditView>
    {
        public AuditGroupsController(IGridConstructor<IBaseRepo<ArtAuditContext, ArtGroupsAuditView>, ArtAuditContext, ArtGroupsAuditView> gridConstructor) : base(gridConstructor)
        {
        }

        //private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtGroupsAuditView> data = context.ArtGroupsAuditViews.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(AuditGroupsController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            {nameof(ArtGroupsAuditView.GroupName            ).ToLower(), _dropSrv.GetGroupAudNameDropDown().ToDynamicList() },
        //            {nameof(ArtGroupsAuditView.CreatedBy            ).ToLower(), _dropSrv.GetUserAudNameDropDown().ToDynamicList() },
        //            {nameof(ArtGroupsAuditView.LastUpdatedBy        ).ToLower(), _dropSrv.GetUserAudNameDropDown().ToDynamicList() },
        //            {nameof(ArtGroupsAuditView.SubGroupNames        ).ToLower(), _dropSrv.GetGroupAudNameDropDown().ToDynamicList() },
        //            {nameof(ArtGroupsAuditView.RoleNames            ).ToLower(), _dropSrv.GetRoleAudNameDropDown().ToDynamicList() },
        //            {nameof(ArtGroupsAuditView.MemberUsers          ).ToLower(), _dropSrv.GetMemberUsersDropDown().ToDynamicList() },
        //            {nameof(ArtGroupsAuditView.Action               ).ToLower(), new List<string> { "Add", "Update", "Delete" }.ToDynamicList() },
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].SkipList;
        //    }


        //    KendoDataDesc<ArtGroupsAuditView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    Microsoft.EntityFrameworkCore.DbSet<ArtGroupsAuditView> data = context.ArtGroupsAuditViews;
        //    byte[] bytes = await data.ExportToCSV<ArtGroupsAuditView, GenericCsvClassMapper<ArtGroupsAuditView, AuditGroupsController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(AuditGroupsController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AuditGroupsController).ToLower()].SkipList;
        //    List<ArtGroupsAuditView> data = context.ArtGroupsAuditViews.CallData(req).Data.ToList();
        //    ViewData["title"] = "ART Group Audit Report";
        //    ViewData["desc"] = "This report Presents all events of groups with the related information as below";
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

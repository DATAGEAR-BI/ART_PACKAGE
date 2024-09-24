using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.Audit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAUDIT
{

    public class ListGroupsRolesSummaryController : BaseReportController<IGridConstructor<IBaseRepo<ArtAuditContext, ListGroupsRolesSummary>, ArtAuditContext, ListGroupsRolesSummary>, IBaseRepo<ArtAuditContext, ListGroupsRolesSummary>, ArtAuditContext, ListGroupsRolesSummary>
    {
        public ListGroupsRolesSummaryController(IGridConstructor<IBaseRepo<ArtAuditContext, ListGroupsRolesSummary>, ArtAuditContext, ListGroupsRolesSummary> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //private readonly ArtAuditContext context;
        //private readonly IPdfService _pdfSrv;
        //private readonly IDropDownService _dropSrv;
        //public ListGroupsRolesSummaryController(ArtAuditContext context, IPdfService pdfSrv, IDropDownService dropSrv)
        //{
        //    this.context = context;
        //    _pdfSrv = pdfSrv;
        //    _dropSrv = dropSrv;
        //}

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ListGroupsRolesSummary> data = context.ListGroupsRolesSummaries.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ListGroupsRolesSummaryController).ToLower()].DisplayNames;

        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            {nameof(ListGroupsRolesSummary.GroupName)  .ToLower()     , _dropSrv.GetGroupNameDropDown().ToDynamicList() },
        //            {nameof(ListGroupsRolesSummary.RoleName)   .ToLower()         , _dropSrv.GetRoleAudNameDropDown().ToDynamicList() },

        //        };
        //    }
        //    ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListGroupsRolesSummaryController).ToLower()].SkipList;

        //    KendoDataDesc<ListGroupsRolesSummary> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    Microsoft.EntityFrameworkCore.DbSet<ListGroupsRolesSummary> data = context.ListGroupsRolesSummaries;
        //    byte[] bytes = await data.ExportToCSV<ListGroupsRolesSummary, GenericCsvClassMapper<ListGroupsRolesSummary, ListGroupsRolesSummaryController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}


        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ListGroupsRolesSummaryController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListGroupsRolesSummaryController).ToLower()].SkipList;
        //    List<ListGroupsRolesSummary> data = context.ListGroupsRolesSummaries.CallData(req).Data.ToList();
        //    ViewData["title"] = "List Of Groups Roles Summary";
        //    ViewData["desc"] = "This Report presents all groups with their roles";
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

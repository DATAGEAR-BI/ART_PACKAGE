using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.Audit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAUDIT
{

    public class ListOfUsersAndGroupsRoleController : BaseReportController<IGridConstructor<IBaseRepo<ArtAuditContext, ListOfUsersAndGroupsRole>, ArtAuditContext, ListOfUsersAndGroupsRole>, IBaseRepo<ArtAuditContext, ListOfUsersAndGroupsRole>, ArtAuditContext, ListOfUsersAndGroupsRole>
    {
        public ListOfUsersAndGroupsRoleController(IGridConstructor<IBaseRepo<ArtAuditContext, ListOfUsersAndGroupsRole>, ArtAuditContext, ListOfUsersAndGroupsRole> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //private readonly ArtAuditContext context;
        //private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        //private readonly IPdfService _pdfSrv;
        //private readonly IDropDownService dropDownService;

        //public ListOfUsersAndGroupsRoleController(ArtAuditContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, IDropDownService dropDownService)
        //{
        //    _env = env; _pdfSrv = pdfSrv; context = _context;
        //    this.dropDownService = dropDownService;
        //}

        ////private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ListOfUsersAndGroupsRole> data = context.ListOfUsersAndGroupsRoles.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ListOfUsersAndGroupsRoleController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            { "UserName".ToLower(),dropDownService.GetUserNameDropDown().ToDynamicList() },
        //            { "MemberOfGroup".ToLower(),dropDownService.GetGroupAudNameDropDown().ToDynamicList() },
        //            { "RoleOfGroup".ToLower(),dropDownService.GetRoleAudNameDropDown().ToDynamicList() },
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfUsersAndGroupsRoleController).ToLower()].SkipList;
        //    }


        //    KendoDataDesc<ListOfUsersAndGroupsRole> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        ////public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        ////{
        ////    Microsoft.EntityFrameworkCore.DbSet<ListOfUsersAndGroupsRole> data = context.ListOfUsersAndGroupsRoles;
        ////    byte[] bytes = await data.ExportToCSV<ListOfUsersAndGroupsRole, GenericCsvClassMapper<ListOfUsersAndGroupsRole, ListOfUsersAndGroupsRoleController>>(para.Req);
        ////    return File(bytes, "text/csv");
        ////}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ListOfUsersAndGroupsRoleController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfUsersAndGroupsRoleController).ToLower()].SkipList;
        //    List<ListOfUsersAndGroupsRole> data = context.ListOfUsersAndGroupsRoles.CallData(req).Data.ToList();
        //    ViewData["title"] = "List Of Users Groups Roles";
        //    ViewData["desc"] = "This Report presents all users with their groups and roles of their groups";
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

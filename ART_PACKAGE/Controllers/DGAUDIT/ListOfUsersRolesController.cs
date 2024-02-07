using ART_PACKAGE.Helpers.Grid;
using Data.Data.Audit;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAUDIT
{

    public class ListOfUsersRolesController : BaseReportController<IGridConstructor<IBaseRepo<ArtAuditContext, ListOfUsersRole>, ArtAuditContext, ListOfUsersRole>, IBaseRepo<ArtAuditContext, ListOfUsersRole>, ArtAuditContext, ListOfUsersRole>
    {
        public ListOfUsersRolesController(IGridConstructor<IBaseRepo<ArtAuditContext, ListOfUsersRole>, ArtAuditContext, ListOfUsersRole> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //private readonly ArtAuditContext context;
        //private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        //private readonly IPdfService _pdfSrv;
        //private readonly IDropDownService dropDownService;
        //public ListOfUsersRolesController(ArtAuditContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, IDropDownService dropDownService)
        //{
        //    _env = env; _pdfSrv = pdfSrv; context = _context;
        //    this.dropDownService = dropDownService;
        //}

        ////private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ListOfUsersRole> data = context.ListOfUsersRoles.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ListOfUsersRolesController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            { "UserName".ToLower(),dropDownService.GetUserNameDropDown().ToDynamicList() },
        //            { "UserRole".ToLower(),dropDownService.GetRoleAudNameDropDown().ToDynamicList() },
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfUsersRolesController).ToLower()].SkipList;
        //    }


        //    KendoDataDesc<ListOfUsersRole> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        ////    Microsoft.EntityFrameworkCore.DbSet<ListOfUsersRole> data = context.ListOfUsersRoles;
        ////    byte[] bytes = await data.ExportToCSV<ListOfUsersRole, GenericCsvClassMapper<ListOfUsersRole, ListOfUsersRolesController>>(para.Req);
        ////    return File(bytes, "text/csv");
        ////}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ListOfUsersRolesController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfUsersRolesController).ToLower()].SkipList;
        //    List<ListOfUsersRole> data = context.ListOfUsersRoles.CallData(req).Data.ToList();
        //    ViewData["title"] = "List Of Users Roles";
        //    ViewData["desc"] = "This Report presents all users with their roles";
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

using ART_PACKAGE.Helpers.Grid;
using Data.Data.Audit;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAUDIT
{

    public class ListOfUserController : BaseReportController<IGridConstructor<IBaseRepo<ArtAuditContext, ListOfUser>, ArtAuditContext, ListOfUser>, IBaseRepo<ArtAuditContext, ListOfUser>, ArtAuditContext, ListOfUser>
    {
        public ListOfUserController(IGridConstructor<IBaseRepo<ArtAuditContext, ListOfUser>, ArtAuditContext, ListOfUser> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //private readonly ArtAuditContext context;
        //private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        //private readonly IPdfService _pdfSrv;
        //private readonly IDropDownService dropDownService;
        //public ListOfUserController(ArtAuditContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, IDropDownService dropDownService)
        //{
        //    _env = env; _pdfSrv = pdfSrv; context = _context;
        //    this.dropDownService = dropDownService;
        //}

        ////private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ListOfUser> data = context.ListOfUsers.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ListOfUserController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            { "UserName".ToLower(),dropDownService.GetUserNameDropDown().ToDynamicList() },
        //            { "UserType".ToLower(),dropDownService.GetUserTypeDropDown().ToDynamicList() },
        //            { "CreatedBy".ToLower(),dropDownService.GetUserAudNameDropDown().ToDynamicList() },
        //            { "LastUpdatedBy".ToLower(),dropDownService.GetUserAudNameDropDown().ToDynamicList() },
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfUserController).ToLower()].SkipList;
        //    }


        //    KendoDataDesc<ListOfUser> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        ////    Microsoft.EntityFrameworkCore.DbSet<ListOfUser> data = context.ListOfUsers;
        ////    byte[] bytes = await data.ExportToCSV<ListOfUser, GenericCsvClassMapper<ListOfUser, ListOfUserController>>(para.Req);
        ////    return File(bytes, "text/csv");
        ////}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ListOfUserController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfUserController).ToLower()].SkipList;
        //    List<ListOfUser> data = context.ListOfUsers.CallData(req).Data.ToList();
        //    ViewData["title"] = "List Of Users Report";
        //    ViewData["desc"] = "This Report presents all users with the related information as below";
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

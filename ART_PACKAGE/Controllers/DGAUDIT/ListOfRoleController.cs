﻿using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.Audit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAUDIT
{

    public class ListOfRoleController : BaseReportController<IGridConstructor<IBaseRepo<ArtAuditContext, ListOfRole>, ArtAuditContext, ListOfRole>, IBaseRepo<ArtAuditContext, ListOfRole>, ArtAuditContext, ListOfRole>
    {
        public ListOfRoleController(IGridConstructor<IBaseRepo<ArtAuditContext, ListOfRole>, ArtAuditContext, ListOfRole> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //private readonly ArtAuditContext context;
        //private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        //private readonly IPdfService _pdfSrv;
        //private readonly IDropDownService dropDownService;
        //public ListOfRoleController(ArtAuditContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, IDropDownService dropDownService)
        //{
        //    _env = env; _pdfSrv = pdfSrv; context = _context;
        //    this.dropDownService = dropDownService;
        //}

        ////private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ListOfRole> data = context.ListOfRoles.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ListOfRoleController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            { "RoleName".ToLower(),dropDownService.GetRoleNameDropDown().ToDynamicList() },
        //            { "RoleType".ToLower(),dropDownService.GetRoleTypeDropDown().ToDynamicList() },
        //            { "CreatedBy".ToLower(),dropDownService.GetUserAudNameDropDown().ToDynamicList() },
        //            { "LastUpdatedBy".ToLower(),dropDownService.GetUserAudNameDropDown().ToDynamicList() },
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfRoleController).ToLower()].SkipList;
        //    }


        //    KendoDataDesc<ListOfRole> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        ////    Microsoft.EntityFrameworkCore.DbSet<ListOfRole> data = context.ListOfRoles;
        ////    byte[] bytes = await data.ExportToCSV<ListOfRole, GenericCsvClassMapper<ListOfRole, ListOfRoleController>>(para.Req);
        ////    return File(bytes, "text/csv");
        ////}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ListOfRoleController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfRoleController).ToLower()].SkipList;
        //    List<ListOfRole> data = context.ListOfRoles.CallData(req).Data.ToList();
        //    ViewData["title"] = "List Of Roles Report";
        //    ViewData["desc"] = "This Report presents all roles with the related information as below";
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

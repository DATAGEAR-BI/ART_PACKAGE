using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.Audit;
using Data.DGECM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    [Authorize(Roles = "ListOfUsersGroup")]
    public class ListOfUsersGroupController : Controller
    {

        private readonly ArtAuditContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly DGECMContext db;
        private readonly IDropDownService dropDownService;
        public ListOfUsersGroupController(ArtAuditContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, DGECMContext db, IDropDownService dropDownService)
        {
            _env = env; _pdfSrv = pdfSrv; context = _context;
            this.db = db;
            this.dropDownService = dropDownService;
        }

        //private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListOfUsersGroup> data = context.ListOfUsersGroups.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ListOfUsersGroupController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    { "UserName".ToLower(),dropDownService.GetUserNameDropDown().ToDynamicList() },
                    { "MemberOfGroup".ToLower(),dropDownService.GetGroupAudNameDropDown().ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfUsersGroupController).ToLower()].SkipList;
            }


            KendoDataDesc<ListOfUsersGroup> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }
        //public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        //{
        //    Microsoft.EntityFrameworkCore.DbSet<ListOfUsersGroup> data = context.ListOfUsersGroups;
        //    byte[] bytes = await data.ExportToCSV<ListOfUsersGroup, GenericCsvClassMapper<ListOfUsersGroup, ListOfUsersGroupController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ListOfUsersGroupController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfUsersGroupController).ToLower()].SkipList;
            List<ListOfUsersGroup> data = context.ListOfUsersGroups.CallData(req).Data.ToList();
            ViewData["title"] = "List Of Users Groups";
            ViewData["desc"] = "This Report presents all users with their groups";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.SASAudit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ART_PACKAGE.Controllers.SASAUDIT
{

    public class ListAccessRightPerRoleController : Controller
    {

        private readonly ArtSasAuditContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService dropDownService;
        public ListAccessRightPerRoleController(ArtSasAuditContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, IDropDownService dropDownService)
        {
            _env = env; _pdfSrv = pdfSrv; context = _context;
            this.dropDownService = dropDownService;
        }

        //private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListAccessRightPerRole> data = context.ListAccessRightPerRoles.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ListAccessRightPerRoleController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListAccessRightPerRoleController).ToLower()].SkipList;
            }


            KendoDataDesc<ListAccessRightPerRole> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    Microsoft.EntityFrameworkCore.DbSet<ListOfUser> data = context.ListOfUsers;
        //    byte[] bytes = await data.ExportToCSV<ListOfUser, GenericCsvClassMapper<ListOfUser, ListOfUserController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ListAccessRightPerRoleController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListAccessRightPerRoleController).ToLower()].SkipList;
            List<ListAccessRightPerRole> data = context.ListAccessRightPerRoles.CallData(req).Data.ToList();
            ViewData["title"] = "List Access Right Per Role Report";
            ViewData["desc"] = "";
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

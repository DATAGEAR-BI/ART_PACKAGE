using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using Data.DGECM;
using ART_PACKAGE.Helpers.DropDown;

namespace ART_PACKAGE.Controllers
{
    [AllowAnonymous]
    public class ListOfUserController : Controller
    {

        private readonly AuthContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly DGECMContext db;
        private readonly IDropDownService dropDownService;
        public ListOfUserController(AuthContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, DGECMContext db, IDropDownService dropDownService)
        {
            this._env = env; _pdfSrv = pdfSrv; context = _context;
            this.db = db;
            this.dropDownService = dropDownService;
        }

        //private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListOfUser> data = context.ListOfUsers.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ListOfUserController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    { "UserName".ToLower(),dropDownService.GetUserNameDropDown().ToDynamicList() },
                    { "UserType".ToLower(),dropDownService.GetUserTypeDropDown().ToDynamicList() },
                    { "CreatedBy".ToLower(),dropDownService.GetUserAudNameDropDown().ToDynamicList() },
                    { "LastUpdatedBy".ToLower(),dropDownService.GetUserAudNameDropDown().ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfUserController).ToLower()].SkipList;
            }


            var Data = data.CallData<ListOfUser>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            var data = context.ListOfUsers;
            var bytes = await data.ExportToCSV<ListOfUser, GenericCsvClassMapper<ListOfUser, ListOfUserController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(ListOfUserController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfUserController).ToLower()].SkipList;
            var data = context.ListOfUsers.CallData<ListOfUser>(req).Data.ToList();
            ViewData["title"] = "List Of Users Report";
            ViewData["desc"] = "This Report presents all users with the related information as below";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

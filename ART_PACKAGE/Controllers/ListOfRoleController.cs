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

namespace ART_PACKAGE.Controllers
{
    [AllowAnonymous]
    public class ListOfRoleController : Controller
    {

        private readonly AuthContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly DGECMContext db;

        public ListOfRoleController(AuthContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, DGECMContext db)
        {
            this._env = env; _pdfSrv = pdfSrv; context = _context;
            this.db = db;
        }

        //private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListOfRole> data = context.ListOfRoles.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ListOfRoleController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfRoleController).ToLower()].SkipList;
            }


            var Data = data.CallData<ListOfRole>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = context.ListOfRoles;
            var bytes = await data.ExportToCSV<ListOfRole, GenericCsvClassMapper<ListOfRole, ListOfRoleController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(ListOfRoleController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfRoleController).ToLower()].SkipList;
            var data = context.ListOfRoles.CallData<ListOfRole>(req).Data.ToList();
            ViewData["title"] = "";
            ViewData["desc"] = "";
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

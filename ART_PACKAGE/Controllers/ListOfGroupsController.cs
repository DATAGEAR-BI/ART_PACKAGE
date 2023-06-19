using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Services.Pdf;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    public class ListOfGroupsController : Controller
    {
        private readonly AuthContext context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService dropDownService;
        public ListOfGroupsController(AuthContext context, IPdfService pdfSrv, IDropDownService dropDownService)
        {
            this.context = context;
            _pdfSrv = pdfSrv;
            this.dropDownService = dropDownService;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListOfGroup> data = context.ListOfGroups.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ListOfGroupsController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    { "GroupName".ToLower(),dropDownService.GetGroupNameDropDown().ToDynamicList() },
                    { "GroupType".ToLower(),dropDownService.GetGroupTypeDropDown().ToDynamicList() },
                    { "CreatedBy".ToLower(),dropDownService.GetUserAudNameDropDown().ToDynamicList() },
                    { "LastUpdatedBy".ToLower(),dropDownService.GetUserAudNameDropDown().ToDynamicList() },

                };
            }
            ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfGroupsController).ToLower()].SkipList;

            var Data = data.CallData<ListOfGroup>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = context.ListOfGroups;
            var bytes = await data.ExportToCSV<ListOfGroup, GenericCsvClassMapper<ListOfGroup, ListOfGroupsController>>(para.Req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(ListOfGroupsController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfGroupsController).ToLower()].SkipList;
            var data = context.ListOfGroups.CallData<ListOfGroup>(req).Data.ToList();
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

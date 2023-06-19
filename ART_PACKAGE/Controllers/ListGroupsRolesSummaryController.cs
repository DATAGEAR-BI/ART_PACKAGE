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
    public class ListGroupsRolesSummaryController : Controller
    {
        private readonly AuthContext context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;
        public ListGroupsRolesSummaryController(AuthContext context, IPdfService pdfSrv)
        {
            this.context = context;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListGroupsRolesSummary> data = context.ListGroupsRolesSummaries.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ListGroupsRolesSummaryController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {nameof(ListGroupsRolesSummary.GroupName)  .ToLower()     , _dropSrv.GetGroupNameDropDown().ToDynamicList() },
                    {nameof(ListGroupsRolesSummary.RoleName)   .ToLower()         , _dropSrv.GetRoleAudNameDropDown().ToDynamicList() },

                };
            }
            ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListGroupsRolesSummaryController).ToLower()].SkipList;

            var Data = data.CallData<ListGroupsRolesSummary>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = context.ListGroupsRolesSummaries;
            var bytes = await data.ExportToCSV<ListGroupsRolesSummary, GenericCsvClassMapper<ListGroupsRolesSummary, ListGroupsRolesSummaryController>>(para.Req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(ListGroupsRolesSummaryController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListGroupsRolesSummaryController).ToLower()].SkipList;
            var data = context.ListGroupsRolesSummaries.CallData<ListGroupsRolesSummary>(req).Data.ToList();
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

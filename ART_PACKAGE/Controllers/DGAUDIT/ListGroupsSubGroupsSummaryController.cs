using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.Audit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.DGAUDIT
{

    public class ListGroupsSubGroupsSummaryController : Controller
    {

        private readonly ArtAuditContext context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;
        public ListGroupsSubGroupsSummaryController(ArtAuditContext context, IPdfService pdfSrv, IDropDownService dropSrv)
        {
            this.context = context;
            _pdfSrv = pdfSrv;
            _dropSrv = dropSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListGroupsSubGroupsSummary> data = context.ListGroupsSubGroupsSummaries.AsQueryable();

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ListGroupsSubGroupsSummaryController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {nameof(ListGroupsSubGroupsSummary.GroupName)     .ToLower()      , _dropSrv.GetGroupNameDropDown().ToDynamicList() },
                    {nameof(ListGroupsSubGroupsSummary.SubGroupName)  .ToLower()      , _dropSrv.GetGroupAudNameDropDown().ToDynamicList() },

                };
            }
            ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListGroupsSubGroupsSummaryController).ToLower()].SkipList;

            KendoDataDesc<ListGroupsSubGroupsSummary> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            Microsoft.EntityFrameworkCore.DbSet<ListGroupsSubGroupsSummary> data = context.ListGroupsSubGroupsSummaries;
            byte[] bytes = await data.ExportToCSV<ListGroupsSubGroupsSummary, GenericCsvClassMapper<ListGroupsSubGroupsSummary, ListGroupsSubGroupsSummaryController>>(para.Req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ListGroupsSubGroupsSummaryController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListGroupsSubGroupsSummaryController).ToLower()].SkipList;
            List<ListGroupsSubGroupsSummary> data = context.ListGroupsSubGroupsSummaries.CallData(req).Data.ToList();
            ViewData["title"] = "List Of Groups Sub Groups Summary";
            ViewData["desc"] = "This Report presents all groups with their sub-groups";
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

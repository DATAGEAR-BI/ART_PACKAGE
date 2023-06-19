using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Services.Pdf;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers
{
    public class ListGroupsSubGroupsSummaryController : Controller
    {

        private readonly AuthContext context;
        private readonly IPdfService _pdfSrv;
        public ListGroupsSubGroupsSummaryController(AuthContext context, IPdfService pdfSrv)
        {
            this.context = context;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListGroupsSubGroupsSummary> data = context.ListGroupsSubGroupsSummaries.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ListGroupsSubGroupsSummaryController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    ////{"CaseType".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.CaseType).Distinct().ToDynamicList() },
                    ////{"CaseStatus".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.CaseStatus).Distinct().ToDynamicList() },
                    ////{"Priority".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.Priority).Distinct().ToDynamicList() },
                    ////{"TransactionDirection".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.TransactionDirection).Distinct().ToDynamicList() },
                    ////{"TransactionType".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.TransactionType).Distinct().ToDynamicList() },
                    ////{"UpdateUserId".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.UpdateUserId).Distinct().ToDynamicList() },
                    ////{"InvestrUserId".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.InvestrUserId).Distinct().ToDynamicList() },

                    //{"CaseType".ToLower(),db.RefTableVals.Where(a => a.RefTableName.StartsWith("RT_CASE_TYPE")).Select(x=>x.ValDesc).ToDynamicList() },
                    //{"CaseStatus".ToLower(),db.RefTableVals
                    //    .Where(a => a.RefTableName.StartsWith("RT_CASE_STATUS"))
                    //    //.Where(b => b.ValCd.Equals("SC") || b.ValCd.Equals("ST"))
                    //    //.Where(b => b.DisplayOrdrNo==0)
                    //    .Select(x=>x.ValDesc).ToDynamicList() },
                    //{"Priority".ToLower(),db.RefTableVals
                    //    .Where(a => a.RefTableName.StartsWith("X_RT_PRIORITY"))
                    //    .Where(b => b.ValDesc.Equals("High") || b.ValDesc.Equals("Low") || b.ValDesc.Equals("Medium")).Select(x=>x.ValDesc).ToDynamicList() }

                };
            }
            ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListGroupsSubGroupsSummaryController).ToLower()].SkipList;

            var Data = data.CallData<ListGroupsSubGroupsSummary>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = context.ListGroupsSubGroupsSummaries;
            var bytes = await data.ExportToCSV<ListGroupsSubGroupsSummary, GenericCsvClassMapper<ListGroupsSubGroupsSummary, ListGroupsSubGroupsSummaryController>>(para.Req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(ListGroupsSubGroupsSummaryController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListGroupsSubGroupsSummaryController).ToLower()].SkipList;
            var data = context.ListGroupsSubGroupsSummaries.CallData<ListGroupsSubGroupsSummary>(req).Data.ToList();
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

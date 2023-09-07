using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.ECM;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    public class AlertedEntitiesController : Controller
    {
        private readonly EcmContext context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;
        public AlertedEntitiesController(EcmContext context, IPdfService pdfSrv, IDropDownService dropSrv)
        {
            this.context = context;
            _pdfSrv = pdfSrv;
            _dropSrv = dropSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtAlertedEntity> data = context.ArtAlertedEntities.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(AlertedEntitiesController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    ////{"CaseType".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.CaseType).Distinct().ToDynamicList() },
                    ////{"CaseStatus".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.CaseStatus).Distinct().ToDynamicList() },
                    ////{"Priority".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.Priority).Distinct().ToDynamicList() },
                    ////{"TransactionDirection".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.TransactionDirection).Distinct().ToDynamicList() },
                    ////{"TransactionType".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.TransactionType).Distinct().ToDynamicList() },
                    ////{"UpdateUserId".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.UpdateUserId).Distinct().ToDynamicList() },
                    ////{"InvestrUserId".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.InvestrUserId).Distinct().ToDynamicList() },
                    {"CaseType".ToLower(),_dropSrv.GetCaseTypeDropDown().ToDynamicList() },
                    {"CaseStatus".ToLower(),_dropSrv.GetCaseStatusDropDown().ToDynamicList()},
                    {"Priority".ToLower(),_dropSrv.GetPriorityDropDown().ToDynamicList() }
                };
            }
            ColumnsToSkip = ReportsConfig.CONFIG[nameof(AlertedEntitiesController).ToLower()].SkipList;

            KendoDataDesc<ArtAlertedEntity> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);

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
            Microsoft.EntityFrameworkCore.DbSet<ArtAlertedEntity> data = context.ArtAlertedEntities;
            byte[] bytes = await data.ExportToCSV<ArtAlertedEntity, GenericCsvClassMapper<ArtAlertedEntity, AlertedEntitiesController>>(para.Req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(AlertedEntitiesController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AlertedEntitiesController).ToLower()].SkipList;
            List<ArtAlertedEntity> data = context.ArtAlertedEntities.CallData(req).Data.ToList();
            ViewData["title"] = "Alerted Entities Report";
            ViewData["desc"] = "This report presents all sanction cases with the related information on case level as below";
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

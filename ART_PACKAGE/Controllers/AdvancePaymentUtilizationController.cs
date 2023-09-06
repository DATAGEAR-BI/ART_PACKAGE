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

namespace ART_PACKAGE.Controllers
{

    //[Authorize(Policy = "Licensed" , Roles = "Activity")]


    public class AdvancePaymentUtilizationController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;


        public AdvancePaymentUtilizationController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }


        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiAdvancePaymentUtilizationReport> data = fti.ArtTiAdvancePaymentUtilizationReports.AsQueryable();


            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {


                DisplayNames = ReportsConfig.CONFIG[nameof(AdvancePaymentUtilizationController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"PrincipalParty".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.PrincipalParty).Distinct()    .Where(x=> x != null)    .ToDynamicList() },
                {"NonPrincipalParty".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.NonPrincipalParty).Distinct()                .Where(x=> x != null)    .ToDynamicList() },
                {"AdvCurrency".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.AdvCurrency).Distinct()      .Where(x=> x != null)    .ToDynamicList() },
                {"UtilizationCurrency".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.UtilizationCurrency).Distinct()          .Where(x=> x != null)    .ToDynamicList() },
                {"Branch".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.Branch).Distinct()        .Where(x=> x != null)    .ToDynamicList() },
                {"AdvReference".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.AdvReference).Distinct()  .Where(x=> x != null)    .ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(AdvancePaymentUtilizationController).ToLower()].SkipList;
            }
            var Data = data.CallData<ArtTiAdvancePaymentUtilizationReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {
                },
                reportname = "Advance Payment Utilization"
            };


            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            var data = fti.ArtTiAdvancePaymentUtilizationReports;
            var bytes = await data.ExportToCSV<ArtTiAdvancePaymentUtilizationReport, GenericCsvClassMapper<ArtTiAdvancePaymentUtilizationReport, AdvancePaymentUtilizationController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var data = fti.ArtTiAdvancePaymentUtilizationReports.CallData<ArtTiAdvancePaymentUtilizationReport>(req).Data.ToList();
            ViewData["title"] = "Advance Payment Utilization Report";
            ViewData["desc"] = "";
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(AdvancePaymentUtilizationController).ToLower()].SkipList;

            var DisplayNames = ReportsConfig.CONFIG[nameof(AdvancePaymentUtilizationController).ToLower()].DisplayNames;
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 9
                                                   , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");

        }
    }
}

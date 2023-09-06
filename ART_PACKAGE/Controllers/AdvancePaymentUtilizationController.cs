using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{

    //[Authorize(Policy = "Licensed" , Roles = "Activity")]


    public class AdvancePaymentUtilizationController : Controller
    {
        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;


        public AdvancePaymentUtilizationController(IPdfService pdfSrv, FTIContext fti)
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
            KendoDataDesc<ArtTiAdvancePaymentUtilizationReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            Microsoft.EntityFrameworkCore.DbSet<ArtTiAdvancePaymentUtilizationReport> data = fti.ArtTiAdvancePaymentUtilizationReports;
            byte[] bytes = await data.ExportToCSV<ArtTiAdvancePaymentUtilizationReport, GenericCsvClassMapper<ArtTiAdvancePaymentUtilizationReport, AdvancePaymentUtilizationController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            List<ArtTiAdvancePaymentUtilizationReport> data = fti.ArtTiAdvancePaymentUtilizationReports.CallData(req).Data.ToList();
            ViewData["title"] = "Advance Payment Utilization Report";
            ViewData["desc"] = "";
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AdvancePaymentUtilizationController).ToLower()].SkipList;

            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(AdvancePaymentUtilizationController).ToLower()].DisplayNames;
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 9
                                                   , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");

        }
    }
}

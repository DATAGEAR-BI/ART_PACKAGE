using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "OurChargesByCustomer")]


    public class OurChargesByCustomerController : Controller
    {
        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;

        public OurChargesByCustomerController(IPdfService pdfSrv, FTIContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiChargesByCustReport> data = fti.ArtTiChargesByCustReports.AsQueryable();
            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(OurChargesByCustomerController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"Hvbad1".ToLower(),fti.ArtTiChargesByCustReports.Select(x=>x.Hvbad1).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Gfcun".ToLower(),fti.ArtTiChargesByCustReports.Select(x=>x.Gfcun).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"Longname".ToLower(),fti.ArtTiChargesByCustReports.Select(x=>x.Longname).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"MasterRef".ToLower(),fti.ArtTiChargesByCustReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(OurChargesByCustomerController).ToLower()].SkipList;

            }
            KendoDataDesc<ArtTiChargesByCustReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {
                },
                reportname = "OurChargesByCustomer"
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




        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            List<ArtTiChargesByCustReport> data = fti.ArtTiChargesByCustReports.CallData(req).Data.ToList();
            ViewData["title"] = "Our Charges By Customer";
            ViewData["desc"] = "This report produces a list of charges by the customer paying the charges";
            Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(OurChargesByCustomerController).ToLower()].DisplayNames;
            List<string> columnsToPrint = new() {
                nameof(ArtTiChargesByCustReport.MasterRef)
               ,nameof(ArtTiChargesByCustReport.Gfcun)
               ,nameof(ArtTiChargesByCustReport.Hvbad1)
               ,nameof(ArtTiChargesByCustReport.TotoalClaimedChgDue)
               ,nameof(ArtTiChargesByCustReport.TotoalPaidChgDue)
               ,nameof(ArtTiChargesByCustReport.TotoalOutstandingChgDue)
               ,nameof(ArtTiChargesByCustReport.TotoalWaivedChgDue)   };
            List<string> ColumnsToSkip = typeof(ArtTiChargesByCustReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

            if (req.Group is not null && req.Group.Count != 0)
            {
                byte[] pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, ControllerContext
                                                   , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
            else
            {
                byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 7
                                                   , User.Identity.Name, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
        }
    }
}

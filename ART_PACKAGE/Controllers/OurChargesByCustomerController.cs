using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;

namespace ART_PACKAGE.Controllers {
    //[Authorize(Policy = "Licensed" , Roles = "OurChargesByCustomer")]

    
    public class OurChargesByCustomerController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;

        public OurChargesByCustomerController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiChargesByCustReport> data = fti.ArtTiChargesByCustReports.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
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
            var Data = data.CallData<ArtTiChargesByCustReport>(request, DropDownColumn, DisplayNames: DisplayNames);
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



        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            var data = fti.ArtTiChargesByCustReports;
            var bytes = await data.ExportToCSV<ArtTiChargesByCustReport, GenericCsvClassMapper<ArtTiChargesByCustReport, OurChargesByCustomerController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var data = fti.ArtTiChargesByCustReports.CallData<ArtTiChargesByCustReport>(req).Data.ToList();
            ViewData["title"] = "Our Charges By Customer";
            ViewData["desc"] = "This report produces a list of charges by the customer paying the charges";
            var DisplayNames = ReportsConfig.CONFIG[nameof(OurChargesByCustomerController).ToLower()].DisplayNames;
            var columnsToPrint = new List<string>() {
                nameof(ArtTiChargesByCustReport.MasterRef)
               ,nameof(ArtTiChargesByCustReport.Gfcun) 
               ,nameof(ArtTiChargesByCustReport.Hvbad1) 
               ,nameof(ArtTiChargesByCustReport.TotoalClaimedChgDue) 
               ,nameof(ArtTiChargesByCustReport.TotoalPaidChgDue)
               ,nameof(ArtTiChargesByCustReport.TotoalOutstandingChgDue)
               ,nameof(ArtTiChargesByCustReport.TotoalWaivedChgDue)   };
            var ColumnsToSkip = typeof(ArtTiChargesByCustReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

            if (req.Group is not null && req.Group.Count != 0)
            {
                var pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, this.ControllerContext
                                                   , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
            else
            {
                var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 7
                                                   , User.Identity.Name, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
        }
    }
}

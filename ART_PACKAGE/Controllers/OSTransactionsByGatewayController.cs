using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;

namespace ART_PACKAGE.Controllers { 
    //[Authorize(Policy = "Licensed" , Roles = "OSTransactionsByGateway")]

    public class OSTransactionsByGatewayController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;

        public OSTransactionsByGatewayController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiOsTransByGatewayReport> data = fti.ArtTiOsTransByGatewayReports.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {

                DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsByGatewayController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"Fullname".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Fullname).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Address1".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Address1).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Sovalue".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"MasterRef".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Partptd".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Partptd).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Revolving".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Revolving).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Outstccy".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Ccy".ToLower(),fti.ArtTiOsTransByGatewayReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSTransactionsByGatewayController).ToLower()].SkipList;
            }
            var Data = data.CallData<ArtTiOsTransByGatewayReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {


                },
                reportname = "OSTransactionsByGateway"
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
            var data = fti.ArtTiOsTransByGatewayReports;
            var bytes = await data.ExportToCSV<ArtTiOsTransByGatewayReport, GenericCsvClassMapper<ArtTiOsTransByGatewayReport, OSTransactionsByGatewayController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var data = fti.ArtTiOsTransByGatewayReports.CallData<ArtTiOsTransByGatewayReport>(req).Data.ToList();
            ViewData["title"] = "OS Transactions By Gateway Report";
            ViewData["desc"] = "This report produces information for master records that are not yet booked off or cancelled for only those transactions relating to customer gateway customers";

            var DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsByGatewayController).ToLower()].DisplayNames;
            var columnsToPrint = new List<string>() {nameof(ArtTiOsTransByGatewayReport.MasterRef)
                , nameof(ArtTiOsTransByGatewayReport.CtrctDate) ,
            nameof(ArtTiOsTransByGatewayReport.ExpiryDat) , nameof(ArtTiOsTransByGatewayReport.Amount) , nameof(ArtTiOsTransByGatewayReport.Ccy),
            nameof(ArtTiOsTransByGatewayReport.Outstamt),nameof(ArtTiOsTransByGatewayReport.Outstccy)   };
            var ColumnsToSkip = typeof(ArtTiOsTransByGatewayReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

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

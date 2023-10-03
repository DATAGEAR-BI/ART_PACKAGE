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
    //////[Authorize(Policy = "Licensed" , Roles = "PeriodicCHRGSPayment")]


    public class PeriodicCHRGSPaymentController : Controller
    {
        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;



        public PeriodicCHRGSPaymentController(IPdfService pdfSrv, FTIContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiPeriodicChrgsPayReport> data = fti.ArtTiPeriodicChrgsPayReports.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(PeriodicCHRGSPaymentController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"Fullname".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.Fullname).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Sovalue".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Descr".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.Descr).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Descr1".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.Descr1).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"MasterRef".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"PcpAddress1".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.PcpAddress1).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Payrec".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.Payrec).Distinct().Where(x=> x != null ).ToDynamicList() },
                //{"AdvArr".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.adv).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Outstccy".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"NpcpAddress1".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.NpcpAddress1).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"SchCcy".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.SchCcy).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"AccrueCcy".ToLower(),fti.ArtTiPeriodicChrgsPayReports.Select(x=>x.AccrueCcy).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(PeriodicCHRGSPaymentController).ToLower()].SkipList;

            }
            KendoDataDesc<ArtTiPeriodicChrgsPayReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {


                },
                reportname = "PeriodicCHRGSPayment"
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
            List<ArtTiPeriodicChrgsPayReport> data = fti.ArtTiPeriodicChrgsPayReports.CallData(req).Data.ToList();
            ViewData["title"] = "Periodic CHRGs Payment Report";
            ViewData["desc"] = "This report produces all transactions which have a Pay Charges event within a period that you can specify";

            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(PeriodicCHRGSPaymentController).ToLower()].DisplayNames;
            List<string> columnsToPrint = new()
            { nameof(ArtTiPeriodicChrgsPayReport.MasterRef)
            , nameof(ArtTiPeriodicChrgsPayReport.Sovalue)
            , nameof(ArtTiPeriodicChrgsPayReport.NpcpAddress1)
            , nameof(ArtTiPeriodicChrgsPayReport.PcpAddress1)
            , nameof(ArtTiPeriodicChrgsPayReport.Descr1)
            , nameof(ArtTiPeriodicChrgsPayReport.SchAmt)
            , nameof(ArtTiPeriodicChrgsPayReport.SchCcy)
            };
            List<string> ColumnsToSkip = typeof(ArtTiPeriodicChrgsPayReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

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

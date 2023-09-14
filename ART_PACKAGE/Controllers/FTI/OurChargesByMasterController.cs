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
    //[Authorize(Policy = "Licensed" , Roles = "OurChargesByMaster")]


    public class OurChargesByMasterController : Controller
    {
        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;

        public OurChargesByMasterController(IPdfService pdfSrv, FTIContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiChargesByMasterReport> data = fti.ArtTiChargesByMasterReports.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {

                DisplayNames = ReportsConfig.CONFIG[nameof(OurChargesByMasterController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
               {"Hvbad1".ToLower(),fti.ArtTiChargesByMasterReports.Select(x=>x.Hvbad1).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"Longname".ToLower(),fti.ArtTiChargesByMasterReports.Select(x=>x.Longname).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"MasterRef".ToLower(),fti.ArtTiChargesByMasterReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(OurChargesByMasterController).ToLower()].SkipList;

            }

            KendoDataDesc<ArtTiChargesByMasterReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {


                },
                reportname = "OurChargesByMaster"
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }
        public IActionResult Index()
        {
            string defaultGrouping = JsonConvert.SerializeObject(new
            {
                field = nameof(ArtTiChargesByMasterReport.Longname),
                aggregates = new List<dynamic>
                {
                    new
                    {
                        field = "TotoalPaidChgDue",
                        aggregate = GridAggregateType.sum.ToString()
                    },new
                    {
                        field = "TotoalClaimedChgDue",
                        aggregate = GridAggregateType.sum.ToString()
                    },new
                    {
                        field = "TotoalOutstandingChgDue",
                        aggregate = GridAggregateType.sum.ToString()
                    },new
                    {
                        field = "TotoalWaivedChgDue",
                        aggregate = GridAggregateType.sum.ToString()
                    },
                }
            });
            ViewBag.defaultGroup = defaultGrouping;
            return View();
        }


        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            Microsoft.EntityFrameworkCore.DbSet<ArtTiChargesByMasterReport> data = fti.ArtTiChargesByMasterReports;
            byte[] bytes = await data.ExportToCSV<ArtTiChargesByMasterReport, GenericCsvClassMapper<ArtTiChargesByMasterReport, OurChargesByMasterController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            List<ArtTiChargesByMasterReport> data = fti.ArtTiChargesByMasterReports.CallData(req).Data.ToList();
            ViewData["title"] = "Our Charges by Master";
            ViewData["desc"] = "This report produces total of paid, claimed and outstanding charges for the master record";
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(OurChargesByMasterController).ToLower()].DisplayNames;
            List<string> columnsToPrint = new() {
                nameof(ArtTiChargesByMasterReport.MasterRef)
               ,nameof(ArtTiChargesByMasterReport.Hvbad1)
               ,nameof(ArtTiChargesByMasterReport.TotoalClaimedChgDue)
               ,nameof(ArtTiChargesByMasterReport.TotoalPaidChgDue)
               ,nameof(ArtTiChargesByMasterReport.TotoalOutstandingChgDue)
               ,nameof(ArtTiChargesByMasterReport.TotoalWaivedChgDue)
            };
            List<string> ColumnsToSkip = typeof(ArtTiChargesByMasterReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

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

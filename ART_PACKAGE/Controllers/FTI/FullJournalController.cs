using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;
using Data.Services.Grid;

namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "FullJournal")]


    public class FullJournalController : Controller
    {
        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;

        public FullJournalController(IPdfService pdfSrv, FTIContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult Test()
        {
            IQueryable<ArtTiFullJournalReport> d = fti.ArtTiFullJournalReports.Where(x => EF.Functions.Like(x.DataAfter, "hi"));
            return Ok(d);
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiFullJournalReport> data = fti.ArtTiFullJournalReports.AsQueryable();

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {

                DisplayNames = ReportsConfig.CONFIG[nameof(FullJournalController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                { "Username".ToLower(), fti.ArtTiFullJournalReports.Select(x=>x.Username).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "MtceType".ToLower(), fti.ArtTiFullJournalReports.Select(x=>x.MtceType).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "Area".ToLower(), fti.ArtTiFullJournalReports.Select(x => x.Area).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(FullJournalController).ToLower()].SkipList;

            }
            KendoDataDesc<ArtTiFullJournalReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {


                },
                reportname = "FullJournal"
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
            List<ArtTiFullJournalReport> data = fti.ArtTiFullJournalReports.CallData(req).Data.ToList();
            ViewData["title"] = " Full Journal Report";
            ViewData["desc"] = "This report produces changes made to Fusion Trade Innovation system tailoring or static data";
            Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(FullJournalController).ToLower()].DisplayNames;
            List<string> columnsToPrint = new() {
                nameof(ArtTiFullJournalReport.Dataitem)
               ,nameof(ArtTiFullJournalReport.Username)
               ,nameof(ArtTiFullJournalReport.Area)
               ,nameof(ArtTiFullJournalReport.MtceType)
               ,nameof(ArtTiFullJournalReport.Datetime)
               ,nameof(ArtTiFullJournalReport.DataAfter)
            };
            List<string> ColumnsToSkip = typeof(ArtTiFullJournalReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

            if (req.Group is not null && req.Group.Count != 0)
            {
                byte[] pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, ControllerContext
                                                   , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
            else
            {
                byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 6
                                                   , User.Identity.Name, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
        }
    }
}

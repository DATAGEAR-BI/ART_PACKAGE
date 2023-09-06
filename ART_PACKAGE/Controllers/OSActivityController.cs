using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Services.Pdf;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers {
    //[Authorize(Policy = "Licensed" , Roles = "OSActivity")]

    
    public class OSActivityController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;

        public OSActivityController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiOsActivityReport> data = fti.ArtTiOsActivityReports.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {

                DisplayNames = ReportsConfig.CONFIG[nameof(OSActivityController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"BranchName".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.BranchName).Distinct()     .Where(x=> x != null)          .ToDynamicList() },
                {"Team".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Team).Distinct()                 .Where(x=> x != null)          .ToDynamicList() },
                {"MasterRef".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.MasterRef).Distinct()       .Where(x=> x != null)          .ToDynamicList() },
                {"Product".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Product).Distinct()           .Where(x=> x != null)          .ToDynamicList() },
                {"Descrip".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Descrip).Distinct()           .Where(x=> x != null)          .ToDynamicList() },
                {"Address1".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Address1).Distinct()         .Where(x=> x != null)          .ToDynamicList() },
                {"Ccy".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Ccy).Distinct()                   .Where(x=> x != null)          .ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSActivityController).ToLower()].SkipList;

            }
            var Data = data.CallData<ArtTiOsActivityReport>(request, DropDownColumn, DisplayNames: DisplayNames);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {


                },
                reportname = "OSActivity"
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
            var data = fti.ArtTiOsActivityReports;
            var bytes = await data.ExportToCSV<ArtTiOsActivityReport, GenericCsvClassMapper<ArtTiOsActivityReport, OSActivityController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var data = fti.ArtTiOsActivityReports.CallData<ArtTiOsActivityReport>(req).Data.ToList();
            ViewData["title"] = "OS Activity Report";
            ViewData["desc"] = "This report produces information for master records, showing what events have been initiated for each master record and the status of the current active steps for each event within it";

            var DisplayNames = ReportsConfig.CONFIG[nameof(OSActivityController).ToLower()].DisplayNames;
            var columnsToPrint = new List<string>()
            { nameof(ArtTiOsActivityReport.MasterRef)
            , nameof(ArtTiOsActivityReport.Product)
            , nameof(ArtTiOsActivityReport.Descrip)
            , nameof(ArtTiOsActivityReport.Address1)
            , nameof(ArtTiOsActivityReport.Amount)
            , nameof(ArtTiOsActivityReport.Ccy)
            
            };
            var ColumnsToSkip = typeof(ArtTiOsActivityReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

            if (req.Group is not null && req.Group.Count != 0)
            {
                var pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, this.ControllerContext
                                                   , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
            else
            {
                var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 6
                                                   , User.Identity.Name, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
        }

    }
}

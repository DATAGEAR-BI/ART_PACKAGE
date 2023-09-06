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

namespace ART_PACKAGE.Controllers
{

    //[Authorize(Policy = "Licensed" , Roles = "Activity")]


    public class ActivityController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;


        public ActivityController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }


        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiActivityReport> data = fti.ArtTiActivityReports.AsQueryable();


            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {


                DisplayNames = ReportsConfig.CONFIG[nameof(ActivityController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"BranchName".ToLower(), fti.ArtTiActivityReports.Select(x=>x.BranchName).Distinct()    .Where(x=> x != null)    .ToDynamicList() },
                {"Team".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Team).Distinct()                .Where(x=> x != null)    .ToDynamicList() },
                {"MasterRef".ToLower(), fti.ArtTiActivityReports.Select(x=>x.MasterRef).Distinct()      .Where(x=> x != null)    .ToDynamicList() },
                {"Sovalue".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Sovalue).Distinct()          .Where(x=> x != null)    .ToDynamicList() },
                {"EventRef".ToLower(), fti.ArtTiActivityReports.Select(x=>x.EventRef).Distinct()        .Where(x=> x != null)    .ToDynamicList() },
                {"EventStatus".ToLower(), fti.ArtTiActivityReports.Select(x=>x.EventStatus).Distinct()  .Where(x=> x != null)    .ToDynamicList() },
                {"Ccy".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Ccy).Distinct()                  .Where(x=> x != null)    .ToDynamicList() },
                {"Address1".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Address1).Distinct()        .Where(x=> x != null)    .ToDynamicList() },
                {"Address12".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Address12).Distinct()      .Where(x=> x != null)    .ToDynamicList() },
                {"Lstmoduser".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Lstmoduser).Distinct()    .Where(x=> x != null)    .ToDynamicList() },
                {"Shortname".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Shortname).Distinct()    .Where(x=> x != null)    .ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ActivityController).ToLower()].SkipList;
            }
            var Data = data.CallData<ArtTiActivityReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {
                },
                reportname = "Activity"
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
            var data = fti.ArtTiActivityReports;
            var bytes = await data.ExportToCSV<ArtTiActivityReport, GenericCsvClassMapper<ArtTiActivityReport, ActivityController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var data = fti.ArtTiActivityReports.CallData<ArtTiActivityReport>(req).Data.ToList();
            ViewData["title"] = "Activity Report";
            ViewData["desc"] = "This report produces information for a single master record or for all master records, showing what events have been initiated for each master record and the status of the current active steps for each event within it";

            var DisplayNames = ReportsConfig.CONFIG[nameof(ActivityController).ToLower()].DisplayNames;
            var columnsToPrint = new List<string>()
            { nameof(ArtTiActivityReport.MasterRef)
            , nameof(ArtTiActivityReport.Address1)
            , nameof(ArtTiActivityReport.Address12)
            , nameof(ArtTiActivityReport.Sovalue)
            , nameof(ArtTiActivityReport.Shortname)
            , nameof(ArtTiActivityReport.EventStatus)
            , nameof(ArtTiActivityReport.Lstmoduser)
            , nameof(ArtTiActivityReport.StartDate)
            };
            var ColumnsToSkip = typeof(ArtTiActivityReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();
            if (req.Group is not null && req.Group.Count != 0)
            {
                var pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, this.ControllerContext
                                                   , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
            else
            {
                var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 9
                                                   , User.Identity.Name, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");


            }

        }
    }
}

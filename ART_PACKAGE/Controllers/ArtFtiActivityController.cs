using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    [Authorize(Roles = "ArtFtiActivity")]

    public class ArtFtiActivityController : Controller
    {
        private readonly FTIContext dbfcfkc;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService dropDownService;
        private readonly ICsvExport _csvSrv;
        public ArtFtiActivityController(FTIContext dbfcfkc, IPdfService pdfSrv, IDropDownService dropDownService, ICsvExport csvSrv)
        {
            this.dbfcfkc = dbfcfkc; ;
            _pdfSrv = pdfSrv;
            this.dropDownService = dropDownService;
            _csvSrv = csvSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtFtiActivity> data = dbfcfkc.ArtFtiActivities.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtFtiActivityController).ToLower()].DisplayNames;
                List<string> evensteps = new()
                {
                   "Abort",
                   "Review",
                   "Final review",
                   "Create",
                   "Input",
                   "Log",
                   "Release",
                   "Complete",
                   "Limit check",
                   "Final limit check",
                   "Gateway",
                   "SWIFT In",
                   "Rate fixing",
                   "*Review/Final review*",
                   "Fix auth",
                   "Limit approval",
                   "Print",
                   "Watch list check",
                   "Release pending",
                   "Post release",
                   "Exchange",
                   "External review",
                   "Internal",
                   "Synchronisation",
                   "Batch",
                   "Gwy auto input",
                   "EoD auto input",
                   "Int auto input",
                   "Swft auto input",
                   "Auto reject"
                };
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    {"EcmReference".ToLower(),dropDownService.GetECMREFERNCEDropDown().ToDynamicList() },
                    {"FtiReference".ToLower(),dbfcfkc.ArtFtiActivities.Where(x=>x.FtiReference!=null).Select(x => x.FtiReference).Distinct().ToDynamicList() },
                    {"EventSteps".ToLower(),evensteps.ToDynamicList() },

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtFtiActivityController).ToLower()].SkipList;
            }

            KendoDataDesc<ArtFtiActivity> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {
                    /*new
                    {
                        text = "Delete Cases",
                        id="dltCases",
                        show = User.IsInRole("Delete_Cases")
                    }*/
                },

            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        /*public IActionResult Export([FromBody] ExportDto<decimal> req)
        {
            var data = dbfcfkc.AmlCaseDetailViews.AsQueryable();
            var bytes = data.ExportToCSV<AmlCaseDetailView>(req.Req);
            return File(bytes, "test/csv");
        }*/
        public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        {
            IQueryable<ArtFtiActivity> data = dbfcfkc.ArtFtiActivities.AsQueryable();
            await _csvSrv.ExportAllCsv<ArtFtiActivity, ArtFtiActivityController, int>(data, User.Identity.Name, para);
            return new EmptyResult();
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtFtiActivityController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtFtiActivityController).ToLower()].SkipList;
            List<ArtFtiActivity> data = dbfcfkc.ArtFtiActivities.CallData(req).Data.ToList();
            ViewData["title"] = "FTI-Activities";
            ViewData["desc"] = "DGECM Activity Report showing what cases have been created and their status";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers
{
    public class ArtFtiEndToEndNewController : Controller
    {

        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService dropDownService;
        private readonly ICsvExport _csvSrv;
        public ArtFtiEndToEndNewController(FTIContext fti, IPdfService pdfSrv, IDropDownService dropDownService, ICsvExport csvSrv)
        {
            this.fti = fti; ;
            _pdfSrv = pdfSrv;
            this.dropDownService = dropDownService;
            _csvSrv = csvSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtFtiEndToEndNew> data = fti.ArtFtiEndToEndsNew.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtFtiEndToEndController).ToLower()].DisplayNames;
                List<string> evensteps = new()
                {
                };
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    //{"EcmReference".ToLower(),dropDownService.GetECMREFERNCEDropDown().ToDynamicList() },
                    //{"FtiReference".ToLower(),fti.ArtFtiActivities.Where(x=>x.FtiReference!=null).Select(x => x.FtiReference).Distinct().ToDynamicList() },
                    //{"EventSteps".ToLower(),evensteps.ToDynamicList() },

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtFtiEndToEndController).ToLower()].SkipList;
            }

            KendoDataDesc<ArtFtiEndToEndNew> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
                        text = "Get Ecm Events Workflow",
                        id = "ecmEventsWorkflow",
                        //show = User.IsInRole("Delete_Cases")
                    }
                    , new
                    {
                        text = "Get Fti Events Workflow",
                        id = "ftiEventsWorkflow",
                        //show = User.IsInRole("Delete_Cases")
                    }
                    , new
                    {
                        text = "Get SubCases",
                        id = "subCases",
                        //show = User.IsInRole("Delete_Cases")
                    },*/
                },
                selectable = true

            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        /*public IActionResult Export([FromBody] ExportDto<decimal> req)
        {
            var data = fti.AmlCaseDetailViews.AsQueryable();
            var bytes = data.ExportToCSV<AmlCaseDetailView>(req.Req);
            return File(bytes, "test/csv");
        }*/
        //public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        //{
        //    IQueryable<ArtFtiActivity> data = fti.ArtFtiActivities.AsQueryable();
        //    await _csvSrv.ExportAllCsv<ArtFtiActivity, ArtFtiActivityController, int>(data, User.Identity.Name, para);
        //    return new EmptyResult();
        //}

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtFtiEndToEndController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtFtiEndToEndController).ToLower()].SkipList;
            List<ArtFtiEndToEndNew> data = fti.ArtFtiEndToEndsNew.CallData(req).Data.ToList();
            ViewData["title"] = "End to end report";
            ViewData["desc"] = "";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("[controller]/[action]/{reference}")]
        public IActionResult GetSubCases(string? reference)
        {
            IQueryable<ArtFtiEndToEndSubCases> subCases = fti.ArtFtiEndToEndSubCasess.Where(x => x.ParentCaseId == reference);
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(subCases)
            };
        }
        [HttpGet("[controller]/[action]/{reference}")]
        public IActionResult GetEcmEvents(string? reference)
        {
            IQueryable<ArtFtiEndToEndEcmEventsWorkflow> events = fti.ArtFtiEndToEndEcmEventsWorkflows.Where(x => x.EcmReference == reference);
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(events)
            };
        }
        [HttpGet("[controller]/[action]/{reference}")]
        public IActionResult GetFtiEvents(string? reference)
        {
            IQueryable<ArtFtiEndToEndFtiEventsWorkflow> subCases = fti.ArtFtiEndToEndFtiEventsWorkflows.Where(x => x.FtiReference == reference);
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(subCases)
            };
        }


    }
}

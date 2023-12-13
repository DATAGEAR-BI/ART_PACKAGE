using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    public class ArtEcmSlaViolatedCasesController : Controller
    {

        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService dropDownService;
        private readonly ICsvExport _csvSrv;
        public ArtEcmSlaViolatedCasesController(FTIContext fti, IPdfService pdfSrv, IDropDownService dropDownService, ICsvExport csvSrv)
        {
            this.fti = fti; ;
            _pdfSrv = pdfSrv;
            this.dropDownService = dropDownService;
            _csvSrv = csvSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtEcmSlaViolatedCasesTb> data = fti.ArtEcmSlaViolatedCasesTb.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;

            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtEcmSlaViolatedCasesController).ToLower()].DisplayNames;
                List<string> evensteps = new()
                {
                };
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    {"Product".ToLower(),dropDownService.GetProductDropDown().ToDynamicList() },
                    {"ProductType".ToLower(),dropDownService.GetProductTypeDropDown().ToDynamicList() },
                    //{"EcmReference".ToLower(),dropDownService.GetECMREFERNCEDropDown().ToDynamicList() },
                    //{"FtiReference".ToLower(),fti.ArtFtiActivities.Where(x=>x.FtiReference!=null).Select(x => x.FtiReference).Distinct().ToDynamicList() },
                    //{"EventSteps".ToLower(),evensteps.ToDynamicList() },

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtEcmSlaViolatedCasesController).ToLower()].SkipList;
            }

            KendoDataDesc<ArtEcmSlaViolatedCasesTb> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtEcmSlaViolatedCasesController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtEcmSlaViolatedCasesController).ToLower()].SkipList;
            List<ArtEcmSlaViolatedCasesTb> data = fti.ArtEcmSlaViolatedCasesTb.CallData(req).Data.ToList();
            ViewData["title"] = "Pending Cases report";
            ViewData["desc"] = "";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("[controller]/[action]/{caseRk}")]
        public IActionResult GetAssignees(string? caseRk)
        {
            IQueryable<ArtEcmAssignee> assignees = fti.ArtEcmAssignees.Where(x => x.CaseRk.ToString() == Uri.UnescapeDataString(caseRk));
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(assignees)
            };
        }
        


    }
}

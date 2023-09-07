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
    [Authorize(Roles = "ArtEcmFtiFullCycle", Policy = "License")]
    public class ArtEcmFtiFullCycleController : Controller
    {
        private readonly FTIContext dbfcfkc;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService dropDownService;

        public ArtEcmFtiFullCycleController(FTIContext dbfcfkc, IPdfService pdfSrv, DropDownService dropDownService)
        {
            this.dbfcfkc = dbfcfkc;
            _pdfSrv = pdfSrv;
            this.dropDownService = dropDownService;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtEcmFtiFullCycle> data = dbfcfkc.ArtEcmFtiFullCycles.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtEcmFtiFullCycleController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"Product".ToLower(),dropDownService.GetProductDropDown().ToDynamicList() },
                    {"FtiReference".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.FtiReference!=null).Select(x => x.FtiReference).Distinct().ToDynamicList() },
                    {"EcmReference".ToLower(),dropDownService.GetECMREFERNCEDropDown().ToDynamicList() },
                    {"ProductType".ToLower(),dropDownService.GetProductTypeDropDown().ToDynamicList() },
                    {"BranchId".ToLower(),dropDownService.GetBranchIDDropDown().ToDynamicList() },
                    {"CustomerName".ToLower(),dropDownService.GetCustomerNameDropDown().ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtEcmFtiFullCycleController).ToLower()].SkipList;
            }

            KendoDataDesc<ArtEcmFtiFullCycle> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            IQueryable<ArtEcmFtiFullCycle> data = dbfcfkc.ArtEcmFtiFullCycles.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtEcmFtiFullCycle, GenericCsvClassMapper<ArtEcmFtiFullCycle, ArtEcmFtiFullCycleController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtEcmFtiFullCycleController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtEcmFtiFullCycleController).ToLower()].SkipList;
            List<ArtEcmFtiFullCycle> data = dbfcfkc.ArtEcmFtiFullCycles.CallData(req).Data.ToList();
            ViewData["title"] = "ECM-FTI Full cycle";
            ViewData["desc"] = "The full cycle between DGECM and FTI, DGECM case main details, Request and response on comment section, FTI main details, Action/ Feedback requested from FTI to DGECM first line, FTI Notes";
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

using Microsoft.AspNetCore.Mvc;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Newtonsoft.Json;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Services.Pdf;
using Microsoft.AspNetCore.Authorization;
using ART_PACKAGE.Helpers.DropDown;

namespace ART_PACKAGE.Controllers
{
    [Authorize(Roles = "ArtCasesInitiatedFromBranch")]
    public class ArtCasesInitiatedFromBranchController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService dropDownService;
        public ArtCasesInitiatedFromBranchController(AuthContext dbfcfkc, IPdfService pdfSrv, DropDownService dropDownService)
        {
            this.dbfcfkc = dbfcfkc;
            _pdfSrv = pdfSrv;
            this.dropDownService = dropDownService;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtCasesInitiatedFromBranch> data = dbfcfkc.ArtCasesInitiatedFromBranches.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtCasesInitiatedFromBranchController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"EcmReference".ToLower(),dropDownService.GetECMREFERNCEDropDown().ToDynamicList() },
                    {"BranchId".ToLower(),dropDownService.GetBranchIDDropDown().ToDynamicList() },
                    {"CustomerName".ToLower(),dropDownService.GetCustomerNameDropDown().ToDynamicList() },
                    {"Product".ToLower(),dropDownService.GetProductDropDown().ToDynamicList() },
                    {"ProductType".ToLower(),dropDownService.GetProductTypeDropDown().ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtCasesInitiatedFromBranchController).ToLower()].SkipList;
            }

            KendoDataDesc<ArtCasesInitiatedFromBranch> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            IQueryable<ArtCasesInitiatedFromBranch> data = dbfcfkc.ArtCasesInitiatedFromBranches.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtCasesInitiatedFromBranch, GenericCsvClassMapper<ArtCasesInitiatedFromBranch, ArtCasesInitiatedFromBranchController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtCasesInitiatedFromBranchController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtCasesInitiatedFromBranchController).ToLower()].SkipList;
            List<ArtCasesInitiatedFromBranch> data = dbfcfkc.ArtCasesInitiatedFromBranches.CallData(req).Data.ToList();
            ViewData["title"] = "Cases Initiated from Branch";
            ViewData["desc"] = "Transaction initiated from branch, Include DGECM cases main details, created and processed to FTI";
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

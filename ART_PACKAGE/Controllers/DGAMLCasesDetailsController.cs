using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    [Authorize(Roles = "CasesDetails")]
    public class DGAMLCasesDetailsController : Controller
    {
        private readonly ArtDgAmlContext _context;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public DGAMLCasesDetailsController(ArtDgAmlContext _context, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this._context = _context;
            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtDgAmlCaseDetailView> data = _context.ArtDgAmlCaseDetailViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCasesDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCasesDetailsController).ToLower()].DisplayNames : new();
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    {"BranchName".ToLower(),_dropDown.GetDGBranchNameDropDown().ToDynamicList() },
                    {"CaseStatus".ToLower(),_dropDown.GetDGCaseStatusDropDown().ToDynamicList() },
                    {"CasePriority".ToLower(),_dropDown.GetDGCasePriorityDropDown().ToDynamicList() },
                    {"CaseCategory".ToLower(),_dropDown.GetDGCaseCategoryDropDown().ToDynamicList() },
                    {"CreatedBy".ToLower(),_dropDown.GetDGCreatedByDropDown().ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCasesDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCasesDetailsController).ToLower()].SkipList : new();
            }

            KendoDataDesc<ArtDgAmlCaseDetailView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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


        public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        {
            IQueryable<ArtDgAmlCaseDetailView> data = _context.ArtDgAmlCaseDetailViews.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtDgAmlCaseDetailView, GenericCsvClassMapper<ArtDgAmlCaseDetailView, DGAMLCasesDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat>? DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCasesDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCasesDetailsController).ToLower()].DisplayNames : null;
            List<string>? ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCasesDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].SkipList : null;
            List<ArtDgAmlCaseDetailView> data = _context.ArtDgAmlCaseDetailViews.CallData(req).Data.ToList();
            ViewData["title"] = "Cases Details";
            ViewData["desc"] = "Presents the cases details in the table below";
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

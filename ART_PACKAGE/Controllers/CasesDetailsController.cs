using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Newtonsoft.Json;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DropDown;
using Data.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Services.Pdf;

namespace ART_PACKAGE.Controllers
{
    public class CasesDetailsController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public CasesDetailsController(AuthContext dbfcfkc, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this.dbfcfkc = dbfcfkc;
            this._dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtAmlCaseDetailsView> data = dbfcfkc.ArtAmlCaseDetailsViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    {"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
                    {"CasePriority".ToLower(),_dropDown.GetCasePriorityDropDown().ToDynamicList() },
                    {"CaseCategory".ToLower(),_dropDown.GetCaseCategoryDropDown().ToDynamicList() },
                    {"CaseSubCategory".ToLower(),_dropDown.GetCaseSubCategoryDropDown().ToDynamicList() },
                    {"CreatedBy".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"Owner".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"EntityLevel".ToLower(),_dropDown.GetEntityLevelDropDown().ToDynamicList() }
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].SkipList;
            }

            var Data = data.CallData<ArtAmlCaseDetailsView>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = dbfcfkc.ArtAmlCaseDetailsViews.AsQueryable();
            var bytes = await data.ExportToCSV<ArtAmlCaseDetailsView, GenericCsvClassMapper<ArtAmlCaseDetailsView, CasesDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].SkipList;
            var data = dbfcfkc.ArtAmlCaseDetailsViews.CallData<ArtAmlCaseDetailsView>(req).Data.ToList();
            ViewData["title"] = "Cases Details";
            ViewData["desc"] = "Presents the cases details in the table below";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

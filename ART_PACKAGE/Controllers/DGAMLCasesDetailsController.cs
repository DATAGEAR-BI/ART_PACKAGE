﻿using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Services.Pdf;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    public class DGAMLCasesDetailsController : Controller
    {
        private readonly AuthContext _context;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public DGAMLCasesDetailsController(AuthContext _context, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this._context = _context;
            this._dropDown = dropDown;
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
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
                    //{"CasePriority".ToLower(),_dropDown.GetCasePriorityDropDown().ToDynamicList() },
                    //{"CaseCategory".ToLower(),_dropDown.GetCaseCategoryDropDown().ToDynamicList() },
                    //{"CaseSubCategory".ToLower(),_dropDown.GetCaseSubCategoryDropDown().ToDynamicList() },
                    //{"CreatedBy".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    //{"Owner".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    //{"EntityLevel".ToLower(),_dropDown.GetEntityLevelDropDown().ToDynamicList() }
                };
                ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCasesDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCasesDetailsController).ToLower()].SkipList : new();
            }

            var Data = data.CallData<ArtDgAmlCaseDetailView>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = _context.ArtDgAmlCaseDetailViews.AsQueryable();
            var bytes = await data.ExportToCSV<ArtDgAmlCaseDetailView, GenericCsvClassMapper<ArtDgAmlCaseDetailView, DGAMLCasesDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCasesDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCasesDetailsController).ToLower()].DisplayNames : null;
            var ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCasesDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].SkipList : null;
            var data = _context.ArtDgAmlCaseDetailViews.CallData<ArtDgAmlCaseDetailView>(req).Data.ToList();
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
﻿using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.SASAML
{
    ////[Authorize(Roles = "CasesDetails")]
    public class CasesDetailsController : Controller
    {
        private readonly SasAmlContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public CasesDetailsController(SasAmlContext dbfcfkc, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this.dbfcfkc = dbfcfkc;
            _dropDown = dropDown;
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

            KendoDataDesc<ArtAmlCaseDetailsView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        //{
        //    IQueryable<ArtAmlCaseDetailsView> data = dbfcfkc.ArtAmlCaseDetailsViews.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtAmlCaseDetailsView, GenericCsvClassMapper<ArtAmlCaseDetailsView, CasesDetailsController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].SkipList;
            List<ArtAmlCaseDetailsView> data = dbfcfkc.ArtAmlCaseDetailsViews.CallData(req).Data.ToList();
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
﻿using ART_PACKAGE.Helpers.Csv;
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
    [Authorize(Roles = "ArtCasesInitiatedFromBranch")]
    public class ArtCasesInitiatedFromBranchController : Controller
    {
        private readonly FTIContext dbfcfkc;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService dropDownService;
        private readonly ICsvExport _csvSrv;
        public ArtCasesInitiatedFromBranchController(FTIContext dbfcfkc, IPdfService pdfSrv, IDropDownService dropDownService, ICsvExport csvSrv)
        {
            this.dbfcfkc = dbfcfkc;
            _pdfSrv = pdfSrv;
            this.dropDownService = dropDownService;
            _csvSrv = csvSrv;
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
                    {"EcmReference".ToLower(),dropDownService   .GetECMREFERNCEDropDown()   .ToDynamicList() },
                    {"BranchName".ToLower(),dropDownService       .GetBranchNameDropDown()      .ToDynamicList() },
                    {"CustomerName".ToLower(),dropDownService   .GetCustomerNameDropDown()  .ToDynamicList() },
                    {"Product".ToLower(),dropDownService        .GetProductDropDown()       .ToDynamicList() },
                    {"ProductType".ToLower(),dropDownService    .GetProductTypeDropDown()   .ToDynamicList() },
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
        //public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        //{
        //    IQueryable<ArtCasesInitiatedFromBranch> data = dbfcfkc.ArtCasesInitiatedFromBranches.AsQueryable();
        //    await _csvSrv.ExportAllCsv<ArtCasesInitiatedFromBranch, ArtCasesInitiatedFromBranchController, int>(data, User.Identity.Name, para);
        //    return new EmptyResult();
        //}

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtCasesInitiatedFromBranchController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtCasesInitiatedFromBranchController).ToLower()].SkipList;
            List<ArtCasesInitiatedFromBranch> data = dbfcfkc.ArtCasesInitiatedFromBranches.CallData(req).Data.ToList();
            ViewData["title"] = "Cases Initiated from Branch";
            ViewData["desc"] = "Transaction initiated from branch, Include DGECM cases main details, created and processed to FTI";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
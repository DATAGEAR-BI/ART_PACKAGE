﻿using ART_PACKAGE.Helpers.Csv;
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
    [Authorize(Roles = "ArtDgecmActivity")]

    public class ArtDgecmActivityController : Controller
    {
        private readonly FTIContext dbfcfkc;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService dropDownService;
        private readonly ICsvExport _csvSrv;
        public ArtDgecmActivityController(FTIContext dbfcfkc, IPdfService pdfSrv, IDropDownService dropDownService, ICsvExport csvSrv)
        {
            this.dbfcfkc = dbfcfkc;
            _pdfSrv = pdfSrv;
            this.dropDownService = dropDownService;
            _csvSrv = csvSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtDgecmActivity> data = dbfcfkc.ArtDgecmActivities.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtDgecmActivityController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    {"EcmReference".ToLower(),dropDownService.GetECMREFERNCEDropDown().ToDynamicList() },
                    {"BranchId".ToLower(),dropDownService.GetBranchIDDropDown().ToDynamicList() },
                    {"CustomerName".ToLower(),dropDownService.GetCustomerNameDropDown().ToDynamicList() },
                    {"CaseStatus".ToLower(),dropDownService.GetCaseStatusDropDown().ToDynamicList() },
                    {"Product".ToLower(),dropDownService.GetProductDropDown().ToDynamicList() },
                    {"ProductType".ToLower(),dropDownService.GetProductTypeDropDown().ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtDgecmActivityController).ToLower()].SkipList;
            }

            KendoDataDesc<ArtDgecmActivity> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            IQueryable<ArtDgecmActivity> data = dbfcfkc.ArtDgecmActivities.AsQueryable();
            await _csvSrv.ExportAllCsv<ArtDgecmActivity, ArtDgecmActivityController, int>(data, User.Identity.Name, para);
            return new EmptyResult();
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtDgecmActivityController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtDgecmActivityController).ToLower()].SkipList;
            List<ArtDgecmActivity> data = dbfcfkc.ArtDgecmActivities.CallData(req).Data.ToList();
            ViewData["title"] = "DGECM-Activities";
            ViewData["desc"] = "Transactions from FTI and their communication with DGECM, FTI Transaction main detail,The first line parties that are selected to communicate with on DGECM";
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
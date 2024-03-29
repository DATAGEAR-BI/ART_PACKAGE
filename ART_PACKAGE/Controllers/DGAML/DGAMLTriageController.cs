﻿using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.ARTDGAML;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLTriageController : Controller
    {
        private readonly ArtDgAmlContext _context;
        private readonly IMemoryCache _cache;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public DGAMLTriageController(ArtDgAmlContext _context, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this._context = _context;
            _cache = cache;
            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtDgAmlTriageView> data = _context.ArtDGAMLTriageViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLTriageController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLTriageController).ToLower()].DisplayNames : new();
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //{"BranchName".ToLower(), _dropDown.GetBranchNameDropDown().ToDynamicList() },
                    //{"RiskScore".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
                    //{"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() }
                };
                ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLTriageController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLTriageController).ToLower()].SkipList : new();
            }
            KendoDataDesc<ArtDgAmlTriageView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        //public IActionResult Export([FromBody] ExportDto<decimal> req)
        //{
        //    var data = _context.AmlTriageViews.AsQueryable();
        //    var bytes = data.ExportToCSV<AmlTriageView>(req.Req);
        //    return File(bytes, "test/csv");
        //}

        public async Task<IActionResult> Export([FromBody] ExportDto<string> exportDto)
        {

            Microsoft.EntityFrameworkCore.DbSet<ArtDgAmlTriageView> data = _context.ArtDGAMLTriageViews;
            if (exportDto.All)
            {
                byte[] bytes = await data.ExportToCSV<ArtDgAmlTriageView, GenericCsvClassMapper<ArtDgAmlTriageView, DGAMLTriageController>>(exportDto.Req);
                return File(bytes, "text/csv");
            }
            else
            {
                byte[] bytes = await data.Where(x => exportDto.SelectedIdz.Contains(x.AlertedEntityNumber)).ExportToCSV<ArtDgAmlTriageView, GenericCsvClassMapper<ArtAmlTriageView, DGAMLTriageController>>(all: false);
                return File(bytes, "text/csv");
            }
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat>? DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLTriageController).ToLower()].DisplayNames : null;
            List<string>? ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLTriageController).ToLower()].SkipList : null;
            List<ArtDgAmlTriageView> data = _context.ArtDGAMLTriageViews.CallData(req).Data.ToList();
            ViewData["title"] = "Triage";
            ViewData["desc"] = "Presents each entity with the related active alerts count";
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

﻿using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.SASAML
{
    [Authorize(Roles = "Triage")]
    public class TriageController : Controller
    {
        private readonly SasAmlContext dbfcfkc;
        private readonly IMemoryCache _cache;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public TriageController(SasAmlContext dbfcfkc, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this.dbfcfkc = dbfcfkc;
            _cache = cache;
            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtAmlTriageView> data = dbfcfkc.ArtAmlTriageViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(TriageController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"BranchName".ToLower(), _dropDown.GetBranchNameDropDown().ToDynamicList() },
                    {"RiskScore".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
                    {"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() }
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(TriageController).ToLower()].SkipList;
            }
            KendoDataDesc<ArtAmlTriageView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    var data = dbfcfkc.AmlTriageViews.AsQueryable();
        //    var bytes = data.ExportToCSV<AmlTriageView>(req.Req);
        //    return File(bytes, "test/csv");
        //}

        //public async Task<IActionResult> Export([FromBody] ExportDto<string> exportDto)
        //{

        //    Microsoft.EntityFrameworkCore.DbSet<ArtAmlTriageView> data = dbfcfkc.ArtAmlTriageViews;
        //    if (exportDto.All)
        //    {
        //        byte[] bytes = await data.ExportToCSV<ArtAmlTriageView, GenericCsvClassMapper<ArtAmlTriageView, TriageController>>(exportDto.Req);
        //        return File(bytes, "text/csv");
        //    }
        //    else
        //    {
        //        byte[] bytes = await data.Where(x => exportDto.SelectedIdz.Contains(x.AlertedEntityNumber)).ExportToCSV<ArtAmlTriageView, GenericCsvClassMapper<ArtAmlTriageView, TriageController>>(all: false);
        //        return File(bytes, "text/csv");
        //    }
        //}

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(TriageController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(TriageController).ToLower()].SkipList;
            List<ArtAmlTriageView> data = dbfcfkc.ArtAmlTriageViews.CallData(req).Data.ToList();
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
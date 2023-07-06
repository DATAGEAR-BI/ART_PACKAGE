
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Services;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DropDown;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using ART_PACKAGE.Services.Pdf;

namespace ART_PACKAGE.Controllers
{
    public class SystemPerformanceController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public SystemPerformanceController(AuthContext dbfcfkc, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this.dbfcfkc = dbfcfkc;

            this._dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtSystemPerformance> data = dbfcfkc.ArtSystemPerformances.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].DisplayNames;
                
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                     {"CaseType".ToLower(),_dropDown.GetCaseTypeDropDown().ToDynamicList() },
                     {"CaseStatus".ToLower(),_dropDown.GetSystemCaseStatusDropDown().ToDynamicList() },
                    {"TransactionDirection".ToLower(),_dropDown.GetTransDirectionDropDown().ToDynamicList() },
                    {"TransactionType".ToLower(),_dropDown.GetTransTypeDropDown().ToDynamicList() },
                    //{"UpdateUserId".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"Priority".ToLower(),_dropDown.GetCasePriorityDropDown().ToDynamicList() },
                };

                ColumnsToSkip = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].SkipList;
            }



            var Data = data.CallData<ArtSystemPerformance>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> req)
        {
            var data = dbfcfkc.ArtSystemPerformances.AsQueryable();
            var bytes = await data.ExportToCSV<ArtSystemPerformance, GenericCsvClassMapper<ArtSystemPerformance, SystemPerformanceController>>(req.Req);
            return File(bytes, "test/csv");
        }
        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].SkipList;
            var data = dbfcfkc.ArtSystemPerformances.CallData<ArtSystemPerformance>(req).Data.ToList();
            ViewData["title"] = "System Performance Details";
            ViewData["desc"] = "presents all cases detail information";
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

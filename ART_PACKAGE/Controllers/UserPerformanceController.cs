﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using Data.DGECM;

namespace DataGear_RV_Ver_1._7.Controllers
{
    [AllowAnonymous]
    public class UserPerformanceController : Controller
    {

        private readonly AuthContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly DGECMContext db = new DGECMContext();

        public UserPerformanceController(AuthContext _context,Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv)
        {
            this._env = env; _pdfSrv = pdfSrv;context = _context;
        }

        //private readonly CMC_AUDIT_TEST.ModelContext dbcmcaudit = new CMC_AUDIT_TEST.ModelContext();

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtUserPerformance> data = context.ArtUserPerformances.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"CaseTypeCd".ToLower(),db.RefTableVals
                       .Where(a => a.RefTableName.StartsWith("RT_CASE_TYPE"))
                       //.Where(b => b.DisplayOrdrNo == 0 || b.DisplayOrdrNo == 5)
                       .Select(x=>x.ValDesc).ToDynamicList() },
                    {"CaseStatus".ToLower(),db.RefTableVals
                                .Where(a => a.RefTableName.StartsWith("RT_CASE_STATUS"))
                               // .Where(b => b.ValCd.Equals("SC") || b.ValCd.Equals("ST"))
                                .Select(x=>x.ValDesc)
                                .ToDynamicList() },
                    {"Priority".ToLower(),db.RefTableVals
                        .Where(a => a.RefTableName.StartsWith("X_RT_PRIORITY"))
                        .Where(b => b.ValDesc.Equals("High") || b.ValDesc.Equals("Low") || b.ValDesc.Equals("Medium")).Select(x=>x.ValDesc).ToDynamicList() },

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].SkipList;
            }


            var Data = data.CallData<ArtUserPerformance>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            var data = context.ArtUserPerformances;
            var bytes = await data.ExportToCSV<ArtUserPerformance, GenericCsvClassMapper<ArtUserPerformance, UserPerformanceController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].SkipList;
            var data = context.ArtUserPerformances.CallData<ArtUserPerformance>(req).Data.ToList();
            ViewData["title"] = "User Performance Report";
            ViewData["desc"] = "This report presents all sanction closed and terminated cases without the manually closed cases with the related information on user level as below";
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
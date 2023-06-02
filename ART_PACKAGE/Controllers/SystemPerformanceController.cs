using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using Microsoft.AspNetCore.Authorization;
using System.Data;

using System.Linq.Dynamic.Core;

using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Services.Pdf;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;

namespace DataGear_RV_Ver_1._7.Controllers
{
    [AllowAnonymous]
    public class SystemPerformanceController : Controller
    {
        private readonly AuthContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;

        public SystemPerformanceController(AuthContext _context,Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv)
        {
            this._env = env; _pdfSrv = pdfSrv;context = _context;
        }


        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtSystemPreformance> data = context.ArtSystemPerformances.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].DisplayNames;

                //DropDownColumn = new Dictionary<string, List<dynamic>>
                //{
                //    ////{"CaseType".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.CaseType).Distinct().ToDynamicList() },
                //    ////{"CaseStatus".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.CaseStatus).Distinct().ToDynamicList() },
                //    ////{"Priority".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.Priority).Distinct().ToDynamicList() },
                //    ////{"TransactionDirection".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.TransactionDirection).Distinct().ToDynamicList() },
                //    ////{"TransactionType".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.TransactionType).Distinct().ToDynamicList() },
                //    ////{"UpdateUserId".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.UpdateUserId).Distinct().ToDynamicList() },
                //    ////{"InvestrUserId".ToLower(),dbdgcmgmt.ArtSystemPerformances.Select(x=>x.InvestrUserId).Distinct().ToDynamicList() },

                //    {"CaseType".ToLower(),context.RefTableVals.Where(a => a.RefTableName.StartsWith("RT_CASE_TYPE")).Select(x=>x.ValDesc).ToDynamicList() },
                //    {"CaseStatus".ToLower(),context.RefTableVals
                //        .Where(a => a.RefTableName.StartsWith("RT_CASE_STATUS"))
                //        //.Where(b => b.ValCd.Equals("SC") || b.ValCd.Equals("ST"))
                //        //.Where(b => b.DisplayOrdrNo==0)
                //        .Select(x=>x.ValDesc).ToDynamicList() },
                //    {"Priority".ToLower(),context.RefTableVals
                //        .Where(a => a.RefTableName.StartsWith("X_RT_PRIORITY"))
                //        .Where(b => b.ValDesc.Equals("High") || b.ValDesc.Equals("Low") || b.ValDesc.Equals("Medium")).Select(x=>x.ValDesc).ToDynamicList() }

                //};
            }
            ColumnsToSkip = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].SkipList;

            var Data = data.CallData<ArtSystemPreformance>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = context.ArtSystemPerformances;
            var bytes = await data.ExportToCSV<ArtSystemPreformance, GenericCsvClassMapper<ArtSystemPreformance, SystemPerformanceController>>(para.Req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].SkipList;
            var data = context.ArtSystemPerformances.CallData<ArtSystemPreformance>(req).Data.ToList();
            ViewData["title"] = "System Performance Report";
            ViewData["desc"] = "This report presents all sanction cases with the related information on case level as below";
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

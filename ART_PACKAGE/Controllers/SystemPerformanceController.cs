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
using Data.DGECM;
using Microsoft.EntityFrameworkCore;
using ART_PACKAGE.Helpers.DropDown;

namespace ART_PACKAGE.Controllers
{
    [AllowAnonymous]
    public class SystemPerformanceController : Controller
    {
        private readonly AuthContext context;
        private readonly DGECMContext db;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;

        public SystemPerformanceController(AuthContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, DGECMContext db, IDropDownService dropSrv)
        {
            this._env = env;
            _pdfSrv = pdfSrv;
            context = _context;
            this.db = db;
            _dropSrv = dropSrv;
        }

        public IActionResult Test()
        {
            var data = context.ArtSystemPerformances.Where(x => x.CreateDate.Date.CompareTo(new DateTime(2022, 04, 12).Date) == 0).Take(10);
            return Ok(data);
        }
        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtSystemPreformance> data = context.ArtSystemPreformances.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    { "CaseType".ToLower()              , _dropSrv.GetCaseTypeDropDown()      .ToDynamicList()     },
                    {"CaseStatus".ToLower()             , _dropSrv.GetSystemCaseStatusDropDown()    .ToDynamicList()     },
                    {"Priority".ToLower()               ,  _dropSrv.GetPriorityDropDown()     .ToDynamicList()     },
                    {"TransactionDirection".ToLower()   ,_dropSrv.GetTransDirectionDropDown() .ToDynamicList()     },
                    {"TransactionType".ToLower()        ,_dropSrv.GetTransTypeDropDown()      .ToDynamicList()     },
                    {"UpdateUserId".ToLower()           ,_dropSrv.GetUpdateUserIdDropDown()          .ToDynamicList()     },
                    {"InvestrUserId".ToLower()          ,_dropSrv.GetInvestagtorDropDown()          .ToDynamicList()     },
                };
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
            var data = context.ArtSystemPreformances;
            var bytes = await data.ExportToCSV<ArtSystemPreformance, GenericCsvClassMapper<ArtSystemPreformance, SystemPerformanceController>>(para.Req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(SystemPerformanceController).ToLower()].SkipList;
            var data = context.ArtSystemPreformances.CallData<ArtSystemPreformance>(req).Data.ToList();
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

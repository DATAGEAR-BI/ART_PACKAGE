using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.ECM;
using Data.DGECM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    [AllowAnonymous]
    public class UserPerformanceController : Controller
    {

        private readonly EcmContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly DGECMContext db;
        private readonly IDropDownService _dropSrv;

        public UserPerformanceController(EcmContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, DGECMContext db, IDropDownService dropSrv)
        {
            _env = env; _pdfSrv = pdfSrv;
            context = _context;
            this.db = db;
            _dropSrv = dropSrv;
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
                    {"CaseTypeCd".ToLower()              , _dropSrv.GetCaseTypeDropDown()    .ToDynamicList()     },
                    {"CaseStatus".ToLower()             , _dropSrv.GetUserCaseStatusDropDown()    .ToDynamicList()     },
                    {"Priority".ToLower()               ,  _dropSrv.GetPriorityDropDown()     .ToDynamicList()     },

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].SkipList;
            }


            KendoDataDesc<ArtUserPerformance> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            Microsoft.EntityFrameworkCore.DbSet<ArtUserPerformance> data = context.ArtUserPerformances;
            byte[] bytes = await data.ExportToCSV<ArtUserPerformance, GenericCsvClassMapper<ArtUserPerformance, UserPerformanceController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(UserPerformanceController).ToLower()].SkipList;
            List<ArtUserPerformance> data = context.ArtUserPerformances.CallData(req).Data.ToList();
            ViewData["title"] = "User Performance Report";
            ViewData["desc"] = "This report presents all sanction closed and terminated cases without the manually closed cases with the related information on user level as below";
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

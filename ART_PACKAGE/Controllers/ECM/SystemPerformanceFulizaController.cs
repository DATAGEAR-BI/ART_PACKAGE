using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.ECM;
using Data.DGECM;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.ECM
{

    public class SystemPerformanceFulizaController : Controller
    {
        private readonly EcmContext context;
        private readonly DGECMContext db;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;
        private readonly ICsvExport _csvSrv;

        public SystemPerformanceFulizaController(EcmContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, DGECMContext db, IDropDownService dropSrv, ICsvExport csvSrv)
        {
            _env = env;
            _pdfSrv = pdfSrv;
            context = _context;
            this.db = db;
            _dropSrv = dropSrv;
            _csvSrv = csvSrv;
        }


        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtSystemPerformanceNcbaFuliza> data = context.ArtSystemPerformanceNcbaFulizas.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(SystemPerformanceFulizaController).ToLower()].DisplayNames;

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
            ColumnsToSkip = ReportsConfig.CONFIG[nameof(SystemPerformanceFulizaController).ToLower()].SkipList;

            KendoDataDesc<ArtSystemPerformanceNcbaFuliza> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            Microsoft.EntityFrameworkCore.DbSet<ArtSystemPerformanceNcbaFuliza> data = context.ArtSystemPerformanceNcbaFulizas;
            await _csvSrv.ExportAllCsv<ArtSystemPerformanceNcbaFuliza, SystemPerformanceFulizaController, decimal>(data, User.Identity.Name, para);
            return new EmptyResult();
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(SystemPerformanceFulizaController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(SystemPerformanceFulizaController).ToLower()].SkipList;
            List<ArtSystemPerformanceNcbaFuliza> data = context.ArtSystemPerformanceNcbaFulizas.CallData(req).Data.ToList();
            ViewData["title"] = "System Performance Fuliza Report";
            ViewData["desc"] = "This report presents all sanction cases for fuliza module with the related information on case level as below";
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

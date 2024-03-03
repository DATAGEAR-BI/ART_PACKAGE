using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.SASAudit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.SASAUDIT
{

    public class SASAuditTrailActionController : Controller
    {
        private readonly SasAuditContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;

        public SASAuditTrailActionController(SasAuditContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, IDropDownService dropSrv)
        {
            _env = env; _pdfSrv = pdfSrv; context = _context;
            _dropSrv = dropSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<SasAuditTrailReport> data = context.SasAuditTrailReports.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(SASAuditTrailActionController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(SASAuditTrailActionController).ToLower()].SkipList;
            }


            KendoDataDesc<SasAuditTrailReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(SASAuditTrailActionController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(SASAuditTrailActionController).ToLower()].SkipList;
            List<SasAuditTrailReport> data = context.SasAuditTrailReports.CallData(req).Data.ToList();
            ViewData["title"] = "SAS Audit Trail Report";
            ViewData["desc"] = "Presents details about auditing the metadata server";
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

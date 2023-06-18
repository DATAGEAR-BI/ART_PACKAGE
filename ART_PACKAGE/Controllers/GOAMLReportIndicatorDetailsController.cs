using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Services.Pdf;

namespace ART_PACKAGE.Controllers
{
    public class GOAMLReportIndicatorDetailsController : Controller
    {
        private readonly AuthContext _context;
        private readonly IPdfService _pdfSrv;

        public GOAMLReportIndicatorDetailsController(AuthContext context, IPdfService pdfSrv)
        {
            _context = context;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtGoamlReportsIndicator> data = _context.ArtGoamlReportsIndicators.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportIndicatorDetailsController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //{"Indicator".ToLower(),_dropDown.GetReportIndicatorDropDown().ToDynamicList() },


                };
                ColumnsToSkip = new List<string>
                {

                };
            }


            var Data = data.CallData<ArtGoamlReportsIndicator>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

        public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        {
            var data = _context.ArtGoamlReportsIndicators.AsQueryable();
            var bytes = await data.ExportToCSV<ArtGoamlReportsIndicator, GenericCsvClassMapper<ArtGoamlReportsIndicator, GOAMLReportIndicatorDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportIndicatorDetailsController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(GOAMLReportIndicatorDetailsController).ToLower()].SkipList;
            var data = _context.ArtGoamlReportsIndicators.CallData<ArtGoamlReportsIndicator>(req).Data.ToList();
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

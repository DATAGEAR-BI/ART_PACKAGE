using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.DropDown;
using System.Linq.Dynamic.Core;
using Data.Data.ARTGOAML;

namespace ART_PACKAGE.Controllers
{
    public class GOAMLReportIndicatorDetailsController : Controller
    {
        private readonly ArtGoAmlContext _context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;

        public GOAMLReportIndicatorDetailsController(ArtGoAmlContext context, IPdfService pdfSrv, IDropDownService dropSrv)
        {
            _context = context;
            _pdfSrv = pdfSrv;
            _dropSrv = dropSrv;
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
                    {"Indicator".ToLower(),_dropSrv.GetReportIndicatorDropDown().ToDynamicList() },
                };
                ColumnsToSkip = new List<string>
                {
                };
            }


            KendoDataDesc<ArtGoamlReportsIndicator> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            IQueryable<ArtGoamlReportsIndicator> data = _context.ArtGoamlReportsIndicators.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtGoamlReportsIndicator, GenericCsvClassMapper<ArtGoamlReportsIndicator, GOAMLReportIndicatorDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportIndicatorDetailsController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(GOAMLReportIndicatorDetailsController).ToLower()].SkipList;
            List<ArtGoamlReportsIndicator> data = _context.ArtGoamlReportsIndicators.CallData(req).Data.ToList();
            ViewData["title"] = "GOAML Reports Indicatores";
            ViewData["desc"] = "Presents each GOAML report with the related indicators";
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

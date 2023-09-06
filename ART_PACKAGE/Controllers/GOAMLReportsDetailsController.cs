using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.DropDown;
using Data.Data.ARTGOAML;

namespace ART_PACKAGE.Controllers
{
    public class GOAMLReportsDetailsController : Controller
    {
        private readonly ArtGoAmlContext _context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropDown;
        public GOAMLReportsDetailsController(ArtGoAmlContext context, IPdfService pdfSrv, IDropDownService dropDown)
        {
            _context = context;
            _pdfSrv = pdfSrv;
            _dropDown = dropDown;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtGoamlReportsDetail> data = _context.ArtGoamlReportsDetails.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportsDetailsController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"Reportcode".ToLower(),_dropDown.GetReportTypeDropDown().ToDynamicList() },
                    {"Reportstatuscode".ToLower(),_dropDown.GetReportstatuscodeDropDown().ToDynamicList() },
                    {"Priority".ToLower(),_dropDown.GetReportPriorityDropDown().ToDynamicList() },
                    {"Rentitybranch".ToLower(),_dropDown.GetNonREntityBranchDropDown().ToDynamicList() },

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(GOAMLReportsDetailsController).ToLower()].SkipList;
            }

            KendoDataDesc<ArtGoamlReportsDetail> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            IQueryable<ArtGoamlReportsDetail> data = _context.ArtGoamlReportsDetails.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtGoamlReportsDetail, GenericCsvClassMapper<ArtGoamlReportsDetail, GOAMLReportsDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportsDetailsController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(GOAMLReportsDetailsController).ToLower()].SkipList;
            List<ArtGoamlReportsDetail> data = _context.ArtGoamlReportsDetails.CallData(req).Data.ToList();
            ViewData["title"] = " GOAML Reports Details";
            ViewData["desc"] = "Presents details about the GOAML reports";
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

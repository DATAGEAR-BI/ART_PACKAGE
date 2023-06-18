using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Services.Pdf;

namespace ART_PACKAGE.Controllers
{
    public class GOAMLReportsDetailsController : Controller
    {
        private readonly AuthContext _context;
        private readonly IPdfService _pdfSrv;
        //private readonly IDropDownService _dropDown;
        public GOAMLReportsDetailsController(AuthContext context, IPdfService pdfSrv)
        {
            this._context = context;
            _pdfSrv = pdfSrv;
            //this._dropDown = dropDown;
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
                    //{"Reportcode".ToLower(),_dropDown.GetReportTypeDropDown().ToDynamicList() },
                    //{"Reportstatuscode".ToLower(),_dropDown.GetReportstatuscodeDropDown().ToDynamicList() },
                    //{"Priority".ToLower(),_dropDown.GetReportPriorityDropDown().ToDynamicList() },
                    //{"Rentitybranch".ToLower(),_dropDown.GetNonREntityBranchDropDown().ToDynamicList() },

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(GOAMLReportsDetailsController).ToLower()].SkipList;
            }

            var Data = data.CallData<ArtGoamlReportsDetail>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = _context.ArtGoamlReportsDetails.AsQueryable();
            var bytes = await data.ExportToCSV<ArtGoamlReportsDetail, GenericCsvClassMapper<ArtGoamlReportsDetail, GOAMLReportsDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportsDetailsController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(GOAMLReportsDetailsController).ToLower()].SkipList;
            var data = _context.ArtGoamlReportsDetails.CallData<ArtGoamlReportsDetail>(req).Data.ToList();
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

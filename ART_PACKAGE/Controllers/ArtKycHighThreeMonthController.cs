using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Newtonsoft.Json;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DropDown;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Services.Pdf;
using Data.Data.KYC;

namespace ART_PACKAGE.Controllers
{
    public class ArtKycHighThreeMonthController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public ArtKycHighThreeMonthController(AuthContext dbfcfkc, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this.dbfcfkc = dbfcfkc;
            this._dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtKycHighThreeMonth> data = dbfcfkc.ArtKycHighThreeMonths.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycHighThreeMonthController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycHighThreeMonthController).ToLower()].SkipList;
            }

            var Data = data.CallData<ArtKycHighThreeMonth>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = dbfcfkc.ArtKycHighThreeMonths.AsQueryable();
            var bytes = await data.ExportToCSV<ArtKycHighThreeMonth, GenericCsvClassMapper<ArtKycHighThreeMonth, ArtKycHighThreeMonthController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycHighThreeMonthController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycHighThreeMonthController).ToLower()].SkipList;
            var data = dbfcfkc.ArtKycHighThreeMonths.CallData<ArtKycHighThreeMonth>(req).Data.ToList();
            ViewData["title"] = "High risk within 3 months customers Report";
            ViewData["desc"] = "presents all high-risk customers need to be update their KYCs within 3 months with the related information below";
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

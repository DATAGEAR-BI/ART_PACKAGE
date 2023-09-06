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
    public class ArtKycLowThreeMonthController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public ArtKycLowThreeMonthController(AuthContext dbfcfkc, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this.dbfcfkc = dbfcfkc;
            this._dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtKycLowThreeMonth> data = dbfcfkc.ArtKycLowThreeMonths.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycLowThreeMonthController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() }
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycLowThreeMonthController).ToLower()].SkipList;
            }

            var Data = data.CallData<ArtKycLowThreeMonth>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }
        public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        {
            var data = dbfcfkc.ArtKycLowThreeMonths.AsQueryable();
            var bytes = await data.ExportToCSV<ArtKycLowThreeMonth, GenericCsvClassMapper<ArtKycLowThreeMonth, ArtKycLowThreeMonthController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycLowThreeMonthController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycLowThreeMonthController).ToLower()].SkipList;
            var data = dbfcfkc.ArtKycLowThreeMonths.CallData<ArtKycLowThreeMonth>(req).Data.ToList();
            ViewData["title"] = "Low risk within 3 months customers Report";
            ViewData["desc"] = "presents all low-risk customers need to be update their KYCs within 3 months with the related information below";
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

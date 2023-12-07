using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.KYC;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtKycMediumThreeMonthU3Controller : Controller
    {
        private readonly KYCContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public ArtKycMediumThreeMonthU3Controller(KYCContext dbfcfkc, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this.dbfcfkc = dbfcfkc;
            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtKycMediumThreeMonthU3> data = dbfcfkc.ArtKycMediumThreeMonthU3s.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycMediumThreeMonthU3Controller).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() }
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycMediumThreeMonthU3Controller).ToLower()].SkipList;
            }

            KendoDataDesc<ArtKycMediumThreeMonthU3> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            IQueryable<ArtKycMediumThreeMonthU3> data = dbfcfkc.ArtKycMediumThreeMonthU3s.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtKycMediumThreeMonthU3, GenericCsvClassMapper<ArtKycMediumThreeMonthU3, ArtKycMediumThreeMonthU3Controller>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycMediumThreeMonthU3Controller).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycMediumThreeMonthU3Controller).ToLower()].SkipList;
            List<ArtKycMediumThreeMonthU3> data = dbfcfkc.ArtKycMediumThreeMonthU3s.CallData(req).Data.ToList();
            ViewData["title"] = "Medium risk within 3 months customers U3 Report";
            ViewData["desc"] = "presents all medium-risk customers need to be update their risk within 3 months with the related information below";
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

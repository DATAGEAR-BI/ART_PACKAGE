using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.DropDown;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.CustomReport;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtKycLowOneMonthU4Controller : Controller
    {
        private readonly KYCContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public ArtKycLowOneMonthU4Controller(KYCContext dbfcfkc, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this.dbfcfkc = dbfcfkc;
            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtKycLowOneMonthU4> data = dbfcfkc.ArtKycLowOneMonthU4s.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycLowOneMonthU4Controller).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycLowOneMonthU4Controller).ToLower()].SkipList;
            }

            KendoDataDesc<ArtKycLowOneMonthU4> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            IQueryable<ArtKycLowOneMonthU4> data = dbfcfkc.ArtKycLowOneMonthU4s.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtKycLowOneMonthU4, GenericCsvClassMapper<ArtKycLowOneMonthU4, ArtKycLowOneMonthU4Controller>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycLowOneMonthU4Controller).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycLowOneMonthU4Controller).ToLower()].SkipList;
            List<ArtKycLowOneMonthU4> data = dbfcfkc.ArtKycLowOneMonthU4s.CallData(req).Data.ToList();
            ViewData["title"] = "Low risk within 1 month customers U4 Report";
            ViewData["desc"] = "presents all low-risk customers need to be update their KYCs within 1 month with the related information below";
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

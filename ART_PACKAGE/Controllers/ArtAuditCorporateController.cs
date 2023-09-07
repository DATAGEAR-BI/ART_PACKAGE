using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.DropDown;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.CustomReport;

namespace ART_PACKAGE.Controllers
{
    public class ArtAuditCorporateController : Controller
    {
        private readonly KYCContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public ArtAuditCorporateController(KYCContext dbfcfkc, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this.dbfcfkc = dbfcfkc;
            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtAuditCorporateView> data = dbfcfkc.ArtAuditCorporateViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtAuditCorporateController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() }
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtAuditCorporateController).ToLower()].SkipList;
            }

            KendoDataDesc<ArtAuditCorporateView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            IQueryable<ArtAuditCorporateView> data = dbfcfkc.ArtAuditCorporateViews.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtAuditCorporateView, GenericCsvClassMapper<ArtAuditCorporateView, ArtAuditCorporateController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtAuditCorporateController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtAuditCorporateController).ToLower()].SkipList;
            List<ArtAuditCorporateView> data = dbfcfkc.ArtAuditCorporateViews.CallData(req).Data.ToList();
            ViewData["title"] = "Audit For Corporates Report";
            ViewData["desc"] = "Presents all Corporate customers with the related information as below";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
        public IActionResult Test()
        {
            return Ok(dbfcfkc.ArtAuditCorporateViews.ToList());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

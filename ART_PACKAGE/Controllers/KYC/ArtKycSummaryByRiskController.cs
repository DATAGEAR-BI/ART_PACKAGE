using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtKycSummaryByRiskController : BaseReportController<KYCContext, ArtKycSummaryByRisk>
    {
        public ArtKycSummaryByRiskController(IGridConstructor<KYCContext, ArtKycSummaryByRisk> gridConstructor) : base(gridConstructor)
        {
        }



        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtKycSummaryByRisk> data = dbfcfkc.ArtKycSummaryByRisks.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycSummaryByRiskController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() }
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycSummaryByRiskController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtKycSummaryByRisk> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false
        //    };

        //    return new ContentResult
        //    {
        //        ContentType = "application/json",
        //        Content = JsonConvert.SerializeObject(result)
        //    };
        //}
        //public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        //{
        //    IQueryable<ArtKycSummaryByRisk> data = dbfcfkc.ArtKycSummaryByRisks.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtKycSummaryByRisk, GenericCsvClassMapper<ArtKycSummaryByRisk, ArtKycSummaryByRiskController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycSummaryByRiskController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycSummaryByRiskController).ToLower()].SkipList;
        //    List<ArtKycSummaryByRisk> data = dbfcfkc.ArtKycSummaryByRisks.CallData(req).Data.ToList();
        //    ViewData["title"] = "KYC Summary By Risk Report";
        //    ViewData["desc"] = "presents the Kyc Summary By Risk with the related information below";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}
        public override IActionResult Index()
        {
            return View();
        }
    }
}

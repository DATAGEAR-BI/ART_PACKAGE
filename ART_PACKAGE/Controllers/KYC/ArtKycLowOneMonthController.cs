using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtKycLowOneMonthController : BaseReportController<KYCContext, ArtKycLowOneMonth>
    {
        public ArtKycLowOneMonthController(IGridConstructor<KYCContext, ArtKycLowOneMonth> gridConstructor) : base(gridConstructor)
        {
        }



        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtKycLowOneMonth> data = dbfcfkc.ArtKycLowOneMonths.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycLowOneMonthController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycLowOneMonthController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtKycLowOneMonth> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //    };

        //    return new ContentResult
        //    {
        //        ContentType = "application/json",
        //        Content = JsonConvert.SerializeObject(result)
        //    };
        //}

        //public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        //{
        //    IQueryable<ArtKycLowOneMonth> data = dbfcfkc.ArtKycLowOneMonths.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtKycLowOneMonth, GenericCsvClassMapper<ArtKycLowOneMonth, ArtKycLowOneMonthController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycLowOneMonthController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycLowOneMonthController).ToLower()].SkipList;
        //    List<ArtKycLowOneMonth> data = dbfcfkc.ArtKycLowOneMonths.CallData(req).Data.ToList();
        //    ViewData["title"] = "Low risk within 1 month customers Report";
        //    ViewData["desc"] = "presents all low-risk customers need to be update their KYCs within 1 month with the related information below";
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

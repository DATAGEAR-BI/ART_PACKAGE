using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;
using Data.Services;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtKycLowThreeMonthController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtKycLowThreeMonth>, KYCContext, ArtKycLowThreeMonth>, IBaseRepo<KYCContext, ArtKycLowThreeMonth>, KYCContext, ArtKycLowThreeMonth>
    {
        public ArtKycLowThreeMonthController(IGridConstructor<IBaseRepo<KYCContext, ArtKycLowThreeMonth>, KYCContext, ArtKycLowThreeMonth> gridConstructor) : base(gridConstructor)
        {
        }



        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtKycLowThreeMonth> data = dbfcfkc.ArtKycLowThreeMonths.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycLowThreeMonthController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() }
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycLowThreeMonthController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtKycLowThreeMonth> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    IQueryable<ArtKycLowThreeMonth> data = dbfcfkc.ArtKycLowThreeMonths.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtKycLowThreeMonth, GenericCsvClassMapper<ArtKycLowThreeMonth, ArtKycLowThreeMonthController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycLowThreeMonthController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycLowThreeMonthController).ToLower()].SkipList;
        //    List<ArtKycLowThreeMonth> data = dbfcfkc.ArtKycLowThreeMonths.CallData(req).Data.ToList();
        //    ViewData["title"] = "Low risk within 3 months customers Report";
        //    ViewData["desc"] = "presents all low-risk customers need to be update their KYCs within 3 months with the related information below";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}
        public override IActionResult Index()
        {
            return View();
        }
    }
}

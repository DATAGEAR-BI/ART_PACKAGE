using ART_PACKAGE.Helpers.Grid;
using Data.Data.KYC;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtKycMediumThreeMonthController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtKycMediumThreeMonth>, KYCContext, ArtKycMediumThreeMonth>, IBaseRepo<KYCContext, ArtKycMediumThreeMonth>, KYCContext, ArtKycMediumThreeMonth>
    {
        public ArtKycMediumThreeMonthController(IGridConstructor<IBaseRepo<KYCContext, ArtKycMediumThreeMonth>, KYCContext, ArtKycMediumThreeMonth> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtKycMediumThreeMonth> data = dbfcfkc.ArtKycMediumThreeMonths.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycMediumThreeMonthController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() }
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycMediumThreeMonthController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtKycMediumThreeMonth> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    IQueryable<ArtKycMediumThreeMonth> data = dbfcfkc.ArtKycMediumThreeMonths.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtKycMediumThreeMonth, GenericCsvClassMapper<ArtKycMediumThreeMonth, ArtKycMediumThreeMonthController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycMediumThreeMonthController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycMediumThreeMonthController).ToLower()].SkipList;
        //    List<ArtKycMediumThreeMonth> data = dbfcfkc.ArtKycMediumThreeMonths.CallData(req).Data.ToList();
        //    ViewData["title"] = "Medium risk within 3 months customers Report";
        //    ViewData["desc"] = "presents all medium-risk customers need to be update their KYCs within 3 months with the related information below";
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

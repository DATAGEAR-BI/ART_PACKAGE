using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtKycHighThreeMonthController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtKycHighThreeMonth>, KYCContext, ArtKycHighThreeMonth>, IBaseRepo<KYCContext, ArtKycHighThreeMonth>, KYCContext, ArtKycHighThreeMonth>
    {
        public ArtKycHighThreeMonthController(IGridConstructor<IBaseRepo<KYCContext, ArtKycHighThreeMonth>, KYCContext, ArtKycHighThreeMonth> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtKycHighThreeMonth> data = dbfcfkc.ArtKycHighThreeMonths.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycHighThreeMonthController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycHighThreeMonthController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtKycHighThreeMonth> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    IQueryable<ArtKycHighThreeMonth> data = dbfcfkc.ArtKycHighThreeMonths.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtKycHighThreeMonth, GenericCsvClassMapper<ArtKycHighThreeMonth, ArtKycHighThreeMonthController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycHighThreeMonthController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycHighThreeMonthController).ToLower()].SkipList;
        //    List<ArtKycHighThreeMonth> data = dbfcfkc.ArtKycHighThreeMonths.CallData(req).Data.ToList();
        //    ViewData["title"] = "High risk within 3 months customers Report";
        //    ViewData["desc"] = "presents all high-risk customers need to be update their KYCs within 3 months with the related information below";
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

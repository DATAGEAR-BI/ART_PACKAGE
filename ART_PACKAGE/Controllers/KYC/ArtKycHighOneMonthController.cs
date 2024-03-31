using ART_PACKAGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;
using Data.Services;
using Microsoft.AspNetCore.Identity;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtKycHighOneMonthController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtKycHighOneMonth>, KYCContext, ArtKycHighOneMonth>, IBaseRepo<KYCContext, ArtKycHighOneMonth>, KYCContext, ArtKycHighOneMonth>
    {
        public ArtKycHighOneMonthController(IGridConstructor<IBaseRepo<KYCContext, ArtKycHighOneMonth>, KYCContext, ArtKycHighOneMonth> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtKycHighOneMonth> data = dbfcfkc.ArtKycHighOneMonths.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycHighOneMonthController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycHighOneMonthController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtKycHighOneMonth> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    IQueryable<ArtKycHighOneMonth> data = dbfcfkc.ArtKycHighOneMonths.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtKycHighOneMonth, GenericCsvClassMapper<ArtKycHighOneMonth, ArtKycHighOneMonthController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycHighOneMonthController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycHighOneMonthController).ToLower()].SkipList;
        //    List<ArtKycHighOneMonth> data = dbfcfkc.ArtKycHighOneMonths.CallData(req).Data.ToList();
        //    ViewData["title"] = "High risk within 1 month customers Report";
        //    ViewData["desc"] = "presents all high-risk customers need to be update their KYCs within 1 month with the related information below";
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

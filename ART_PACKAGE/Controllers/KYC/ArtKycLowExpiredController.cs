using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtKycLowExpiredController : BaseReportController<IBaseRepo<KYCContext, ArtKycLowExpired>, KYCContext, ArtKycLowExpired>
    {
        public ArtKycLowExpiredController(IGridConstructor<IBaseRepo<KYCContext, ArtKycLowExpired>, KYCContext, ArtKycLowExpired> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtKycLowExpired> data = dbfcfkc.ArtKycLowExpireds.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycLowExpiredController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycLowExpiredController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtKycLowExpired> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    IQueryable<ArtKycLowExpired> data = dbfcfkc.ArtKycLowExpireds.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtKycLowExpired, GenericCsvClassMapper<ArtKycLowExpired, ArtKycLowExpiredController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycLowExpiredController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycLowExpiredController).ToLower()].SkipList;
        //    List<ArtKycLowExpired> data = dbfcfkc.ArtKycLowExpireds.CallData(req).Data.ToList();
        //    ViewData["title"] = "Low risk expired customers Report";
        //    ViewData["desc"] = "presents all low-risk customers need to be update their expired KYCs with the related information below";
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

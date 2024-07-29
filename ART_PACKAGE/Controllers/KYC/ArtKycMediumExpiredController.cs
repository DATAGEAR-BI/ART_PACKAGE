using ART_PACKAGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;
using Data.Services;
using Microsoft.AspNetCore.Identity;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtKycMediumExpiredController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtKycMediumExpired>, KYCContext, ArtKycMediumExpired>, IBaseRepo<KYCContext, ArtKycMediumExpired>, KYCContext, ArtKycMediumExpired>
    {
        public ArtKycMediumExpiredController(IGridConstructor<IBaseRepo<KYCContext, ArtKycMediumExpired>, KYCContext, ArtKycMediumExpired> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtKycMediumExpired> data = dbfcfkc.ArtKycMediumExpireds.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycMediumExpiredController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() }
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycMediumExpiredController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtKycMediumExpired> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    IQueryable<ArtKycMediumExpired> data = dbfcfkc.ArtKycMediumExpireds.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtKycMediumExpired, GenericCsvClassMapper<ArtKycMediumExpired, ArtKycMediumExpiredController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycMediumExpiredController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycMediumExpiredController).ToLower()].SkipList;
        //    List<ArtKycMediumExpired> data = dbfcfkc.ArtKycMediumExpireds.CallData(req).Data.ToList();
        //    ViewData["title"] = "Medium risk expired customers Report";
        //    ViewData["desc"] = "presents all medium-risk customers need to be update their expired KYCs with the related information below";
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

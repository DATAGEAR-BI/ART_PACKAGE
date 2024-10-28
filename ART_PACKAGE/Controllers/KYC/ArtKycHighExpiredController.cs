using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;
using Data.Services;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtKycHighExpiredController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtKycHighExpired>, KYCContext, ArtKycHighExpired>, IBaseRepo<KYCContext, ArtKycHighExpired>, KYCContext, ArtKycHighExpired>
    {
        public ArtKycHighExpiredController(IGridConstructor<IBaseRepo<KYCContext, ArtKycHighExpired>, KYCContext, ArtKycHighExpired> gridConstructor) : base(gridConstructor)
        {
        }



        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtKycHighExpired> data = dbfcfkc.ArtKycHighExpireds.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycHighExpiredController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycHighExpiredController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtKycHighExpired> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    IQueryable<ArtKycHighExpired> data = dbfcfkc.ArtKycHighExpireds.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtKycHighExpired, GenericCsvClassMapper<ArtKycHighExpired, ArtKycHighExpiredController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycHighExpiredController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycHighExpiredController).ToLower()].SkipList;
        //    List<ArtKycHighExpired> data = dbfcfkc.ArtKycHighExpireds.CallData(req).Data.ToList();
        //    ViewData["title"] = "High risk expired customers Report";
        //    ViewData["desc"] = "presents all high-risk customers need to be update their expired KYCs with the related information below";
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

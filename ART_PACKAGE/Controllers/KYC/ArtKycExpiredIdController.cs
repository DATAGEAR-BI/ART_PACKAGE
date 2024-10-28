using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;
using Data.Services;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtKycExpiredIdController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtKycExpiredId>, KYCContext, ArtKycExpiredId>, IBaseRepo<KYCContext, ArtKycExpiredId>, KYCContext, ArtKycExpiredId>
    {
        public ArtKycExpiredIdController(IGridConstructor<IBaseRepo<KYCContext, ArtKycExpiredId>, KYCContext, ArtKycExpiredId> gridConstructor) : base(gridConstructor)
        {
        }



        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtKycExpiredId> data = dbfcfkc.ArtKycExpiredIds.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycExpiredIdController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycExpiredIdController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtKycExpiredId> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    IQueryable<ArtKycExpiredId> data = dbfcfkc.ArtKycExpiredIds.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtKycExpiredId, GenericCsvClassMapper<ArtKycExpiredId, ArtKycExpiredIdController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycExpiredIdController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycExpiredIdController).ToLower()].SkipList;
        //    List<ArtKycExpiredId> data = dbfcfkc.ArtKycExpiredIds.CallData(req).Data.ToList();
        //    ViewData["title"] = "Expired ID customers Report";
        //    ViewData["desc"] = "Presents all expired ID customers need to be update their expired IDs with the related information below";
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

using ART_PACKAGE.Helpers.Grid;
using Data.Data.KYC;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtAuditCorporateController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtAuditCorporateView>, KYCContext, ArtAuditCorporateView>, IBaseRepo<KYCContext, ArtAuditCorporateView>, KYCContext, ArtAuditCorporateView>
    {
        public ArtAuditCorporateController(IGridConstructor<IBaseRepo<KYCContext, ArtAuditCorporateView>, KYCContext, ArtAuditCorporateView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtAuditCorporateView> data = dbfcfkc.ArtAuditCorporateViews.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ArtAuditCorporateController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() }
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtAuditCorporateController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtAuditCorporateView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    IQueryable<ArtAuditCorporateView> data = dbfcfkc.ArtAuditCorporateViews.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtAuditCorporateView, GenericCsvClassMapper<ArtAuditCorporateView, ArtAuditCorporateController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ArtAuditCorporateController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtAuditCorporateController).ToLower()].SkipList;
        //    List<ArtAuditCorporateView> data = dbfcfkc.ArtAuditCorporateViews.CallData(req).Data.ToList();
        //    ViewData["title"] = "Audit For Corporates Report";
        //    ViewData["desc"] = "Presents all Corporate customers with the related information as below";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}
        //public IActionResult Test()
        //{
        //    return Ok(dbfcfkc.ArtAuditCorporateViews.ToList());
        //}
        public override IActionResult Index()
        {
            return View();
        }
    }
}

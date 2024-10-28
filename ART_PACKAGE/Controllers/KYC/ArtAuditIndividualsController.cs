using ART_PACKAGE.Helpers.Grid;
using Data.Data.KYC;
using Data.Services;
using Microsoft.AspNetCore.Mvc;


namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtAuditIndividualsController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtAuditIndividualsView>, KYCContext, ArtAuditIndividualsView>, IBaseRepo<KYCContext, ArtAuditIndividualsView>, KYCContext, ArtAuditIndividualsView>
    {
        public ArtAuditIndividualsController(IGridConstructor<IBaseRepo<KYCContext, ArtAuditIndividualsView>, KYCContext, ArtAuditIndividualsView> gridConstructor) : base(gridConstructor)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtAuditIndividualsView> data = dbfcfkc.ArtAuditIndividualsViews.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ArtAuditIndividualsController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() }
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtAuditIndividualsController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtAuditIndividualsView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    IQueryable<ArtAuditIndividualsView> data = dbfcfkc.ArtAuditIndividualsViews.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtAuditIndividualsView, GenericCsvClassMapper<ArtAuditIndividualsView, ArtAuditIndividualsController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ArtAuditIndividualsController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtAuditIndividualsController).ToLower()].SkipList;
        //    List<ArtAuditIndividualsView> data = dbfcfkc.ArtAuditIndividualsViews.CallData(req).Data.ToList();
        //    ViewData["title"] = "Audit For Individuals Report";
        //    ViewData["desc"] = "Presents all individual customers with the related information as below";
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

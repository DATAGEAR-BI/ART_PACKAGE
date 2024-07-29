using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "RiskAssessment")]
    public class RiskAssessmentController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, ArtRiskAssessmentView>, SasAmlContext, ArtRiskAssessmentView>, IBaseRepo<SasAmlContext, ArtRiskAssessmentView>, SasAmlContext, ArtRiskAssessmentView>
    {
        public RiskAssessmentController(IGridConstructor<IBaseRepo<SasAmlContext, ArtRiskAssessmentView>, SasAmlContext, ArtRiskAssessmentView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtRiskAssessmentView> data = dbfcfcore.ArtRiskAssessmentViews.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(RiskAssessmentController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            {"AssessmentTypeCd".ToLower(),_dropDown.GetAssessmentTypeDropDown().ToDynamicList() },
        //            {"CreateUserId".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
        //            {"RiskStatus".ToLower(),_dropDown.GetRiskStatusDropDown().ToDynamicList() },
        //            {"RiskClass".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
        //            {"ProposedRiskClass".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
        //            {"OwnerUserLongId".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() }
        //        };
        //    }


        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(RiskAssessmentController).ToLower()].SkipList;
        //    KendoDataDesc<ArtRiskAssessmentView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

        //public async Task<IActionResult> Export([FromBody] ExportDto<decimal> req)
        //{
        //    IQueryable<ArtRiskAssessmentView> data = dbfcfcore.ArtRiskAssessmentViews.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtRiskAssessmentView, GenericCsvClassMapper<ArtRiskAssessmentView, RiskAssessmentController>>(req.Req);
        //    return File(bytes, "test/csv");
        //}


        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(RiskAssessmentController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(RiskAssessmentController).ToLower()].SkipList;
        //    List<ArtRiskAssessmentView> data = dbfcfcore.ArtRiskAssessmentViews.CallData(req).Data.ToList();
        //    ViewData["title"] = "Risk Assessment Details";
        //    ViewData["desc"] = "Presents the Risk details";
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

using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "CasesDetails")]
    public class CasesDetailsController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, ArtAmlCaseDetailsView>, SasAmlContext, ArtAmlCaseDetailsView>, IBaseRepo<SasAmlContext, ArtAmlCaseDetailsView>, SasAmlContext, ArtAmlCaseDetailsView>
    {
        public CasesDetailsController(IGridConstructor<IBaseRepo<SasAmlContext, ArtAmlCaseDetailsView>, SasAmlContext, ArtAmlCaseDetailsView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtAmlCaseDetailsView> data = dbfcfkc.ArtAmlCaseDetailsViews.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            {"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
        //            {"CasePriority".ToLower(),_dropDown.GetCasePriorityDropDown().ToDynamicList() },
        //            {"CaseCategory".ToLower(),_dropDown.GetCaseCategoryDropDown().ToDynamicList() },
        //            {"CaseSubCategory".ToLower(),_dropDown.GetCaseSubCategoryDropDown().ToDynamicList() },
        //            {"CreatedBy".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
        //            {"Owner".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
        //            {"EntityLevel".ToLower(),_dropDown.GetEntityLevelDropDown().ToDynamicList() }
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtAmlCaseDetailsView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        toolbar = new List<dynamic>
        //        {
        //            /*new
        //            {
        //                text = "Delete Cases",
        //                id="dltCases",
        //                show = User.IsInRole("Delete_Cases")
        //            }*/
        //        },

        //    };

        //    return new ContentResult
        //    {
        //        ContentType = "application/json",
        //        Content = JsonConvert.SerializeObject(result)
        //    };
        //}

        /*public IActionResult Export([FromBody] ExportDto<decimal> req)
        {
            var data = dbfcfkc.AmlCaseDetailViews.AsQueryable();
            var bytes = data.ExportToCSV<AmlCaseDetailView>(req.Req);
            return File(bytes, "test/csv");
        }*/
        //public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        //{
        //    IQueryable<ArtAmlCaseDetailsView> data = dbfcfkc.ArtAmlCaseDetailsViews.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtAmlCaseDetailsView, GenericCsvClassMapper<ArtAmlCaseDetailsView, CasesDetailsController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].SkipList;
        //    List<ArtAmlCaseDetailsView> data = dbfcfkc.ArtAmlCaseDetailsViews.CallData(req).Data.ToList();
        //    ViewData["title"] = "Cases Details";
        //    ViewData["desc"] = "Presents the cases details in the table below";
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

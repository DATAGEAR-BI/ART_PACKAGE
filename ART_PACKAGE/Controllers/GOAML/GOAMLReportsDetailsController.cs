using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTGOAML;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.GOAML
{
    public class GOAMLReportsDetailsController : BaseReportController<IGridConstructor<IBaseRepo<ArtGoAmlContext, ArtGoamlReportsDetail>, ArtGoAmlContext, ArtGoamlReportsDetail>, IBaseRepo<ArtGoAmlContext, ArtGoamlReportsDetail>, ArtGoAmlContext, ArtGoamlReportsDetail>
    {
        public GOAMLReportsDetailsController(IGridConstructor<IBaseRepo<ArtGoAmlContext, ArtGoamlReportsDetail>, ArtGoAmlContext, ArtGoamlReportsDetail> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtGoamlReportsDetail> data = _context.ArtGoamlReportsDetails.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;
        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportsDetailsController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            {"Reportcode".ToLower(),_dropDown.GetReportTypeDropDown().ToDynamicList() },
        //            {"Reportstatuscode".ToLower(),_dropDown.GetReportstatuscodeDropDown().ToDynamicList() },
        //            {"Priority".ToLower(),_dropDown.GetReportPriorityDropDown().ToDynamicList() },
        //            {"Rentitybranch".ToLower(),_dropDown.GetNonREntityBranchDropDown().ToDynamicList() },

        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(GOAMLReportsDetailsController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtGoamlReportsDetail> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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


        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportsDetailsController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(GOAMLReportsDetailsController).ToLower()].SkipList;
        //    List<ArtGoamlReportsDetail> data = _context.ArtGoamlReportsDetails.CallData(req).Data.ToList();
        //    ViewData["title"] = " GOAML Reports Details";
        //    ViewData["desc"] = "Presents details about the GOAML reports";
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

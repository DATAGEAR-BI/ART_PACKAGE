using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTGOAML;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.GOAML
{
    public class GOAMLReportIndicatorDetailsController : BaseReportController<IBaseRepo<ArtGoAmlContext, ArtGoamlReportsIndicator>, ArtGoAmlContext, ArtGoamlReportsIndicator>
    {
        public GOAMLReportIndicatorDetailsController(IGridConstructor<IBaseRepo<ArtGoAmlContext, ArtGoamlReportsIndicator>, ArtGoAmlContext, ArtGoamlReportsIndicator> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtGoamlReportsIndicator> data = _context.ArtGoamlReportsIndicators.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;
        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportIndicatorDetailsController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            {"Indicator".ToLower(),_dropSrv.GetReportIndicatorDropDown().ToDynamicList() },
        //        };
        //        ColumnsToSkip = new List<string>
        //        {
        //        };
        //    }


        //    KendoDataDesc<ArtGoamlReportsIndicator> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportIndicatorDetailsController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(GOAMLReportIndicatorDetailsController).ToLower()].SkipList;
        //    List<ArtGoamlReportsIndicator> data = _context.ArtGoamlReportsIndicators.CallData(req).Data.ToList();
        //    ViewData["title"] = "GOAML Reports Indicatores";
        //    ViewData["desc"] = "Presents each GOAML report with the related indicators";
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

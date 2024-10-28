using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "OSTransactionsByNonPri")]


    public class OSTransactionsByNonPriController : BaseReportController<IGridConstructor<IBaseRepo<FTIContext, ArtTiOsTransByNonpriReport>, FTIContext, ArtTiOsTransByNonpriReport>, IBaseRepo<FTIContext, ArtTiOsTransByNonpriReport>, FTIContext, ArtTiOsTransByNonpriReport>
    {
        public OSTransactionsByNonPriController(IGridConstructor<IBaseRepo<FTIContext, ArtTiOsTransByNonpriReport>, FTIContext, ArtTiOsTransByNonpriReport> gridConstructor) : base(gridConstructor)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtTiOsTransByNonpriReport> data = fti.ArtTiOsTransByNonpriReports.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {

        //        DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsByNonPriController).ToLower()].DisplayNames;

        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //    {
        //        {"BhalfBrn".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.BhalfBrn).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Address1".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Address1).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Sovalue".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Descrip".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Descrip).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"MasterRef".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Partptd".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Partptd).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Revolving".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Revolving).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Outstccy".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Ccy".ToLower(),fti.ArtTiOsTransByNonpriReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },
        //    };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSTransactionsByNonPriController).ToLower()].SkipList;

        //    }
        //    KendoDataDesc<ArtTiOsTransByNonpriReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        toolbar = new List<dynamic>
        //        {


        //        },
        //        reportname = "OSTransactionsByNonPri"
        //    };

        //    return new ContentResult
        //    {
        //        ContentType = "application/json",
        //        Content = JsonConvert.SerializeObject(result)
        //    };
        //}
        public override IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsByNonPriController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSTransactionsByNonPriController).ToLower()].SkipList;
        //    List<ArtTiOsTransByNonpriReport> data = fti.ArtTiOsTransByNonpriReports.CallData(req).Data.ToList();
        //    ViewData["title"] = "OS Transactions By Non-Pri Report";
        //    ViewData["desc"] = "This report produces information for non-principal parties instead of principal parties. All totals are in the reporting currency if one is specified, otherwise in base currency";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}
    }
}

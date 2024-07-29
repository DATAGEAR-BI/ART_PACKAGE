using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "PeriodicCHRGs")]


    public class PeriodicCHRGsController : BaseReportController<IGridConstructor<IBaseRepo<FTIContext, ArtTiPeriodicChrgsReport>, FTIContext, ArtTiPeriodicChrgsReport>, IBaseRepo<FTIContext, ArtTiPeriodicChrgsReport>, FTIContext, ArtTiPeriodicChrgsReport>
    {
        public PeriodicCHRGsController(IGridConstructor<IBaseRepo<FTIContext, ArtTiPeriodicChrgsReport>, FTIContext, ArtTiPeriodicChrgsReport> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtTiPeriodicChrgsReport> data = fti.ArtTiPeriodicChrgsReports.AsQueryable();
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(PeriodicCHRGsController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //    {
        //        {"Fullname".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Fullname).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Sovalue".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Descr".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Descr).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Descri56".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Descri56).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Address1".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Address1).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"MasterRef".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Payrec".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Payrec).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"AdvArr".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.AdvArr).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Outstccy".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"AccrueCcy".ToLower(),fti.ArtTiPeriodicChrgsReports.Select(x=>x.AccrueCcy).Distinct().Where(x=> x != null ).ToDynamicList() },
        //    };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(PeriodicCHRGsController).ToLower()].SkipList;
        //    }
        //    KendoDataDesc<ArtTiPeriodicChrgsReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        toolbar = new List<dynamic>
        //        {


        //        },
        //        reportname = "PeriodicCHRGs"
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
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(PeriodicCHRGsController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(PeriodicCHRGsController).ToLower()].SkipList;
        //    List<ArtTiPeriodicChrgsReport> data = fti.ArtTiPeriodicChrgsReports.CallData(req).Data.ToList();
        //    ViewData["title"] = "Amortization Report";
        //    ViewData["desc"] = "This report produces all transactions which have not yet expired and which have periodic charges either accruing or amortising within a period that you can specify";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}

    }
}

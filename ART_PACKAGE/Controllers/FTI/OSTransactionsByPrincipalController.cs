using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "OSTransactionsByPrincipal")]


    public class OSTransactionsByPrincipalController : BaseReportController<IGridConstructor<IBaseRepo<FTIContext, ArtTiOsTransByPrincipalReport>, FTIContext, ArtTiOsTransByPrincipalReport>, IBaseRepo<FTIContext, ArtTiOsTransByPrincipalReport>, FTIContext, ArtTiOsTransByPrincipalReport>
    {
        public OSTransactionsByPrincipalController(IGridConstructor<IBaseRepo<FTIContext, ArtTiOsTransByPrincipalReport>, FTIContext, ArtTiOsTransByPrincipalReport> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtTiOsTransByPrincipalReport> data = fti.ArtTiOsTransByPrincipalReports.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {

        //        DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsByPrincipalController).ToLower()].DisplayNames;

        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //    {
        //      {"BhalfBrn".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.BhalfBrn).Distinct().Where(x=> x != null ).ToDynamicList() },
        //      {"Address1".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Address1).Distinct().Where(x=> x != null ).ToDynamicList() },
        //      {"Sovalue".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Sovalue).Distinct().Where(x=> x != null ).ToDynamicList() },
        //      {"Descrip".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Descrip).Distinct().Where(x=> x != null ).ToDynamicList() },
        //      {"MasterRef".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
        //      {"Partptd".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Partptd).Distinct().Where(x=> x != null ).ToDynamicList() },
        //      {"Revolving".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Revolving).Distinct().Where(x=> x != null ).ToDynamicList() },
        //      {"Outstccy".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null ).ToDynamicList() },
        //      {"Ccy".ToLower(),fti.ArtTiOsTransByPrincipalReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },
        //    };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSTransactionsByPrincipalController).ToLower()].SkipList;

        //    }
        //    KendoDataDesc<ArtTiOsTransByPrincipalReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        toolbar = new List<dynamic>
        //        {

        //        },
        //        reportname = "OSTransactionsByPrincipal"
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
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsByPrincipalController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSTransactionsByPrincipalController).ToLower()].SkipList;
        //    List<ArtTiOsTransByPrincipalReport> data = fti.ArtTiOsTransByPrincipalReports.CallData(req).Data.ToList();
        //    ViewData["title"] = "OS Transactions By Principal Report";
        //    ViewData["desc"] = "This report produces list information for master records that are not yet booked off or cancelled";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}
    }
}

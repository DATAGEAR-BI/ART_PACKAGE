using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "OSTransactionsAwaitiApprl")]


    public class OSTransactionsAwaitiApprlController : BaseReportController<IBaseRepo<FTIContext, ArtTiOsTransAwaitiApprlReport>, FTIContext, ArtTiOsTransAwaitiApprlReport>
    {
        public OSTransactionsAwaitiApprlController(IGridConstructor<IBaseRepo<FTIContext, ArtTiOsTransAwaitiApprlReport>, FTIContext, ArtTiOsTransAwaitiApprlReport> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtTiOsTransAwaitiApprlReport> data = fti.ArtTiOsTransAwaitiApprlReports.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {

        //        DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsAwaitiApprlController).ToLower()].DisplayNames;

        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //    {
        //        {"Fullname".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Fullname).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Descri56".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Descri56).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"MasterRef".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"EventReference".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.EventReference).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Status".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Status).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"PcpAddress1".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.PcpAddress1).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"NpcpAddress1".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.NpcpAddress1).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Ccy".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Lstmoduser".ToLower(),fti.ArtTiOsTransAwaitiApprlReports.Select(x=>x.Lstmoduser).Distinct().Where(x=> x != null ).ToDynamicList() },
        //    };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSTransactionsAwaitiApprlController).ToLower()].SkipList;

        //    }
        //    KendoDataDesc<ArtTiOsTransAwaitiApprlReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        toolbar = new List<dynamic>
        //        {
        //        },
        //        reportname = "OSTransactionsAwaitiApprl"
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
        //    List<ArtTiOsTransAwaitiApprlReport> data = fti.ArtTiOsTransAwaitiApprlReports.CallData(req).Data.ToList();
        //    ViewData["title"] = "OS Transactions Awaiti Apprl Report";
        //    ViewData["desc"] = "This report produces information transactions awaiting credit approval only with the related master records and the related events have been initiated with the related status";

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(OSTransactionsAwaitiApprlController).ToLower()].DisplayNames;
        //    List<string> columnsToPrint = new()
        //    { nameof(ArtTiOsTransAwaitiApprlReport.MasterRef)
        //    , nameof(ArtTiOsTransAwaitiApprlReport.EventReference)
        //    , nameof(ArtTiOsTransAwaitiApprlReport.PcpAddress1)
        //    , nameof(ArtTiOsTransAwaitiApprlReport.NpcpAddress1)
        //    , nameof(ArtTiOsTransAwaitiApprlReport.Amount)
        //    , nameof(ArtTiOsTransAwaitiApprlReport.Ccy)
        //    , nameof(ArtTiOsTransAwaitiApprlReport.Status)
        //    , nameof(ArtTiOsTransAwaitiApprlReport.Lstmoduser)
        //    };
        //    List<string> ColumnsToSkip = typeof(ArtTiOsTransAwaitiApprlReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

        //    if (req.Group is not null && req.Group.Count != 0)
        //    {
        //        byte[] pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, ControllerContext
        //                                           , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
        //        return File(pdfBytes, "application/pdf");
        //    }
        //    else
        //    {
        //        byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 8
        //                                           , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //        return File(pdfBytes, "application/pdf");
        //    }
        //}
    }
}

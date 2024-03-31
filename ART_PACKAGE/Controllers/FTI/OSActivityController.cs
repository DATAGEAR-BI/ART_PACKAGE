using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "OSActivity")]


    public class OSActivityController : BaseReportController<IGridConstructor<IBaseRepo<FTIContext, ArtTiOsActivityReport>, FTIContext, ArtTiOsActivityReport>, IBaseRepo<FTIContext, ArtTiOsActivityReport>, FTIContext, ArtTiOsActivityReport>
    {
        public OSActivityController(IGridConstructor<IBaseRepo<FTIContext, ArtTiOsActivityReport>, FTIContext, ArtTiOsActivityReport> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtTiOsActivityReport> data = fti.ArtTiOsActivityReports.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {

        //        DisplayNames = ReportsConfig.CONFIG[nameof(OSActivityController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //    {
        //        {"BranchName".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.BranchName).Distinct()     .Where(x=> x != null)          .ToDynamicList() },
        //        {"Team".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Team).Distinct()                 .Where(x=> x != null)          .ToDynamicList() },
        //        {"MasterRef".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.MasterRef).Distinct()       .Where(x=> x != null)          .ToDynamicList() },
        //        {"Product".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Product).Distinct()           .Where(x=> x != null)          .ToDynamicList() },
        //        {"Descrip".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Descrip).Distinct()           .Where(x=> x != null)          .ToDynamicList() },
        //        {"Address1".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Address1).Distinct()         .Where(x=> x != null)          .ToDynamicList() },
        //        {"Ccy".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Ccy).Distinct()                   .Where(x=> x != null)          .ToDynamicList() },
        //    };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(OSActivityController).ToLower()].SkipList;

        //    }
        //    KendoDataDesc<ArtTiOsActivityReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        toolbar = new List<dynamic>
        //        {


        //        },
        //        reportname = "OSActivity"
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
        //    List<ArtTiOsActivityReport> data = fti.ArtTiOsActivityReports.CallData(req).Data.ToList();
        //    ViewData["title"] = "OS Activity Report";
        //    ViewData["desc"] = "This report produces information for master records, showing what events have been initiated for each master record and the status of the current active steps for each event within it";

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(OSActivityController).ToLower()].DisplayNames;
        //    List<string> columnsToPrint = new()
        //    { nameof(ArtTiOsActivityReport.MasterRef)
        //    , nameof(ArtTiOsActivityReport.Product)
        //    , nameof(ArtTiOsActivityReport.Descrip)
        //    , nameof(ArtTiOsActivityReport.Address1)
        //    , nameof(ArtTiOsActivityReport.Amount)
        //    , nameof(ArtTiOsActivityReport.Ccy)

        //    };
        //    List<string> ColumnsToSkip = typeof(ArtTiOsActivityReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

        //    if (req.Group is not null && req.Group.Count != 0)
        //    {
        //        byte[] pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, ControllerContext
        //                                           , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
        //        return File(pdfBytes, "application/pdf");
        //    }
        //    else
        //    {
        //        byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 6
        //                                           , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //        return File(pdfBytes, "application/pdf");
        //    }
        //}

    }
}

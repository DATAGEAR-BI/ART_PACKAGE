using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "SystemTailoring")]


    public class SystemTailoringController : BaseReportController<IBaseRepo<FTIContext, ArtTiSystemTailoringReport>, FTIContext, ArtTiSystemTailoringReport>
    {
        public SystemTailoringController(IGridConstructor<IBaseRepo<FTIContext, ArtTiSystemTailoringReport>, FTIContext, ArtTiSystemTailoringReport> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtTiSystemTailoringReport> data = fti.ArtTiSystemTailoringReports.AsQueryable();
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(SystemTailoringController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //    {
        //        {"Paramsetdescr".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Paramsetdescr).Distinct().Where(x=> x != null ).ToDynamicList() },
        //            {"Prodlongname".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Prodlongname).Distinct().Where(x=> x != null ).ToDynamicList() },
        //            {"Eventlongname".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Eventlongname).Distinct().Where(x=> x != null ).ToDynamicList() },
        //            {"Attachment".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Attachment).Distinct().Where(x=> x != null ).ToDynamicList() },
        //            {"Mappingtype".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Mappingtype).Distinct().Where(x=> x != null ).ToDynamicList() },
        //            {"Templateid".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Templateid).Distinct().Where(x=> x != null ).ToDynamicList() },
        //            {"Optional".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Optional).Distinct().Where(x=> x != null ).ToDynamicList() },
        //            {"Templatedescr".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Templatedescr).Distinct().Where(x=> x != null ).ToDynamicList() },
        //    };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(SystemTailoringController).ToLower()].SkipList;

        //    }
        //    KendoDataDesc<ArtTiSystemTailoringReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        toolbar = new List<dynamic>
        //        {

        //        },
        //        reportname = "SystemTailoring"
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
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(SystemTailoringController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(SystemTailoringController).ToLower()].SkipList;
        //    List<ArtTiSystemTailoringReport> data = fti.ArtTiSystemTailoringReports.CallData(req).Data.ToList();
        //    ViewData["title"] = "System Tailoring Report";
        //    ViewData["desc"] = "This report produces rules conditions and parameter code details";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}
    }
}

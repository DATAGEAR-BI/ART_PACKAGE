using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI
{

    ////////[Authorize(Policy = "Licensed" , Roles = "Activity")]


    public class AdvancePaymentUtilizationController : BaseReportController<IGridConstructor<IBaseRepo<FTIContext, ArtTiAdvancePaymentUtilizationReport>, FTIContext, ArtTiAdvancePaymentUtilizationReport>, IBaseRepo<FTIContext, ArtTiAdvancePaymentUtilizationReport>, FTIContext, ArtTiAdvancePaymentUtilizationReport>
    {
        public AdvancePaymentUtilizationController(IGridConstructor<IBaseRepo<FTIContext, ArtTiAdvancePaymentUtilizationReport>, FTIContext, ArtTiAdvancePaymentUtilizationReport> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }


        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtTiAdvancePaymentUtilizationReport> data = fti.ArtTiAdvancePaymentUtilizationReports.AsQueryable();


        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {


        //        DisplayNames = ReportsConfig.CONFIG[nameof(AdvancePaymentUtilizationController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //    {
        //        {"PrincipalParty".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.PrincipalParty).Distinct()    .Where(x=> x != null)    .ToDynamicList() },
        //        {"NonPrincipalParty".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.NonPrincipalParty).Distinct()                .Where(x=> x != null)    .ToDynamicList() },
        //        {"AdvCurrency".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.AdvCurrency).Distinct()      .Where(x=> x != null)    .ToDynamicList() },
        //        {"UtilizationCurrency".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.UtilizationCurrency).Distinct()          .Where(x=> x != null)    .ToDynamicList() },
        //        {"Branch".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.Branch).Distinct()        .Where(x=> x != null)    .ToDynamicList() },
        //        {"AdvReference".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.AdvReference).Distinct()  .Where(x=> x != null)    .ToDynamicList() },
        //    };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(AdvancePaymentUtilizationController).ToLower()].SkipList;
        //    }
        //    KendoDataDesc<ArtTiAdvancePaymentUtilizationReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        toolbar = new List<dynamic>
        //        {
        //        },
        //        reportname = "Advance Payment Utilization"
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
        //    List<ArtTiAdvancePaymentUtilizationReport> data = fti.ArtTiAdvancePaymentUtilizationReports.CallData(req).Data.ToList();
        //    ViewData["title"] = "Advance Payment Utilization Report";
        //    ViewData["desc"] = "";
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AdvancePaymentUtilizationController).ToLower()].SkipList;

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(AdvancePaymentUtilizationController).ToLower()].DisplayNames;
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 9
        //                                           , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");

        //}
    }
}

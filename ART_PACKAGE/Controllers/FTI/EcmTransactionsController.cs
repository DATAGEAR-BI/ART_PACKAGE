using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "EcmTransactions")]


    public class EcmTransactionsController : BaseReportController<IGridConstructor<IBaseRepo<FTIContext, ArtTiEcmTransactionsReport>, FTIContext, ArtTiEcmTransactionsReport>, IBaseRepo<FTIContext, ArtTiEcmTransactionsReport>, FTIContext, ArtTiEcmTransactionsReport>
    {
        public EcmTransactionsController(IGridConstructor<IBaseRepo<FTIContext, ArtTiEcmTransactionsReport>, FTIContext, ArtTiEcmTransactionsReport> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }


        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtTiEcmTransactionsReport> data = fti.ArtTiEcmTransactionsReports.AsQueryable();
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(EcmTransactionsController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //    {
        //        {"CaseId".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.CaseId).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Product".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Product).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Producttype".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Producttype).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Behalfofbranch".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Behalfofbranch).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Eventname".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Eventname).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"TransactionCurrency".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.TransactionCurrency).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"PrimaryOwner".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.PrimaryOwner).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"CaseStatCd".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.CaseStatCd).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"UpdateUserId".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.UpdateUserId).Distinct().Where(x=> x != null ).ToDynamicList() },
        //    };
        //    }

        //    KendoDataDesc<ArtTiEcmTransactionsReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        toolbar = new List<dynamic>
        //        {


        //        },
        //        reportname = "EcmTransactions"
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
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(EcmTransactionsController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = new() { };
        //    List<ArtTiEcmTransactionsReport> data = fti.ArtTiEcmTransactionsReports.CallData(req).Data.ToList();
        //    ViewData["title"] = "ECM Transactions Report";
        //    ViewData["desc"] = "";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}
    }
}

using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;


namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "FinancingInterestAccruals")]


    public class FinancingInterestAccrualsController : BaseReportController<IGridConstructor<IBaseRepo<FTIContext, ArtTiFinanInterAccrual>, FTIContext, ArtTiFinanInterAccrual>, IBaseRepo<FTIContext, ArtTiFinanInterAccrual>, FTIContext, ArtTiFinanInterAccrual>
    {
        public FinancingInterestAccrualsController(IGridConstructor<IBaseRepo<FTIContext, ArtTiFinanInterAccrual>, FTIContext, ArtTiFinanInterAccrual> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtTiFinanInterAccrual> data = fti.ArtTiFinanInterAccruals.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {

        //        DisplayNames = ReportsConfig.CONFIG[nameof(FinancingInterestAccrualsController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //    {
        //        {"BranchName".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.BranchName).Distinct().Where(x=> x != null ).ToDynamicList()},
        //        {"MasterRef".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList()},
        //        {"Prodcut".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.Prodcut).Distinct().Where(x=> x != null ).ToDynamicList()},
        //        {"Recccy".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.Recccy).Distinct().Where(x=> x != null ).ToDynamicList()},
        //        {"Address1".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.Address1).Distinct().Where(x=> x != null ).ToDynamicList()},
        //        {"InterestRateType".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.InterestRateType).Distinct().Where(x=> x != null ).ToDynamicList()},
        //    };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(FinancingInterestAccrualsController).ToLower()].SkipList;
        //    }
        //    KendoDataDesc<ArtTiFinanInterAccrual> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        toolbar = new List<dynamic>
        //        {

        //        },
        //        reportname = "FinancingInterestAccruals"
        //    };

        //    return new ContentResult
        //    {
        //        ContentType = "application/json",
        //        Content = JsonConvert.SerializeObject(result)
        //    };

        //}


        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    List<ArtTiFinanInterAccrual> data = fti.ArtTiFinanInterAccruals.CallData(req).Data.ToList();
        //    ViewData["title"] = "Financing Interest Accruals Report";
        //    ViewData["desc"] = "This report produces details of interest accruals to date for financing transactions, showing for each the interest earned to date";

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(FinancingInterestAccrualsController).ToLower()].DisplayNames;
        //    List<string> columnsToPrint = new()
        //    {nameof(ArtTiFinanInterAccrual.MasterRef)
        //    , nameof(ArtTiFinanInterAccrual.Address1)
        //    , nameof(ArtTiFinanInterAccrual.Prodcut)
        //    , nameof(ArtTiFinanInterAccrual.Startdate)
        //    , nameof(ArtTiFinanInterAccrual.Maturity)
        //    , nameof(ArtTiFinanInterAccrual.InterestRateType)

        //    };
        //    List<string> ColumnsToSkip = typeof(ArtTiFinanInterAccrual).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

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

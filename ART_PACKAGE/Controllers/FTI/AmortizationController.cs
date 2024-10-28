using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Data.Services;
using Microsoft.AspNetCore.Mvc;


namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed", Roles = "Amortization")]
    public class AmortizationController : BaseReportController<IGridConstructor<IBaseRepo<FTIContext, ArtTiAmortizationReport>, FTIContext, ArtTiAmortizationReport>, IBaseRepo<FTIContext, ArtTiAmortizationReport>, FTIContext, ArtTiAmortizationReport>
    {
        public AmortizationController(IGridConstructor<IBaseRepo<FTIContext, ArtTiAmortizationReport>, FTIContext, ArtTiAmortizationReport> gridConstructor) : base(gridConstructor)
        {
        }

        //private readonly FTIContext fti;
        //private readonly IPdfService _pdfSrv;

        //public AmortizationController(IPdfService pdfSrv, FTIContext fti)
        //{
        //    _pdfSrv = pdfSrv;
        //    this.fti = fti;
        //}

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtTiAmortizationReport> data = fti.ArtTiAmortizationReports.AsQueryable();
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(AmortizationController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //    {

        //        { "MasterRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        { "AcctNo".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.AcctNo).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        { "AccountType".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.AccountType).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        { "Shortname".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.Shortname).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        { "CusMnm".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.CusMnm).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        { "Ccy".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        { "DrCrFlg".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.DrCrFlg).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        { "Mainbanking".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Mainbanking).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        { "BranchName".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.BranchName).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        { "EventRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.EventRef).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        { "Spsk".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Spsk).Distinct().Where(x=> x != null ).ToDynamicList() },

        //    };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(AmortizationController).ToLower()].SkipList;
        //    }
        //    KendoDataDesc<ArtTiAmortizationReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        toolbar = new List<dynamic>
        //        {

        //        },
        //        reportname = "Amortization"

        //    };
        //    return new ContentResult
        //    {
        //        ContentType = "application/json",
        //        Content = JsonConvert.SerializeObject(result)
        //    };
        //}



        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    List<ArtTiAmortizationReport> data = fti.ArtTiAmortizationReports.CallData(req).Data.ToList();
        //    ViewData["title"] = "Amortization Report";
        //    ViewData["desc"] = "This report produces all postings posted to an account by value date";
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(AmortizationController).ToLower()].DisplayNames;
        //    List<string> columnsToPrint = new()
        //    {
        //        // nameof(ArtTiAmortizationReport.EventRef)
        //        //,nameof(ArtTiAmortizationReport.MasterRef)
        //        //,nameof(ArtTiAmortizationReport.AccountType)
        //        //,nameof(ArtTiAmortizationReport.Valuedate)
        //        //,nameof(ArtTiAmortizationReport.AcctNo)
        //        //,nameof(ArtTiAmortizationReport.DrCrFlg)
        //        //,nameof(ArtTiAmortizationReport.Ccy)
        //        //,nameof(ArtTiAmortizationReport.PostAmount)
        //    };
        //    List<string> ColumnsToSkip = typeof(ArtTiAcpostingsAccReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();

        //    if (req.Group is not null && req.Group.Count != 0)
        //    {
        //        byte[] pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, ControllerContext
        //                                           , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
        //        return File(pdfBytes, "application/pdf");
        //    }
        //    else
        //    {
        //        byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 8
        //                                           , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //        return File(pdfBytes, "application/pdf");
        //    }

        //}


        public override IActionResult Index()
        {
            return View();
        }
    }
}

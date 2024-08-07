﻿using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.CRP;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.CRP
{
    public class CrpSystemPerformanceController : BaseReportController<IGridConstructor<IBaseRepo<CRPContext, ArtCrpSystemPerformance>, CRPContext, ArtCrpSystemPerformance>, IBaseRepo<CRPContext, ArtCrpSystemPerformance>, CRPContext, ArtCrpSystemPerformance>
    {
        public CrpSystemPerformanceController(IGridConstructor<IBaseRepo<CRPContext, ArtCrpSystemPerformance>, CRPContext, ArtCrpSystemPerformance> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
        /* private readonly CRPContext _crp;
private readonly IDropDownService _dropDown;
private readonly IPdfService _pdfSrv;
private readonly IHubContext<ExportHub> _exportHub;
private readonly UsersConnectionIds connections;

public CrpSystemPerformanceController(CRPContext crp, IDropDownService dropDown, IPdfService pdfSrv, IHubContext<ExportHub> exportHub, UsersConnectionIds connections)
{
    _crp = crp;

    _dropDown = dropDown;
    _pdfSrv = pdfSrv;

    _exportHub = exportHub;
    this.connections = connections;
}

public IActionResult Index()
{
    return View();
}


public IActionResult GetData([FromBody] KendoRequest request)
{
    IQueryable<ArtCrpSystemPerformance> data = _crp.ArtCrpSystemPerformances.AsQueryable();

    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
    Dictionary<string, List<dynamic>> DropDownColumn = null;
    List<string> ColumnsToSkip = null;
    if (request.IsIntialize)
    {
        DisplayNames = ReportsConfig.CONFIG[nameof(CrpSystemPerformanceController).ToLower()].DisplayNames;
        DropDownColumn = new Dictionary<string, List<dynamic>>
        {
            {"CaseType".ToLower(),_crp.ArtCrpSystemPerformances.Select(x=>x.CaseType).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
            {"CaseStatus".ToLower(),_crp.ArtCrpSystemPerformances.Select(x=>x.CaseStatus).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
            {"CreateUserId".ToLower(),_crp.ArtCrpSystemPerformances.Select(x=>x.CreateUserId).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
            {"CaseCurrentRate".ToLower(),_crp.ArtCrpSystemPerformances.Select(x=>x.CaseCurrentRate).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
            {"Casetargetrate".ToLower(),_crp.ArtCrpSystemPerformances.Select(x=>x.Casetargetrate).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
        };

        ColumnsToSkip = ReportsConfig.CONFIG[nameof(CrpSystemPerformanceController).ToLower()].SkipList;
    }



    KendoDataDesc<ArtCrpSystemPerformance> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
    var result = new
    {
        data = Data.Data,
        columns = Data.Columns,
        total = Data.Total,
        containsActions = false,

    };

    return new ContentResult
    {
        ContentType = "application/json",
        Content = JsonConvert.SerializeObject(result)
    };
}
public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
{
    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(CrpSystemPerformanceController).ToLower()].DisplayNames;
    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(CrpSystemPerformanceController).ToLower()].SkipList;
    List<ArtCrpSystemPerformance> data = _crp.ArtCrpSystemPerformances.CallData(req).Data.ToList();
    ViewData["title"] = "CRP System Performance Details";
    ViewData["desc"] = "";
    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
    return File(pdfBytes, "application/pdf");
}

*/
    }
}

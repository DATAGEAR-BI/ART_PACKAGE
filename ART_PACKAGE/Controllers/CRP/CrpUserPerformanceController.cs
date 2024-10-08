﻿using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.CRP;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.CRP
{
    public class CrpUserPerformanceController : BaseReportController<IGridConstructor<IBaseRepo<CRPContext, ArtCrpUserPerformance>, CRPContext, ArtCrpUserPerformance>, IBaseRepo<CRPContext, ArtCrpUserPerformance>, CRPContext, ArtCrpUserPerformance>
    {
        public CrpUserPerformanceController(IGridConstructor<IBaseRepo<CRPContext, ArtCrpUserPerformance>, CRPContext, ArtCrpUserPerformance> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
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

public CrpUserPerformanceController(CRPContext crp, IDropDownService dropDown, IPdfService pdfSrv, IHubContext<ExportHub> exportHub, UsersConnectionIds connections)
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
    IQueryable<ArtCrpUserPerformance> data = _crp.ArtCrpUserPerformances.AsQueryable();

    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
    Dictionary<string, List<dynamic>> DropDownColumn = null;
    List<string> ColumnsToSkip = null;
    if (request.IsIntialize)
    {
        DisplayNames = ReportsConfig.CONFIG[nameof(CrpUserPerformanceController).ToLower()].DisplayNames;
        DropDownColumn = new Dictionary<string, List<dynamic>>
        {
            {"CaseType".ToLower(),_crp.ArtCrpUserPerformances.Select(x=>x.CaseType).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
            {"CaseStatus".ToLower(),_crp.ArtCrpUserPerformances.Select(x=>x.CaseStatus).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
            {"CreateUserId".ToLower(),_crp.ArtCrpUserPerformances.Select(x=>x.CreateUserId).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
            {"CaseCurrentRate".ToLower(),_crp.ArtCrpUserPerformances.Select(x=>x.CaseCurrentRate).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
            {"Casetargetrate".ToLower(),_crp.ArtCrpUserPerformances.Select(x=>x.Casetargetrate).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
            {"ActionUser".ToLower(),_crp.ArtCrpUserPerformances.Select(x=>x.ActionUser).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
            {"Action".ToLower(),_crp.ArtCrpUserPerformances.Select(x=>x.Action).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
        };

        ColumnsToSkip = ReportsConfig.CONFIG[nameof(CrpUserPerformanceController).ToLower()].SkipList;
    }



    KendoDataDesc<ArtCrpUserPerformance> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(CrpUserPerformanceController).ToLower()].DisplayNames;
    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(CrpUserPerformanceController).ToLower()].SkipList;
    List<ArtCrpUserPerformance> data = _crp.ArtCrpUserPerformances.CallData(req).Data.ToList();
    ViewData["title"] = "CRP User Performance Details";
    ViewData["desc"] = "";
    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
    return File(pdfBytes, "application/pdf");
}

*/
    }
}

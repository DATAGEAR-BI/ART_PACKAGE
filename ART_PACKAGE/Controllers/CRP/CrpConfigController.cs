using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.CRP;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.CRP
{
    public class CrpConfigController : BaseReportController<IGridConstructor<IBaseRepo<CRPContext, ArtCrpConfig>, CRPContext, ArtCrpConfig>, IBaseRepo<CRPContext, ArtCrpConfig>, CRPContext, ArtCrpConfig>
    {
        public CrpConfigController(IGridConstructor<IBaseRepo<CRPContext, ArtCrpConfig>, CRPContext, ArtCrpConfig> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
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

public CrpConfigController(CRPContext crp, IDropDownService dropDown, IPdfService pdfSrv, IHubContext<ExportHub> exportHub, UsersConnectionIds connections)
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
    IQueryable<ArtCrpConfig> data = _crp.ArtCrpConfigs.AsQueryable();

    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
    Dictionary<string, List<dynamic>> DropDownColumn = null;
    List<string> ColumnsToSkip = null;
    if (request.IsIntialize)
    {
        DisplayNames = ReportsConfig.CONFIG[nameof(CrpConfigController).ToLower()].DisplayNames;
        DropDownColumn = new Dictionary<string, List<dynamic>>
        {
        };

        ColumnsToSkip = ReportsConfig.CONFIG[nameof(CrpConfigController).ToLower()].SkipList;
    }



    KendoDataDesc<ArtCrpConfig> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(CrpConfigController).ToLower()].DisplayNames;
    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(CrpConfigController).ToLower()].SkipList;
    List<ArtCrpConfig> data = _crp.ArtCrpConfigs.CallData(req).Data.ToList();
    ViewData["title"] = "CRP Configs ";
    ViewData["desc"] = "";
    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
    return File(pdfBytes, "application/pdf");
}
*/

    }
}

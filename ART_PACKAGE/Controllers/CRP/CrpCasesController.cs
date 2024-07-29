using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.CRP;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.CRP
{
    public class CrpCasesController : BaseReportController<IGridConstructor<IBaseRepo<CRPContext, ArtCrpCase>, CRPContext, ArtCrpCase>, IBaseRepo<CRPContext, ArtCrpCase>, CRPContext, ArtCrpCase>
    {
        public CrpCasesController(IGridConstructor<IBaseRepo<CRPContext, ArtCrpCase>, CRPContext, ArtCrpCase> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
        /*  private readonly CRPContext _crp;
 private readonly IDropDownService _dropDown;
 private readonly IPdfService _pdfSrv;
 private readonly IHubContext<ExportHub> _exportHub;
 private readonly UsersConnectionIds connections;

 public CrpCasesController(CRPContext crp, IDropDownService dropDown, IPdfService pdfSrv, IHubContext<ExportHub> exportHub, UsersConnectionIds connections)
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
     IQueryable<ArtCrpCase> data = _crp.ArtCrpCases.AsQueryable();

     Dictionary<string, GridColumnConfiguration> DisplayNames = null;
     Dictionary<string, List<dynamic>> DropDownColumn = null;
     List<string> ColumnsToSkip = null;
     if (request.IsIntialize)
     {
         //DisplayNames = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].DisplayNames;
         //List<dynamic> PEPlist = new()
         //    {
         //        "Y","N"
         //    };
         //DropDownColumn = new Dictionary<string, List<dynamic>>
         //{
         //    {"AlertStatus".ToLower(),_dropDown.GetAlertStatusDropDown().ToDynamicList() },
         //    {"AlertSubCat".ToLower(),_dropDown.GetCaseSubCategoryDropDown().ToDynamicList() },
         //    //{"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
         //    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
         //    {"PartyTypeDesc".ToLower(),_dropDown.GetPartyTypeDropDown().ToDynamicList() },
         //    {"PoliticallyExposedPersonInd".ToLower(),PEPlist.ToDynamicList() },
         //    {"ScenarioName".ToLower(),_dropDown.GetScenarioNameDropDown().ToDynamicList() }
         //};

         //ColumnsToSkip = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].SkipList;
     }



     KendoDataDesc<ArtCrpCase> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
     Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].DisplayNames;
     List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].SkipList;
     List<ArtCrpCase> data = _crp.ArtCrpCases.CallData(req).Data.ToList();
     ViewData["title"] = "CRP Cases Details";
     ViewData["desc"] = "";
     byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
                                             , User.Identity.Name, ColumnsToSkip, DisplayNames);
     return File(pdfBytes, "application/pdf");
 }*/


    }
}

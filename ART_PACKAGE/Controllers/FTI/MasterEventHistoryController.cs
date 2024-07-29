using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles = "MasterEventHistory")]


    public class MasterEventHistoryController : BaseReportController<IGridConstructor<IBaseRepo<FTIContext, ArtTiMasterEventHistory>, FTIContext, ArtTiMasterEventHistory>, IBaseRepo<FTIContext, ArtTiMasterEventHistory>, FTIContext, ArtTiMasterEventHistory>
    {
        public MasterEventHistoryController(IGridConstructor<IBaseRepo<FTIContext, ArtTiMasterEventHistory>, FTIContext, ArtTiMasterEventHistory> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtTiMasterEventHistory> data = fti.ArtTiMasterEventHistories.AsQueryable();
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;
        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(MasterEventHistoryController).ToLower()].DisplayNames;

        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //    {
        //        {"BranchName".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.BranchName).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"MasterRef".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Shortname".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Shortname).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"EventRef".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.EventRef).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Stepdescr".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Stepdescr).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Status".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Status).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Address1".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Address1).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"StatusEv".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.StatusEv).Distinct().Where(x=> x != null ).ToDynamicList() },
        //        {"Ccy".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },


        //    };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(MasterEventHistoryController).ToLower()].SkipList;

        //    }

        //    KendoDataDesc<ArtTiMasterEventHistory> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        reportname = "MasterEventHistory"
        //    };

        //    return new ContentResult
        //    {
        //        ContentType = "application/json",
        //        Content = JsonConvert.SerializeObject(result)
        //    };
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(MasterEventHistoryController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(MasterEventHistoryController).ToLower()].SkipList;
        //    List<ArtTiMasterEventHistory> data = fti.ArtTiMasterEventHistories.CallData(req).Data.ToList();
        //    ViewData["title"] = "Master Event History Report";
        //    ViewData["desc"] = "This report produces a full history of the events for master records";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}
    }
}

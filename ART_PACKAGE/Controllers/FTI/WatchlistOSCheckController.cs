﻿using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI
{
    public class WatchlistOSCheckController : BaseReportController<IGridConstructor<IBaseRepo<FTIContext, ArtTiWatchlistOsCheckReport>, FTIContext, ArtTiWatchlistOsCheckReport>, IBaseRepo<FTIContext, ArtTiWatchlistOsCheckReport>, FTIContext, ArtTiWatchlistOsCheckReport>
    {
        public WatchlistOSCheckController(IGridConstructor<IBaseRepo<FTIContext, ArtTiWatchlistOsCheckReport>, FTIContext, ArtTiWatchlistOsCheckReport> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtTiWatchlistOsCheckReport> data = fti.ArtTiWatchlistOsCheckReports.AsQueryable();
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(WatchlistOSCheckController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //    {
        //       {"Fullname".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Fullname).Distinct().Where(x=> x != null ).ToDynamicList() },
        //       {"Descri56".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Descri56).Distinct().Where(x=> x != null ).ToDynamicList() },
        //       {"MasterRef".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
        //       {"Pcpaddress1".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Pcpaddress1).Distinct().Where(x=> x != null ).ToDynamicList() },
        //       {"Npcpaddress1".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Npcpaddress1).Distinct().Where(x=> x != null ).ToDynamicList() },
        //       {"Longna85".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Longna85).Distinct().Where(x=> x != null ).ToDynamicList() },
        //       {"Shortname".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Shortname).Distinct().Where(x=> x != null ).ToDynamicList() },
        //       {"Descr".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Descr).Distinct().Where(x=> x != null ).ToDynamicList() },
        //       {"Status".ToLower(),fti.ArtTiWatchlistOsCheckReports.Select(x=>x.Status).Distinct().Where(x=> x != null ).ToDynamicList() },

        //    };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(WatchlistOSCheckController).ToLower()].SkipList;

        //    }

        //    KendoDataDesc<ArtTiWatchlistOsCheckReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        toolbar = new List<dynamic>
        //        {


        //        },
        //        reportname = "WatchlistOSCheck"
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
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(WatchlistOSCheckController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(WatchlistOSCheckController).ToLower()].SkipList;
        //    List<ArtTiWatchlistOsCheckReport> data = fti.ArtTiWatchlistOsCheckReports.CallData(req).Data.ToList();
        //    ViewData["title"] = "Watchlist - OS Check Report";
        //    ViewData["desc"] = "This report produces lists of transactions that have been pended and are awaiting list checking";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}
    }
}

﻿using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTGOAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ART_PACKAGE.Controllers.GOAML
{
    public class GOAMLReportsSuspectController : BaseReportController<IGridConstructor<IBaseRepo<ArtGoAmlContext, ArtGoamlReportsSusbectParty>, ArtGoAmlContext, ArtGoamlReportsSusbectParty>, IBaseRepo<ArtGoAmlContext, ArtGoamlReportsSusbectParty>, ArtGoAmlContext, ArtGoamlReportsSusbectParty>
    {
        public GOAMLReportsSuspectController(IGridConstructor<IBaseRepo<ArtGoAmlContext, ArtGoamlReportsSusbectParty>, ArtGoAmlContext, ArtGoamlReportsSusbectParty> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtGoamlReportsSusbectParty> data = _context.ArtGoamlReportsSusbectParties.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportsSuspectController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {

        //            {"Reportcode".ToLower(),_dropDown.GetReportTypeDropDown().ToDynamicList() },
        //            {"Reportstatuscode".ToLower(),_dropDown.GetReportstatuscodeDropDown().ToDynamicList() },
        //            {"Branch".ToLower(),_dropDown.GetReportAcctBranchDropDown().ToDynamicList() },


        //        };
        //    }


        //    List<string> ColumnsToSkip = new()
        //    {

        //    };
        //    KendoDataDesc<ArtGoamlReportsSusbectParty> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //    };

        //    return new ContentResult
        //    {
        //        ContentType = "application/json",
        //        Content = JsonConvert.SerializeObject(result)
        //    };
        //}





        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportsSuspectController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(GOAMLReportsSuspectController).ToLower()].SkipList;
        //    List<ArtGoamlReportsSusbectParty> data = _context.ArtGoamlReportsSusbectParties.CallData(req).Data.ToList();
        //    ViewData["title"] = "GOAML Reports Suspected Partites Details";
        //    ViewData["desc"] = "Presents details about the GOAML reports with the related suspected parties";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}
        public override IActionResult Index()
        {
            return View();
        }
    }
}

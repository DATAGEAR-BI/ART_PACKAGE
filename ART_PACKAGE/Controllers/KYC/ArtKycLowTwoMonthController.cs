﻿using ART_PACKAGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;
using Data.Services;
using Microsoft.AspNetCore.Identity;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtKycLowTwoMonthController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtKycLowTwoMonth>, KYCContext, ArtKycLowTwoMonth>, IBaseRepo<KYCContext, ArtKycLowTwoMonth>, KYCContext, ArtKycLowTwoMonth>
    {
        public ArtKycLowTwoMonthController(IGridConstructor<IBaseRepo<KYCContext, ArtKycLowTwoMonth>, KYCContext, ArtKycLowTwoMonth> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }




        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtKycLowTwoMonth> data = dbfcfkc.ArtKycLowTwoMonths.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycLowTwoMonthController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            //commented untill resolve drop down 
        //            //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() }
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycLowTwoMonthController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtKycLowTwoMonth> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false
        //    };

        //    return new ContentResult
        //    {
        //        ContentType = "application/json",
        //        Content = JsonConvert.SerializeObject(result)
        //    };
        //}
        //public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        //{
        //    IQueryable<ArtKycLowTwoMonth> data = dbfcfkc.ArtKycLowTwoMonths.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtKycLowTwoMonth, GenericCsvClassMapper<ArtKycLowTwoMonth, ArtKycLowTwoMonthController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(ArtKycLowTwoMonthController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtKycLowTwoMonthController).ToLower()].SkipList;
        //    List<ArtKycLowTwoMonth> data = dbfcfkc.ArtKycLowTwoMonths.CallData(req).Data.ToList();
        //    ViewData["title"] = "Low risk within 2 months customers Report";
        //    ViewData["desc"] = "presents all low-risk customers need to be update their KYCs within 2 months with the related information below";
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

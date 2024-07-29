using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "HighRisk")]
    public class HighRiskController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, ArtAmlHighRiskCustView>, SasAmlContext, ArtAmlHighRiskCustView>, IBaseRepo<SasAmlContext, ArtAmlHighRiskCustView>, SasAmlContext, ArtAmlHighRiskCustView>
    {
        public HighRiskController(IGridConstructor<IBaseRepo<SasAmlContext, ArtAmlHighRiskCustView>, SasAmlContext, ArtAmlHighRiskCustView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtAmlHighRiskCustView> data = dbfcfcore.ArtAmlHighRiskCustViews.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(HighRiskController).ToLower()].DisplayNames;
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            {"PartyIdentificationTypeDesc".ToLower(),_dropDown.GetPartyIdentificationTypeDropDown().ToDynamicList() },
        //            {"PartyTypeDesc".ToLower(),_dropDown.GetPartyTypeDropDown().ToDynamicList() },
        //            {"RiskClassification".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
        //            //{"PoliticallyExposedPersonInd".ToLower(),_dropDown.Getpo().ToDynamicList() },
        //            {"ResidenceCountryName".ToLower(),_dropDown.GetResidenceCountryNameDropDown().ToDynamicList() },
        //            {"CitizenshipCountryName".ToLower(),_dropDown.GetCitizenshipCountryNameDropDown().ToDynamicList() },
        //            //{"MailingCityName".ToLower(),_dropDown.().ToDynamicList() },

        //        };
        //    }


        //    List<string> ColumnsToSkip = new()
        //    {

        //    };
        //    KendoDataDesc<ArtAmlHighRiskCustView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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


        //public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        //{
        //    IQueryable<ArtAmlHighRiskCustView> data = dbfcfcore.ArtAmlHighRiskCustViews.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtAmlHighRiskCustView, GenericCsvClassMapper<ArtAmlHighRiskCustView, HighRiskController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}

        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(HighRiskController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(HighRiskController).ToLower()].SkipList;
        //    List<ArtAmlHighRiskCustView> data = dbfcfcore.ArtAmlHighRiskCustViews.CallData(req).Data.ToList();
        //    ViewData["title"] = "High Risk Customers Details";
        //    ViewData["desc"] = "Presents the High Risk Customers Details";
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

using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "Customers")]
    public class CustomersController : BaseReportController<SasAmlContext, ArtAmlCustomersDetailsView>
    {
        public CustomersController(IGridConstructor<SasAmlContext, ArtAmlCustomersDetailsView> gridConstructor) : base(gridConstructor)
        {
        }


        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtAmlCustomersDetailsView> data = dbfcfcore.ArtAmlCustomersDetailsViews.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(CustomersController).ToLower()].DisplayNames;
        //        List<dynamic> Indlist = new()
        //            {
        //                "Y","N"
        //            };
        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {
        //            {"CustomerType".ToLower(),_dropDown.GetPartyTypeDropDown().ToDynamicList() },
        //            {"RiskClassification".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
        //            {"NonProfitOrgInd".ToLower(),Indlist.ToDynamicList() },
        //            {"PoliticallyExposedPersonInd".ToLower(),Indlist.ToDynamicList() },
        //            {"CharityDonationsInd".ToLower(),Indlist.ToDynamicList() },
        //            {"ResidenceCountryName".ToLower(),_dropDown.GetResidenceCountryNameDropDown().ToDynamicList() },
        //            {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
        //            {"IndustryDesc".ToLower(),_dropDown.GetIndustryDescDropDown().ToDynamicList() },
        //            {"CustomerIdentificationType".ToLower(),_dropDown.GetCustomerIdentificationTypeDropDown().ToDynamicList() },
        //            {"OccupationDesc".ToLower(),_dropDown.GetOccupationDescDropDown().ToDynamicList() },
        //            {"CitizenshipCountryName".ToLower(),_dropDown.GetCitizenshipCountryNameDropDown().ToDynamicList() }
        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(CustomersController).ToLower()].SkipList;
        //    }


        //    KendoDataDesc<ArtAmlCustomersDetailsView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
        //    IQueryable<ArtAmlCustomersDetailsView> data = dbfcfcore.ArtAmlCustomersDetailsViews.AsQueryable();
        //    byte[] bytes = await data.ExportToCSV<ArtAmlCustomersDetailsView, GenericCsvClassMapper<ArtAmlCustomersDetailsView, CustomersController>>(para.Req);
        //    return File(bytes, "text/csv");
        //}


        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(CustomersController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(CustomersController).ToLower()].SkipList;
        //    List<ArtAmlCustomersDetailsView> data = dbfcfcore.ArtAmlCustomersDetailsViews.CallData(req).Data.ToList();
        //    ViewData["title"] = "Customers Details";
        //    ViewData["desc"] = "Presents all customers details";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}


        public override IActionResult Index()
        {
            return View();
        }

    }
}

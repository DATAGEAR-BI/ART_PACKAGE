using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTDGAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLCustomersDetailsController : BaseReportController<IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgAmlCustomerDetailView>, ArtDgAmlContext, ArtDgAmlCustomerDetailView>, IBaseRepo<ArtDgAmlContext, ArtDgAmlCustomerDetailView>, ArtDgAmlContext, ArtDgAmlCustomerDetailView>
    {
        public DGAMLCustomersDetailsController(IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgAmlCustomerDetailView>, ArtDgAmlContext, ArtDgAmlCustomerDetailView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }


        /*private readonly ArtDgAmlContext _context;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public DGAMLCustomersDetailsController(ArtDgAmlContext _context, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this._context = _context;
            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtDgAmlCustomerDetailView> data = _context.ArtDGAMLCustomerDetailViews.AsQueryable();

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCustomersDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCustomersDetailsController).ToLower()].DisplayNames : new();
                List<dynamic> Indlist = new()
                    {
                        "Y","N"
                    };
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"CustomerType".ToLower()                           ,_context.ArtDGAMLCustomerDetailViews.Select(x=>x.CustomerType)                   .Distinct()                               .Where(x=>x!=null)  .ToDynamicList() },
                    {"RiskClassification".ToLower()                     ,_context.ArtDGAMLCustomerDetailViews.Select(x=>x.RiskClassification)             .Distinct()                               .Where(x=>x!=null)  .ToDynamicList() },
                    {"ResidenceCountryName".ToLower()                   ,_context.ArtDGAMLCustomerDetailViews.Select(x=>x.ResidenceCountryName)           .Distinct()                           .Where(x=>x!=null)  .ToDynamicList() },
                    {"BranchName".ToLower()                             ,_context.ArtDGAMLCustomerDetailViews.Select(x=>x.BranchName)                     .Distinct()                       .Where(x=>x!=null)  .ToDynamicList() },
                    {"IndustryDesc".ToLower()                           ,_context.ArtDGAMLCustomerDetailViews.Select(x=>x.IndustryDesc)                   .Distinct()               .Where(x=>x!=null)  .ToDynamicList() },
                    {"CustomerIdentificationType".ToLower()             ,_context.ArtDGAMLCustomerDetailViews.Select(x=>x.CustomerIdentificationType)     .Distinct()           .Where(x=>x!=null)  .ToDynamicList() },
                    {"OccupationDesc".ToLower()                         ,_context.ArtDGAMLCustomerDetailViews.Select(x=>x.OccupationDesc)                 .Distinct()           .Where(x=>x!=null)  .ToDynamicList() },
                    {"CitizenshipCountryName".ToLower()                 ,_context.ArtDGAMLCustomerDetailViews.Select(x=>x.CitizenshipCountryName)         .Distinct()                       .Where(x=>x!=null)  .ToDynamicList() },
                    {"CityName".ToLower()                 ,_context.ArtDGAMLCustomerDetailViews.Select(x=>x.CityName)                                     .Distinct()               .Where(x=>x!=null)  .ToDynamicList() },
                    {"MaritalStatusDesc".ToLower()                 ,_context.ArtDGAMLCustomerDetailViews.Select(x=>x.MaritalStatusDesc)                   .Distinct()           .Where(x=>x!=null)  .ToDynamicList() },
                    {"NonProfitOrgInd".ToLower()                        ,Indlist.ToDynamicList() },
                    {"PoliticallyExposedPersonInd".ToLower()            ,Indlist.ToDynamicList() },

                };
                ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCustomersDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCustomersDetailsController).ToLower()].SkipList : new();
            }


            KendoDataDesc<ArtDgAmlCustomerDetailView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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


        public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        {
            IQueryable<ArtDgAmlCustomerDetailView> data = _context.ArtDGAMLCustomerDetailViews.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtDgAmlCustomerDetailView, GenericCsvClassMapper<ArtAmlCustomersDetailsView, DGAMLCustomersDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, GridColumnConfiguration>? DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCustomersDetailsController).ToLower()].DisplayNames : null;
            List<string>? ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCustomersDetailsController).ToLower()].SkipList : null;
            List<ArtDgAmlCustomerDetailView> data = _context.ArtDGAMLCustomerDetailViews.CallData(req).Data.ToList();
            ViewData["title"] = "Customers Details";
            ViewData["desc"] = "Presents all customers details";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }


        public IActionResult Index()
        {
            return View();
        }*/
        public override IActionResult Index()
        {
            return View();
        }
    }
}

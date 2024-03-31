using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTDGAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLAlertDetailsController : BaseReportController<IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgAmlAlertDetailView>, ArtDgAmlContext, ArtDgAmlAlertDetailView>, IBaseRepo<ArtDgAmlContext, ArtDgAmlAlertDetailView>, ArtDgAmlContext, ArtDgAmlAlertDetailView>
    {
        public DGAMLAlertDetailsController(IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgAmlAlertDetailView>, ArtDgAmlContext, ArtDgAmlAlertDetailView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        /*        private readonly ArtDgAmlContext _context;
       private readonly IDropDownService _dropDown;
       private readonly IPdfService _pdfSrv;
       public DGAMLAlertDetailsController(ArtDgAmlContext _context, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv)
       {
           this._context = _context;

           _dropDown = dropDown;
           _pdfSrv = pdfSrv;
       }

       public IActionResult GetData([FromBody] KendoRequest request)
       {
           IQueryable<ArtDgAmlAlertDetailView> data = _context.ArtDGAMLAlertDetailViews.AsQueryable();

           Dictionary<string, GridColumnConfiguration> DisplayNames = null;
           Dictionary<string, List<dynamic>> DropDownColumn = null;
           List<string> ColumnsToSkip = null;
           if (request.IsIntialize)
           {
               DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLAlertDetailsController).ToLower()].DisplayNames : new();
               List<dynamic> PEPlist = new()
                   {
                       "Y","N"
                   };
               DropDownColumn = new Dictionary<string, List<dynamic>>
               {
                   {"AlertStatus".ToLower()                    ,_context.ArtDGAMLAlertDetailViews.Select(x => x.AlertStatus)          .Distinct()   .Where(x=> x != null)          .ToDynamicList()         },
                   {"AlertSubcategory".ToLower()                    ,_context.ArtDGAMLAlertDetailViews.Select(x =>x.AlertSubcategory) .Distinct()   .Where(x=> x != null)          .ToDynamicList()         },
                   {"AlertCategory".ToLower()                    ,_context.ArtDGAMLAlertDetailViews.Select(x =>x.AlertCategory)       .Distinct()   .Where(x=> x != null)          .ToDynamicList()         },
                   //{"OwnerUserid".ToLower()                  ,_context.ArtDGAMLAlertDetailViews.Select(x =>x.)                      .Distinct()   .Where(x=> x != null)          .ToDynamicList()                      },
                   {"BranchName".ToLower()                     ,_context.ArtDGAMLAlertDetailViews.Select(x =>x.BranchName)            .Distinct()   .Where(x=> x != null)          .ToDynamicList()                              },
                   {"ScenarioName".ToLower()                   ,_context.ArtDGAMLAlertDetailViews.Select(x =>x.ScenarioName)          .Distinct()   .Where(x=> x != null)          .ToDynamicList()          },
                   {"ClosedUserId".ToLower()                   ,_context.ArtDGAMLAlertDetailViews.Select(x =>x.ClosedUserId)          .Distinct()   .Where(x=> x != null)       .ToDynamicList()          },
                   {"CloseUserName".ToLower()                   ,_context.ArtDGAMLAlertDetailViews.Select(x =>x.CloseUserName)        .Distinct()   .Where(x=> x != null)       .ToDynamicList()          },
                   {"CloseReason".ToLower()                   ,_context.ArtDGAMLAlertDetailViews.Select(x =>x.CloseReason)            .Distinct()   .Where(x=> x != null)       .ToDynamicList()          },
                   {"PoliticallyExposedPersonInd".ToLower()    ,PEPlist.ToDynamicList()                                                },
                   {"EmpInd".ToLower()    ,PEPlist.ToDynamicList()                                                },
               };

               ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLAlertDetailsController).ToLower()].SkipList : new();
           }



           KendoDataDesc<ArtDgAmlAlertDetailView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

       public async Task<IActionResult> Export([FromBody] ExportDto<decimal> req)
       {
           IQueryable<ArtDgAmlAlertDetailView> data = _context.ArtDGAMLAlertDetailViews.AsQueryable();
           byte[] bytes = await data.ExportToCSV<ArtDgAmlAlertDetailView, GenericCsvClassMapper<ArtAmlAlertDetailView, DGAMLAlertDetailsController>>(req.Req);
           return File(bytes, "test/csv");
       }
       public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
       {
           Dictionary<string, GridColumnConfiguration>? DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLAlertDetailsController).ToLower()].DisplayNames : null;
           List<string>? ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLAlertDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLAlertDetailsController).ToLower()].SkipList : null;
           List<ArtDgAmlAlertDetailView> data = _context.ArtDGAMLAlertDetailViews.CallData(req).Data.ToList();
           ViewData["title"] = "Alert Details";
           ViewData["desc"] = "Presents the alerts details";
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

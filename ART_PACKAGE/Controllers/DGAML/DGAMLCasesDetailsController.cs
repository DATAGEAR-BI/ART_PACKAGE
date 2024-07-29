using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTDGAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLCasesDetailsController : BaseReportController<IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgAmlCaseDetailView>, ArtDgAmlContext, ArtDgAmlCaseDetailView>, IBaseRepo<ArtDgAmlContext, ArtDgAmlCaseDetailView>, ArtDgAmlContext, ArtDgAmlCaseDetailView>
    {
        public DGAMLCasesDetailsController(IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgAmlCaseDetailView>, ArtDgAmlContext, ArtDgAmlCaseDetailView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        /*private readonly ArtDgAmlContext _context;
private readonly IDropDownService _dropDown;
private readonly IPdfService _pdfSrv;
public DGAMLCasesDetailsController(ArtDgAmlContext _context, IDropDownService dropDown, IPdfService pdfSrv)
{
   this._context = _context;
   _dropDown = dropDown;
   _pdfSrv = pdfSrv;
}



public IActionResult GetData([FromBody] KendoRequest request)
{
   IQueryable<ArtDgAmlCaseDetailView> data = _context.ArtDgAmlCaseDetailViews.AsQueryable();

   Dictionary<string, GridColumnConfiguration> DisplayNames = null;
   Dictionary<string, List<dynamic>> DropDownColumn = null;
   List<string> ColumnsToSkip = null;

   if (request.IsIntialize)
   {
       DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCasesDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCasesDetailsController).ToLower()].DisplayNames : new();
       DropDownColumn = new Dictionary<string, List<dynamic>>
       {
           //commented untill resolve drop down 
           {"BranchName".ToLower()                 ,_context.ArtDgAmlCaseDetailViews.Select(x=>x.BranchName)       .Distinct()         .Where(x=>x!=null).ToDynamicList()          },
           {"CaseStatus".ToLower()                 ,_context.ArtDgAmlCaseDetailViews.Select(x=>x.CaseStatus)       .Distinct()     .Where(x=>x!=null).ToDynamicList()          },
           {"CasePriority".ToLower()               ,_context.ArtDgAmlCaseDetailViews.Select(x=>x.CasePriority)     .Distinct()     .Where(x=>x!=null).ToDynamicList()          },
           {"CaseCategory".ToLower()               ,_context.ArtDgAmlCaseDetailViews.Select(x=>x.CaseCategory)     .Distinct()     .Where(x=>x!=null).ToDynamicList()          },
           {"EntityLevel".ToLower()                ,_context.ArtDgAmlCaseDetailViews.Select(x=>x.EntityLevel)      .Distinct()     .Where(x=>x!=null).ToDynamicList()          }
       };
       ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCasesDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCasesDetailsController).ToLower()].SkipList : new();
   }

   KendoDataDesc<ArtDgAmlCaseDetailView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
   var result = new
   {
       data = Data.Data,
       columns = Data.Columns,
       total = Data.Total,
       containsActions = false,
       toolbar = new List<dynamic>
       {
           *//*new
           {
               text = "Delete Cases",
               id="dltCases",
               show = User.IsInRole("Delete_Cases")
           }*//*
       },

   };

   return new ContentResult
   {
       ContentType = "application/json",
       Content = JsonConvert.SerializeObject(result)
   };
}


public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
{
   IQueryable<ArtDgAmlCaseDetailView> data = _context.ArtDgAmlCaseDetailViews.AsQueryable();
   byte[] bytes = await data.ExportToCSV<ArtDgAmlCaseDetailView, GenericCsvClassMapper<ArtDgAmlCaseDetailView, DGAMLCasesDetailsController>>(para.Req);
   return File(bytes, "text/csv");
}

public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
{
   Dictionary<string, GridColumnConfiguration>? DisplayNames = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCasesDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(DGAMLCasesDetailsController).ToLower()].DisplayNames : null;
   List<string>? ColumnsToSkip = ReportsConfig.CONFIG.ContainsKey(nameof(DGAMLCasesDetailsController).ToLower()) ? ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].SkipList : null;
   List<ArtDgAmlCaseDetailView> data = _context.ArtDgAmlCaseDetailViews.CallData(req).Data.ToList();
   ViewData["title"] = "Cases Details";
   ViewData["desc"] = "Presents the cases details in the table below";
   byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
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

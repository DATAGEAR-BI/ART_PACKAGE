using ART_PACKAGE.Helpers.Grid;
using Data.Data.AmlAnalysis;
using Data.Services.AmlAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.AML_ANALYSIS
{
    public class AmlAnalysisController : BaseReportController<IGridConstructor<IAmlAnalysisRepo, AmlAnalysisContext, ArtAmlAnalysisViewTb>, IAmlAnalysisRepo, AmlAnalysisContext, ArtAmlAnalysisViewTb>
    {
        // GET
        public override IActionResult Index()
        {
            return View();
        }

        public AmlAnalysisController(IGridConstructor<IAmlAnalysisRepo, AmlAnalysisContext, ArtAmlAnalysisViewTb> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
    }
}
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTDGAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLArtScenarioAdminController : BaseReportController<IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtScenarioAdminView>, ArtDgAmlContext, ArtScenarioAdminView>, IBaseRepo<ArtDgAmlContext, ArtScenarioAdminView>, ArtDgAmlContext, ArtScenarioAdminView>
    {
        public DGAMLArtScenarioAdminController(IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtScenarioAdminView>, ArtDgAmlContext, ArtScenarioAdminView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

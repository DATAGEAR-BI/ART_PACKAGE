using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTGOAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ART_PACKAGE.Controllers.GOAML
{
    public class GoamlReportsValidationController : BaseReportController<IGridConstructor<IBaseRepo<ArtGoAmlContext, ArtGoamlReportsValidationView>, ArtGoAmlContext, ArtGoamlReportsValidationView>, IBaseRepo<ArtGoAmlContext, ArtGoamlReportsValidationView>, ArtGoAmlContext, ArtGoamlReportsValidationView>
    {
        public GoamlReportsValidationController(IGridConstructor<IBaseRepo<ArtGoAmlContext, ArtGoamlReportsValidationView>, ArtGoAmlContext, ArtGoamlReportsValidationView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

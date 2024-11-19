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
        public override IActionResult Index()
        {
            return View();
        }
    }
}

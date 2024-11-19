using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTDGAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLUserPerformanceController : BaseReportController<IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtAmlUserPerformance>, ArtDgAmlContext, ArtAmlUserPerformance>, IBaseRepo<ArtDgAmlContext, ArtAmlUserPerformance>, ArtDgAmlContext, ArtAmlUserPerformance>
    {
        public DGAMLUserPerformanceController(IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtAmlUserPerformance>, ArtDgAmlContext, ArtAmlUserPerformance> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

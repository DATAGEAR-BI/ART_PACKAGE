using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.DGINTFRAUD;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    //[Authorize(Roles = "UserPerformance")]
    public class UserPerformanceController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtUserPerformance>, DGINTFRAUDContext, ArtUserPerformance>, IBaseRepo<DGINTFRAUDContext, ArtUserPerformance>, DGINTFRAUDContext, ArtUserPerformance>
    {
        public UserPerformanceController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtUserPerformance>, DGINTFRAUDContext, ArtUserPerformance> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

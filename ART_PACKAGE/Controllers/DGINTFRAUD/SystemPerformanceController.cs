using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.DGINTFRAUD;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    public class SystemPerformanceController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtSystemPerformance>, DGINTFRAUDContext, ArtSystemPerformance>, IBaseRepo<DGINTFRAUDContext, ArtSystemPerformance>, DGINTFRAUDContext, ArtSystemPerformance>
    {
        public SystemPerformanceController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtSystemPerformance>, DGINTFRAUDContext, ArtSystemPerformance> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }






        public override IActionResult Index()
        {
            return View();
        }
    }
}

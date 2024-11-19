using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "SystemPerformance")]
    public class SystemPerformanceController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtSystemPerformance>, EcmContext, ArtSystemPerformance>, IBaseRepo<EcmContext, ArtSystemPerformance>, EcmContext, ArtSystemPerformance>
    {
        public SystemPerformanceController(IGridConstructor<IBaseRepo<EcmContext, ArtSystemPerformance>, EcmContext, ArtSystemPerformance> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }


        public override IActionResult Index()
        {
            return View();
        }
    }
}

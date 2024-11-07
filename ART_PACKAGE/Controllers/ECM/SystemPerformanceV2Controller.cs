using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "SystemPerformanceV2")]
    public class SystemPerformanceV2Controller : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtSystemPerformanceV2Sidian>, EcmContext, ArtSystemPerformanceV2Sidian>, IBaseRepo<EcmContext, ArtSystemPerformanceV2Sidian>, EcmContext, ArtSystemPerformanceV2Sidian>
    {
        public SystemPerformanceV2Controller(IGridConstructor<IBaseRepo<EcmContext, ArtSystemPerformanceV2Sidian>, EcmContext, ArtSystemPerformanceV2Sidian> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }


        public override IActionResult Index()
        {
            return View();
        }
    }
}

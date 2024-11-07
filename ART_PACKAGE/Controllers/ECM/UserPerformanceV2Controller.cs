using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "UserPerformanceV2")]
    public class UserPerformanceV2Controller : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtUserPerformanceV2Sidian>, EcmContext, ArtUserPerformanceV2Sidian>, IBaseRepo<EcmContext, ArtUserPerformanceV2Sidian>, EcmContext, ArtUserPerformanceV2Sidian>
    {
        public UserPerformanceV2Controller(IGridConstructor<IBaseRepo<EcmContext, ArtUserPerformanceV2Sidian>, EcmContext, ArtUserPerformanceV2Sidian> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

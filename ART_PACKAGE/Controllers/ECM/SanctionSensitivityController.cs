using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "SanctionSensitivity")]
    public class SanctionSensitivityController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtSanctionSensitivityView>, EcmContext, ArtSanctionSensitivityView>, IBaseRepo<EcmContext, ArtSanctionSensitivityView>, EcmContext, ArtSanctionSensitivityView>
    {
        public SanctionSensitivityController(IGridConstructor<IBaseRepo<EcmContext, ArtSanctionSensitivityView>, EcmContext, ArtSanctionSensitivityView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }


        public override IActionResult Index()
        {
            return View();
        }
    }
}

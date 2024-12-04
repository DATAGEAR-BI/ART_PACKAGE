using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    public class CFTConfigController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtCFTConfig>, EcmContext, ArtCFTConfig>, IBaseRepo<EcmContext, ArtCFTConfig>, EcmContext, ArtCFTConfig>
    {
        public CFTConfigController(IGridConstructor<IBaseRepo<EcmContext, ArtCFTConfig>, EcmContext, ArtCFTConfig> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

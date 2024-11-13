
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    public class SlaTbLevel1ViolatedWithoutActionController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaTbLevel1ViolatedWithoutAction>, SasAmlContext, SlaTbLevel1ViolatedWithoutAction>, IBaseRepo<SasAmlContext, SlaTbLevel1ViolatedWithoutAction>, SasAmlContext, SlaTbLevel1ViolatedWithoutAction>
    {
        public SlaTbLevel1ViolatedWithoutActionController(IGridConstructor<IBaseRepo<SasAmlContext, SlaTbLevel1ViolatedWithoutAction>, SasAmlContext, SlaTbLevel1ViolatedWithoutAction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

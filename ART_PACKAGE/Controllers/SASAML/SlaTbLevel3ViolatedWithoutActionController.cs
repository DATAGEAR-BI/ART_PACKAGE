
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    public class SlaTbLevel3ViolatedWithoutActionController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaTbLevel3ViolatedWithoutAction>, SasAmlContext, SlaTbLevel3ViolatedWithoutAction>, IBaseRepo<SasAmlContext, SlaTbLevel3ViolatedWithoutAction>, SasAmlContext, SlaTbLevel3ViolatedWithoutAction>
    {
        public SlaTbLevel3ViolatedWithoutActionController(IGridConstructor<IBaseRepo<SasAmlContext, SlaTbLevel3ViolatedWithoutAction>, SasAmlContext, SlaTbLevel3ViolatedWithoutAction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

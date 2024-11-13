
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    public class SlaTbLevel2ViolatedWithoutActionController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaTbLevel2ViolatedWithoutAction>, SasAmlContext, SlaTbLevel2ViolatedWithoutAction>, IBaseRepo<SasAmlContext, SlaTbLevel2ViolatedWithoutAction>, SasAmlContext, SlaTbLevel2ViolatedWithoutAction>
    {
        public SlaTbLevel2ViolatedWithoutActionController(IGridConstructor<IBaseRepo<SasAmlContext, SlaTbLevel2ViolatedWithoutAction>, SasAmlContext, SlaTbLevel2ViolatedWithoutAction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

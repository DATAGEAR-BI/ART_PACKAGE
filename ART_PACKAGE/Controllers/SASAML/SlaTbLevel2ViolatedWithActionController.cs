using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "SlaTbLevel2ViolatedWithAction")]
    public class SlaTbLevel2ViolatedWithActionController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaTbLevel2ViolatedWithAction>, SasAmlContext, SlaTbLevel2ViolatedWithAction>, IBaseRepo<SasAmlContext, SlaTbLevel2ViolatedWithAction>, SasAmlContext, SlaTbLevel2ViolatedWithAction>
    {
        public SlaTbLevel2ViolatedWithActionController(IGridConstructor<IBaseRepo<SasAmlContext, SlaTbLevel2ViolatedWithAction>, SasAmlContext, SlaTbLevel2ViolatedWithAction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }


    }
}

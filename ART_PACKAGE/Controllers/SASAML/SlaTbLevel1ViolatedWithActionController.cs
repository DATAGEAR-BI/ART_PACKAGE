using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "SlaLevel2NonStaffViolatedWithAction")]
    public class SlaTbLevel1ViolatedWithActionController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaTbLevel1ViolatedWithAction>, SasAmlContext, SlaTbLevel1ViolatedWithAction>, IBaseRepo<SasAmlContext, SlaTbLevel1ViolatedWithAction>, SasAmlContext, SlaTbLevel1ViolatedWithAction>
    {
        public SlaTbLevel1ViolatedWithActionController(IGridConstructor<IBaseRepo<SasAmlContext, SlaTbLevel1ViolatedWithAction>, SasAmlContext, SlaTbLevel1ViolatedWithAction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }


    }
}

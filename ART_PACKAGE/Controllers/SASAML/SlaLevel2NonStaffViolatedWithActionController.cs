using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "SlaLevel2NonStaffViolatedWithAction")]
    public class SlaLevel2NonStaffViolatedWithActionController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaLevel2NonStaffViolatedWithAction>, SasAmlContext, SlaLevel2NonStaffViolatedWithAction>, IBaseRepo<SasAmlContext, SlaLevel2NonStaffViolatedWithAction>, SasAmlContext, SlaLevel2NonStaffViolatedWithAction>
    {
        public SlaLevel2NonStaffViolatedWithActionController(IGridConstructor<IBaseRepo<SasAmlContext, SlaLevel2NonStaffViolatedWithAction>, SasAmlContext, SlaLevel2NonStaffViolatedWithAction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }


    }
}

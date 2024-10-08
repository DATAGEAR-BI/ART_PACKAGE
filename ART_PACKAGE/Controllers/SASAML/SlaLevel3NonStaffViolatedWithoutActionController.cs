
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    public class SlaLevel3NonStaffViolatedWithoutActionController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaLevel3NonStaffViolatedWithoutAction>, SasAmlContext, SlaLevel3NonStaffViolatedWithoutAction>, IBaseRepo<SasAmlContext, SlaLevel3NonStaffViolatedWithoutAction>, SasAmlContext, SlaLevel3NonStaffViolatedWithoutAction>
    {
        public SlaLevel3NonStaffViolatedWithoutActionController(IGridConstructor<IBaseRepo<SasAmlContext, SlaLevel3NonStaffViolatedWithoutAction>, SasAmlContext, SlaLevel3NonStaffViolatedWithoutAction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

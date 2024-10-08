
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    public class SlaLevel2NonStaffViolatedWithoutActionController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaLevel2NonStaffViolatedWithoutAction>, SasAmlContext, SlaLevel2NonStaffViolatedWithoutAction>, IBaseRepo<SasAmlContext, SlaLevel2NonStaffViolatedWithoutAction>, SasAmlContext, SlaLevel2NonStaffViolatedWithoutAction>
    {
        public SlaLevel2NonStaffViolatedWithoutActionController(IGridConstructor<IBaseRepo<SasAmlContext, SlaLevel2NonStaffViolatedWithoutAction>, SasAmlContext, SlaLevel2NonStaffViolatedWithoutAction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

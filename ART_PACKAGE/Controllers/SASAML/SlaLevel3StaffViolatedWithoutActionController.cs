
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    public class SlaLevel3StaffViolatedWithoutActionController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaLevel3StaffViolatedWithoutAction>, SasAmlContext, SlaLevel3StaffViolatedWithoutAction>, IBaseRepo<SasAmlContext, SlaLevel3StaffViolatedWithoutAction>, SasAmlContext, SlaLevel3StaffViolatedWithoutAction>
    {
        public SlaLevel3StaffViolatedWithoutActionController(IGridConstructor<IBaseRepo<SasAmlContext, SlaLevel3StaffViolatedWithoutAction>, SasAmlContext, SlaLevel3StaffViolatedWithoutAction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

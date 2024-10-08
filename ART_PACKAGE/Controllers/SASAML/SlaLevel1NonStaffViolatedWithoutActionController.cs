
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    public class SlaLevel1NonStaffViolatedWithoutActionController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaLevel1NonStaffViolatedWithoutAction>, SasAmlContext, SlaLevel1NonStaffViolatedWithoutAction>, IBaseRepo<SasAmlContext, SlaLevel1NonStaffViolatedWithoutAction>, SasAmlContext, SlaLevel1NonStaffViolatedWithoutAction>
    {
        public SlaLevel1NonStaffViolatedWithoutActionController(IGridConstructor<IBaseRepo<SasAmlContext, SlaLevel1NonStaffViolatedWithoutAction>, SasAmlContext, SlaLevel1NonStaffViolatedWithoutAction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

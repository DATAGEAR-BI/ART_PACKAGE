using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "SlaLevel2NonStaffViolatedWithAction")]
    public class SlaLevel1NonStaffViolatedWithActionController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaLevel1NonStaffViolatedWithAction>, SasAmlContext, SlaLevel1NonStaffViolatedWithAction>, IBaseRepo<SasAmlContext, SlaLevel1NonStaffViolatedWithAction>, SasAmlContext, SlaLevel1NonStaffViolatedWithAction>
    {
        public SlaLevel1NonStaffViolatedWithActionController(IGridConstructor<IBaseRepo<SasAmlContext, SlaLevel1NonStaffViolatedWithAction>, SasAmlContext, SlaLevel1NonStaffViolatedWithAction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }


    }
}

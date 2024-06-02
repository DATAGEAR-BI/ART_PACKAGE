using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAUDIT;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailAccessRoleController : BaseReportController<IGridConstructor<IBaseRepo<SASAUDITContext, SasListAccessRightPerRole>, SASAUDITContext, SasListAccessRightPerRole>, IBaseRepo<SASAUDITContext, SasListAccessRightPerRole>, SASAUDITContext, SasListAccessRightPerRole>
    {
        public SASAuditTrailAccessRoleController(IGridConstructor<IBaseRepo<SASAUDITContext, SasListAccessRightPerRole>, SASAUDITContext, SasListAccessRightPerRole> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }


        public override IActionResult Index()
        {
            return View();
        }
    }
}

using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAUDIT;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailAccessGroupRoleController : BaseReportController<IGridConstructor<IBaseRepo<SASAUDITContext, SasListAccessRightPerProfile>, SASAUDITContext, SasListAccessRightPerProfile>, IBaseRepo<SASAUDITContext, SasListAccessRightPerProfile>, SASAUDITContext, SasListAccessRightPerProfile>
    {
        public SASAuditTrailAccessGroupRoleController(IGridConstructor<IBaseRepo<SASAUDITContext, SasListAccessRightPerProfile>, SASAUDITContext, SasListAccessRightPerProfile> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }




        public override IActionResult Index()
        {
            return View();
        }
    }
}

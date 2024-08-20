using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAudit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailAccessGroupRoleController : BaseReportController<IGridConstructor<IBaseRepo<SasAuditContext, SasListAccessRightPerProfile>, SasAuditContext, SasListAccessRightPerProfile>, IBaseRepo<SasAuditContext, SasListAccessRightPerProfile>, SasAuditContext, SasListAccessRightPerProfile>
    {
        public SASAuditTrailAccessGroupRoleController(IGridConstructor<IBaseRepo<SasAuditContext, SasListAccessRightPerProfile>, SasAuditContext, SasListAccessRightPerProfile> gridConstructor, UserManager<Areas.Identity.Data.AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

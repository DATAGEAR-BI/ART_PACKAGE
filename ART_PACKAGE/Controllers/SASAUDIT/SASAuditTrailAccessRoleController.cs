using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAudit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailAccessRoleController : BaseReportController<IGridConstructor<IBaseRepo<SasAuditContext, SasListAccessRightPerRole>, SasAuditContext, SasListAccessRightPerRole>, IBaseRepo<SasAuditContext, SasListAccessRightPerRole>, SasAuditContext, SasListAccessRightPerRole>
    {
        public SASAuditTrailAccessRoleController(IGridConstructor<IBaseRepo<SasAuditContext, SasListAccessRightPerRole>, SasAuditContext, SasListAccessRightPerRole> gridConstructor) : base(gridConstructor)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

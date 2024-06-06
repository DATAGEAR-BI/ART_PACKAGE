using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAudit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailUsersDepartmentController : BaseReportController<IGridConstructor<IBaseRepo<SasAuditContext, SasListUsersDepartment>, SasAuditContext, SasListUsersDepartment>, IBaseRepo<SasAuditContext, SasListUsersDepartment>, SasAuditContext, SasListUsersDepartment>
    {
        public SASAuditTrailUsersDepartmentController(IGridConstructor<IBaseRepo<SasAuditContext, SasListUsersDepartment>, SasAuditContext, SasListUsersDepartment> gridConstructor, UserManager<Areas.Identity.Data.AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

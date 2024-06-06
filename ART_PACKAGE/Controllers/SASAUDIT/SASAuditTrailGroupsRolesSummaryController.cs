using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAudit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailGroupsRolesSummaryController : BaseReportController<IGridConstructor<IBaseRepo<SasAuditContext, SasListGroupsRolesSummary>, SasAuditContext, SasListGroupsRolesSummary>, IBaseRepo<SasAuditContext, SasListGroupsRolesSummary>, SasAuditContext, SasListGroupsRolesSummary>
    {
        public SASAuditTrailGroupsRolesSummaryController(IGridConstructor<IBaseRepo<SasAuditContext, SasListGroupsRolesSummary>, SasAuditContext, SasListGroupsRolesSummary> gridConstructor, UserManager<Areas.Identity.Data.AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

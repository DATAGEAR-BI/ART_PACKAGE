using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAudit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailGroupsRolesSummaryController : BaseReportController<IGridConstructor<IBaseRepo<SasAuditContext, SasListGroupsRolesSummary>, SasAuditContext, SasListGroupsRolesSummary>, IBaseRepo<SasAuditContext, SasListGroupsRolesSummary>, SasAuditContext, SasListGroupsRolesSummary>
    {
        public SASAuditTrailGroupsRolesSummaryController(IGridConstructor<IBaseRepo<SasAuditContext, SasListGroupsRolesSummary>, SasAuditContext, SasListGroupsRolesSummary> gridConstructor) : base(gridConstructor)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

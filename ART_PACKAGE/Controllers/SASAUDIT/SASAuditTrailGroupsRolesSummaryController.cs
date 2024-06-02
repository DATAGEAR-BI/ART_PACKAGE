using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAUDIT;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailGroupsRolesSummaryController : BaseReportController<IGridConstructor<IBaseRepo<SASAUDITContext, SasListGroupsRolesSummary>, SASAUDITContext, SasListGroupsRolesSummary>, IBaseRepo<SASAUDITContext, SasListGroupsRolesSummary>, SASAUDITContext, SasListGroupsRolesSummary>
    {
        public SASAuditTrailGroupsRolesSummaryController(IGridConstructor<IBaseRepo<SASAUDITContext, SasListGroupsRolesSummary>, SASAUDITContext, SasListGroupsRolesSummary> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

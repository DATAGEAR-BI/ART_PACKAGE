using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAUDIT;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailUsersGroupsRoleController : BaseReportController<IGridConstructor<IBaseRepo<SASAUDITContext, SasListOfUsersAndGroupsRole>, SASAUDITContext, SasListOfUsersAndGroupsRole>, IBaseRepo<SASAUDITContext, SasListOfUsersAndGroupsRole>, SASAUDITContext, SasListOfUsersAndGroupsRole>
    {
        public SASAuditTrailUsersGroupsRoleController(IGridConstructor<IBaseRepo<SASAUDITContext, SasListOfUsersAndGroupsRole>, SASAUDITContext, SasListOfUsersAndGroupsRole> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

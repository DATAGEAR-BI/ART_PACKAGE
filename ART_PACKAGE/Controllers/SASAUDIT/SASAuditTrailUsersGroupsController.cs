using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAudit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailUsersGroupsController : BaseReportController<IGridConstructor<IBaseRepo<SasAuditContext, SasListOfUsersAndGroupsRole>, SasAuditContext, SasListOfUsersAndGroupsRole>, IBaseRepo<SasAuditContext, SasListOfUsersAndGroupsRole>, SasAuditContext, SasListOfUsersAndGroupsRole>
    {
        public SASAuditTrailUsersGroupsController(IGridConstructor<IBaseRepo<SasAuditContext, SasListOfUsersAndGroupsRole>, SasAuditContext, SasListOfUsersAndGroupsRole> gridConstructor, UserManager<Areas.Identity.Data.AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

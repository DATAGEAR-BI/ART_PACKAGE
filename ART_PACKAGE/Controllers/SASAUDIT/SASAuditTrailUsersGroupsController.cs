using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAudit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailUsersGroupsController : BaseReportController<IGridConstructor<IBaseRepo<SasAuditContext, SasListOfUsersAndGroupsRole>, SasAuditContext, SasListOfUsersAndGroupsRole>, IBaseRepo<SasAuditContext, SasListOfUsersAndGroupsRole>, SasAuditContext, SasListOfUsersAndGroupsRole>
    {
        public SASAuditTrailUsersGroupsController(IGridConstructor<IBaseRepo<SasAuditContext, SasListOfUsersAndGroupsRole>, SasAuditContext, SasListOfUsersAndGroupsRole> gridConstructor) : base(gridConstructor)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

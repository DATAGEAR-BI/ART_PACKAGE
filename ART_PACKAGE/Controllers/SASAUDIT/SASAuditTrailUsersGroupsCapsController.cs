using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAudit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailUsersGroupsCapsController : BaseReportController<IGridConstructor<IBaseRepo<SasAuditContext, SasListAccessUsersGroupsCap>, SasAuditContext, SasListAccessUsersGroupsCap>, IBaseRepo<SasAuditContext, SasListAccessUsersGroupsCap>, SasAuditContext, SasListAccessUsersGroupsCap>
    {
        public SASAuditTrailUsersGroupsCapsController(IGridConstructor<IBaseRepo<SasAuditContext, SasListAccessUsersGroupsCap>, SasAuditContext, SasListAccessUsersGroupsCap> gridConstructor, UserManager<Areas.Identity.Data.AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

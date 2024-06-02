using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAUDIT;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailUsersGroupsCapsController : BaseReportController<IGridConstructor<IBaseRepo<SASAUDITContext, SasListAccessUsersGroupsCap>, SASAUDITContext, SasListAccessUsersGroupsCap>, IBaseRepo<SASAUDITContext, SasListAccessUsersGroupsCap>, SASAUDITContext, SasListAccessUsersGroupsCap>
    {
        public SASAuditTrailUsersGroupsCapsController(IGridConstructor<IBaseRepo<SASAUDITContext, SasListAccessUsersGroupsCap>, SASAUDITContext, SasListAccessUsersGroupsCap> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

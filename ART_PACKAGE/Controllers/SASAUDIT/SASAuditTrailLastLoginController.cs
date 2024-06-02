using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAUDIT;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailLastLoginController : BaseReportController<IGridConstructor<IBaseRepo<SASAUDITContext, VaLastLoginView>, SASAUDITContext, VaLastLoginView>, IBaseRepo<SASAUDITContext, VaLastLoginView>, SASAUDITContext, VaLastLoginView>
    {
        public SASAuditTrailLastLoginController(IGridConstructor<IBaseRepo<SASAUDITContext, VaLastLoginView>, SASAUDITContext, VaLastLoginView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

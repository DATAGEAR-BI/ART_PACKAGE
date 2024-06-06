using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAudit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailLastLoginController : BaseReportController<IGridConstructor<IBaseRepo<SasAuditContext, VaLastLoginView>, SasAuditContext, VaLastLoginView>, IBaseRepo<SasAuditContext, VaLastLoginView>, SasAuditContext, VaLastLoginView>
    {
        public SASAuditTrailLastLoginController(IGridConstructor<IBaseRepo<SasAuditContext, VaLastLoginView>, SasAuditContext, VaLastLoginView> gridConstructor, UserManager<Areas.Identity.Data.AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }

}

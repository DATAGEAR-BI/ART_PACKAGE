using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAUDIT;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditListAppController : BaseReportController<IGridConstructor<IBaseRepo<SASAUDITContext, VaLicensedView>, SASAUDITContext, VaLicensedView>, IBaseRepo<SASAUDITContext, VaLicensedView>, SASAUDITContext, VaLicensedView>
    {
        public SASAuditListAppController(IGridConstructor<IBaseRepo<SASAUDITContext, VaLicensedView>, SASAUDITContext, VaLicensedView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

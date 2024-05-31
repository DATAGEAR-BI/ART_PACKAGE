using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAUDIT;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailActionController : BaseReportController<IGridConstructor<IBaseRepo<SASAUDITContext, SasAuditTrailReport>, SASAUDITContext, SasAuditTrailReport>, IBaseRepo<SASAUDITContext, SasAuditTrailReport>, SASAUDITContext, SasAuditTrailReport>
    {
        public SASAuditTrailActionController(IGridConstructor<IBaseRepo<SASAUDITContext, SasAuditTrailReport>, SASAUDITContext, SasAuditTrailReport> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAudit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditTrailActionController : BaseReportController<IGridConstructor<IBaseRepo<SasAuditContext, SasAuditTrailReport>, SasAuditContext, SasAuditTrailReport>, IBaseRepo<SasAuditContext, SasAuditTrailReport>, SasAuditContext, SasAuditTrailReport>
    {
        public SASAuditTrailActionController(IGridConstructor<IBaseRepo<SasAuditContext, SasAuditTrailReport>, SasAuditContext, SasAuditTrailReport> gridConstructor) : base(gridConstructor)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

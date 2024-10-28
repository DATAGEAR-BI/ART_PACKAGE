using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAudit;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAUDIT
{
    public class SASAuditListAppController : BaseReportController<IGridConstructor<IBaseRepo<SasAuditContext, VaLicensed>, SasAuditContext, VaLicensed>, IBaseRepo<SasAuditContext, VaLicensed>, SasAuditContext, VaLicensed>
    {
        public SASAuditListAppController(IGridConstructor<IBaseRepo<SasAuditContext, VaLicensed>, SasAuditContext, VaLicensed> gridConstructor) : base(gridConstructor)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

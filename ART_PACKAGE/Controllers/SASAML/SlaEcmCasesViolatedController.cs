
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    public class SlaEcmCasesViolatedController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaEcmCasesViolated>, SasAmlContext, SlaEcmCasesViolated>, IBaseRepo<SasAmlContext, SlaEcmCasesViolated>, SasAmlContext, SlaEcmCasesViolated>
    {
        public SlaEcmCasesViolatedController(IGridConstructor<IBaseRepo<SasAmlContext, SlaEcmCasesViolated>, SasAmlContext, SlaEcmCasesViolated> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "InternalCaseValidation")]
    public class InternalCaseValidationController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, ArtAmlInternalCaseValidationView>, SasAmlContext, ArtAmlInternalCaseValidationView>, IBaseRepo<SasAmlContext, ArtAmlInternalCaseValidationView>, SasAmlContext, ArtAmlInternalCaseValidationView>
    {
        public InternalCaseValidationController(IGridConstructor<IBaseRepo<SasAmlContext, ArtAmlInternalCaseValidationView>, SasAmlContext, ArtAmlInternalCaseValidationView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

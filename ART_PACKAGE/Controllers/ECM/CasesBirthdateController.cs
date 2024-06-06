using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "CasesBirthdate")]
    public class CasesBirthdateController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtEcmCasesBirthdateView>, EcmContext, ArtEcmCasesBirthdateView>, IBaseRepo<EcmContext, ArtEcmCasesBirthdateView>, EcmContext, ArtEcmCasesBirthdateView>
    {
        public CasesBirthdateController(IGridConstructor<IBaseRepo<EcmContext, ArtEcmCasesBirthdateView>, EcmContext, ArtEcmCasesBirthdateView> gridConstructor, UserManager<Areas.Identity.Data.AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

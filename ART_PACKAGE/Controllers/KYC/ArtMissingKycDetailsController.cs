using ART_PACKAGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;
using Data.Services;
using Microsoft.AspNetCore.Identity;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtMissingKycDetailsController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtMissingKycDetailsView>, KYCContext, ArtMissingKycDetailsView>, IBaseRepo<KYCContext, ArtMissingKycDetailsView>, KYCContext, ArtMissingKycDetailsView>
    {
        public ArtMissingKycDetailsController(IGridConstructor<IBaseRepo<KYCContext, ArtMissingKycDetailsView>, KYCContext, ArtMissingKycDetailsView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }


        public override IActionResult Index()
        {
            return View();
        }
    }
}

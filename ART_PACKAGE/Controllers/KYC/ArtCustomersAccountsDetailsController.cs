using ART_PACKAGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;
using Data.Services;
using Microsoft.AspNetCore.Identity;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtCustomersAccountsDetailsController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtCustomersAccountsDetailsView>, KYCContext, ArtCustomersAccountsDetailsView>, IBaseRepo<KYCContext, ArtCustomersAccountsDetailsView>, KYCContext, ArtCustomersAccountsDetailsView>
    {
        public ArtCustomersAccountsDetailsController(IGridConstructor<IBaseRepo<KYCContext, ArtCustomersAccountsDetailsView>, KYCContext, ArtCustomersAccountsDetailsView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

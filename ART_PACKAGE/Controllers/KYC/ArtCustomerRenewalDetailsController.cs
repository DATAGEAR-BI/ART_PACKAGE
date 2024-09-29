using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.KYC;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtCustomerRenewalDetailsController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtCustomerRenewalDetails>, KYCContext, ArtCustomerRenewalDetails>, IBaseRepo<KYCContext, ArtCustomerRenewalDetails>, KYCContext, ArtCustomerRenewalDetails>
    {
        public ArtCustomerRenewalDetailsController(IGridConstructor<IBaseRepo<KYCContext, ArtCustomerRenewalDetails>, KYCContext, ArtCustomerRenewalDetails> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

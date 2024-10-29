using ART_PACKAGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;
using Data.Services;
using Microsoft.AspNetCore.Identity;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtCustomersWithSameDocumentsDiffCidController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtCustomersWithSameDocumentsDiffCidView>, KYCContext, ArtCustomersWithSameDocumentsDiffCidView>, IBaseRepo<KYCContext, ArtCustomersWithSameDocumentsDiffCidView>, KYCContext, ArtCustomersWithSameDocumentsDiffCidView>
    {
        public ArtCustomersWithSameDocumentsDiffCidController(IGridConstructor<IBaseRepo<KYCContext, ArtCustomersWithSameDocumentsDiffCidView>, KYCContext, ArtCustomersWithSameDocumentsDiffCidView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

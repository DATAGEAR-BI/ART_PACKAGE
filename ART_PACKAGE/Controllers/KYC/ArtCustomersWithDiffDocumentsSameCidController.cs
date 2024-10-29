using ART_PACKAGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Data.Data.KYC;
using ART_PACKAGE.Helpers.Grid;
using Data.Services;
using Microsoft.AspNetCore.Identity;

namespace ART_PACKAGE.Controllers.KYC
{
    public class ArtCustomersWithDiffDocumentsSameCidController : BaseReportController<IGridConstructor<IBaseRepo<KYCContext, ArtCustomersWithDiffDocumentsSameCidView>, KYCContext, ArtCustomersWithDiffDocumentsSameCidView>, IBaseRepo<KYCContext, ArtCustomersWithDiffDocumentsSameCidView>, KYCContext, ArtCustomersWithDiffDocumentsSameCidView>
    {
        public ArtCustomersWithDiffDocumentsSameCidController(IGridConstructor<IBaseRepo<KYCContext, ArtCustomersWithDiffDocumentsSameCidView>, KYCContext, ArtCustomersWithDiffDocumentsSameCidView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

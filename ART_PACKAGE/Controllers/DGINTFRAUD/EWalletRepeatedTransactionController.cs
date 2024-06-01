using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.DGINTFRAUD;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    public class EWalletRepeatedTransactionController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlEWalletRepeatedTransaction>, DGINTFRAUDContext, ArtDgamlEWalletRepeatedTransaction>, IBaseRepo<DGINTFRAUDContext, ArtDgamlEWalletRepeatedTransaction>, DGINTFRAUDContext, ArtDgamlEWalletRepeatedTransaction>
    {
        public EWalletRepeatedTransactionController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlEWalletRepeatedTransaction>, DGINTFRAUDContext, ArtDgamlEWalletRepeatedTransaction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }

    }
}

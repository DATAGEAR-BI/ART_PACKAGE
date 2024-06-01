using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.DGINTFRAUD;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    public class AchTransactionController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlAchTransaction>, DGINTFRAUDContext, ArtDgamlAchTransaction>, IBaseRepo<DGINTFRAUDContext, ArtDgamlAchTransaction>, DGINTFRAUDContext, ArtDgamlAchTransaction>
    {
        public AchTransactionController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlAchTransaction>, DGINTFRAUDContext, ArtDgamlAchTransaction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }

    }
}

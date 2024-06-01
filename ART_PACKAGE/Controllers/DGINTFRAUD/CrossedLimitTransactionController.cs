using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.DGINTFRAUD;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    public class CrossedLimitTransactionController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlCrossedLimitTransaction>, DGINTFRAUDContext, ArtDgamlCrossedLimitTransaction>, IBaseRepo<DGINTFRAUDContext, ArtDgamlCrossedLimitTransaction>, DGINTFRAUDContext, ArtDgamlCrossedLimitTransaction>
    {
        public CrossedLimitTransactionController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlCrossedLimitTransaction>, DGINTFRAUDContext, ArtDgamlCrossedLimitTransaction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }

    }
}

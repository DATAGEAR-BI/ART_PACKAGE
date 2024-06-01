using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.DGINTFRAUD;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    public class AllTransactionController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlAllTransaction>, DGINTFRAUDContext, ArtDgamlAllTransaction>, IBaseRepo<DGINTFRAUDContext, ArtDgamlAllTransaction>, DGINTFRAUDContext, ArtDgamlAllTransaction>
    {
        public AllTransactionController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlAllTransaction>, DGINTFRAUDContext, ArtDgamlAllTransaction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }

    }
}

using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.DGINTFRAUD;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    public class HierarchicalTransactionController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlHierarchicalTransaction>, DGINTFRAUDContext, ArtDgamlHierarchicalTransaction>, IBaseRepo<DGINTFRAUDContext, ArtDgamlHierarchicalTransaction>, DGINTFRAUDContext, ArtDgamlHierarchicalTransaction>
    {
        public HierarchicalTransactionController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlHierarchicalTransaction>, DGINTFRAUDContext, ArtDgamlHierarchicalTransaction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }

    }
}

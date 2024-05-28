using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.DGINTFRAUD;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    public class DgamlAllTransactionsWithReasonController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlAllTransactionsWithReason>, DGINTFRAUDContext, ArtDgamlAllTransactionsWithReason>, IBaseRepo<DGINTFRAUDContext, ArtDgamlAllTransactionsWithReason>, DGINTFRAUDContext, ArtDgamlAllTransactionsWithReason>
    {
        public DgamlAllTransactionsWithReasonController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlAllTransactionsWithReason>, DGINTFRAUDContext, ArtDgamlAllTransactionsWithReason> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }

    }
}

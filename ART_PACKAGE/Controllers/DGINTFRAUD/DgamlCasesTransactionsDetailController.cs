using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.DGINTFRAUD;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    public class DgamlCasesTransactionsDetailController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlCasesTransactionsDetail>, DGINTFRAUDContext, ArtDgamlCasesTransactionsDetail>, IBaseRepo<DGINTFRAUDContext, ArtDgamlCasesTransactionsDetail>, DGINTFRAUDContext, ArtDgamlCasesTransactionsDetail>
    {
        public DgamlCasesTransactionsDetailController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlCasesTransactionsDetail>, DGINTFRAUDContext, ArtDgamlCasesTransactionsDetail> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }

    }
}

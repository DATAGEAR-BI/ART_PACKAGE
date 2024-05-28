using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.DGINTFRAUD;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    public class DgamlStaffToStaffDailyTransactionController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlStaffToStaffDailyTransaction>, DGINTFRAUDContext, ArtDgamlStaffToStaffDailyTransaction>, IBaseRepo<DGINTFRAUDContext, ArtDgamlStaffToStaffDailyTransaction>, DGINTFRAUDContext, ArtDgamlStaffToStaffDailyTransaction>
    {
        public DgamlStaffToStaffDailyTransactionController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlStaffToStaffDailyTransaction>, DGINTFRAUDContext, ArtDgamlStaffToStaffDailyTransaction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }

    }
}

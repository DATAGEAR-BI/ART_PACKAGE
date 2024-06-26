using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.DGINTFRAUD;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    //////[Authorize(Roles = "AlertDetails")]
    public class AlertDetailsController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlAlertDetailView>, DGINTFRAUDContext, ArtDgamlAlertDetailView>, IBaseRepo<DGINTFRAUDContext, ArtDgamlAlertDetailView>, DGINTFRAUDContext, ArtDgamlAlertDetailView>
    {
        public AlertDetailsController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlAlertDetailView>, DGINTFRAUDContext, ArtDgamlAlertDetailView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }




        public override IActionResult Index()
        {
            return View();
        }


    }
}

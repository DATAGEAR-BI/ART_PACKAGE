using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTDGAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLAlertDetailsStaffController : BaseReportController<IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgamlAlertDetailViewStaff>, ArtDgAmlContext, ArtDgamlAlertDetailViewStaff>, IBaseRepo<ArtDgAmlContext, ArtDgamlAlertDetailViewStaff>, ArtDgAmlContext, ArtDgamlAlertDetailViewStaff>
    {
        public DGAMLAlertDetailsStaffController(IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgamlAlertDetailViewStaff>, ArtDgAmlContext, ArtDgamlAlertDetailViewStaff> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

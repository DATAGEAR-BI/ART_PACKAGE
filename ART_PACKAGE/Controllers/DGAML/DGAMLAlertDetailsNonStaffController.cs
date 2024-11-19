using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTDGAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLAlertDetailsNonStaffController : BaseReportController<IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgamlAlertDetailViewNonStaff>, ArtDgAmlContext, ArtDgamlAlertDetailViewNonStaff>, IBaseRepo<ArtDgAmlContext, ArtDgamlAlertDetailViewNonStaff>, ArtDgAmlContext, ArtDgamlAlertDetailViewNonStaff>
    {
        public DGAMLAlertDetailsNonStaffController(IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgamlAlertDetailViewNonStaff>, ArtDgAmlContext, ArtDgamlAlertDetailViewNonStaff> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTDGAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLCustomersDetailsController : BaseReportController<IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgAmlCustomerDetailView>, ArtDgAmlContext, ArtDgAmlCustomerDetailView>, IBaseRepo<ArtDgAmlContext, ArtDgAmlCustomerDetailView>, ArtDgAmlContext, ArtDgAmlCustomerDetailView>
    {
        public DGAMLCustomersDetailsController(IGridConstructor<IBaseRepo<ArtDgAmlContext, ArtDgAmlCustomerDetailView>, ArtDgAmlContext, ArtDgAmlCustomerDetailView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

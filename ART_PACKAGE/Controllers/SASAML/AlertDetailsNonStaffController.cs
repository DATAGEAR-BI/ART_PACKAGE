using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "AlertDetailsNonStaff")]
    public class AlertDetailsNonStaffController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, ArtAmlAlertDetailViewNonStaff>, SasAmlContext, ArtAmlAlertDetailViewNonStaff>, IBaseRepo<SasAmlContext, ArtAmlAlertDetailViewNonStaff>, SasAmlContext, ArtAmlAlertDetailViewNonStaff>
    {
        public AlertDetailsNonStaffController(IGridConstructor<IBaseRepo<SasAmlContext, ArtAmlAlertDetailViewNonStaff>, SasAmlContext, ArtAmlAlertDetailViewNonStaff> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }




        public override IActionResult Index()
        {
            return View();
        }


    }
}

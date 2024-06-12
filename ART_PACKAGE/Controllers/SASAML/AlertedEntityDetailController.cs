using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    public class AlertedEntityDetailController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, ArtAlertsPerAlertedEntityView>, SasAmlContext, ArtAlertsPerAlertedEntityView>, IBaseRepo<SasAmlContext, ArtAlertsPerAlertedEntityView>, SasAmlContext, ArtAlertsPerAlertedEntityView>
    {
        public AlertedEntityDetailController(IGridConstructor<IBaseRepo<SasAmlContext, ArtAlertsPerAlertedEntityView>, SasAmlContext, ArtAlertsPerAlertedEntityView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

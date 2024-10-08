
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    public class SlaMedHighClosedAlertsExceeded10DayController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaMedHighClosedAlertsExceeded10Day>, SasAmlContext, SlaMedHighClosedAlertsExceeded10Day>, IBaseRepo<SasAmlContext, SlaMedHighClosedAlertsExceeded10Day>, SasAmlContext, SlaMedHighClosedAlertsExceeded10Day>
    {
        public SlaMedHighClosedAlertsExceeded10DayController(IGridConstructor<IBaseRepo<SasAmlContext, SlaMedHighClosedAlertsExceeded10Day>, SasAmlContext, SlaMedHighClosedAlertsExceeded10Day> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

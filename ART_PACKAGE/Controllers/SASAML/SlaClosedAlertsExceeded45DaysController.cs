using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "SlaClosedAlertsExceeded45Day")]
    public class SlaClosedAlertsExceeded45DaysController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaClosedAlertsExceeded45Day>, SasAmlContext, SlaClosedAlertsExceeded45Day>, IBaseRepo<SasAmlContext, SlaClosedAlertsExceeded45Day>, SasAmlContext, SlaClosedAlertsExceeded45Day>
    {
        public SlaClosedAlertsExceeded45DaysController(IGridConstructor<IBaseRepo<SasAmlContext, SlaClosedAlertsExceeded45Day>, SasAmlContext, SlaClosedAlertsExceeded45Day> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }


    }
}

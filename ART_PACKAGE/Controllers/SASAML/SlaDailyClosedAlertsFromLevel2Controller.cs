
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    public class SlaDailyClosedAlertsFromLevel2Controller : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaDailyClosedAlertsFromLevel2>, SasAmlContext, SlaDailyClosedAlertsFromLevel2>, IBaseRepo<SasAmlContext, SlaDailyClosedAlertsFromLevel2>, SasAmlContext, SlaDailyClosedAlertsFromLevel2>
    {
        public SlaDailyClosedAlertsFromLevel2Controller(IGridConstructor<IBaseRepo<SasAmlContext, SlaDailyClosedAlertsFromLevel2>, SasAmlContext, SlaDailyClosedAlertsFromLevel2> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "SlaAlertsExceeded20Days")]
    public class SlaAlertsExceeded20DaysController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaAlertsExceeded20Day>, SasAmlContext, SlaAlertsExceeded20Day>, IBaseRepo<SasAmlContext, SlaAlertsExceeded20Day>, SasAmlContext, SlaAlertsExceeded20Day>
    {
        public SlaAlertsExceeded20DaysController(IGridConstructor<IBaseRepo<SasAmlContext, SlaAlertsExceeded20Day>, SasAmlContext, SlaAlertsExceeded20Day> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }


    }
}

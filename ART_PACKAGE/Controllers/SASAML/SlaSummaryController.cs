using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "SlaSummary")]
    public class SlaSummaryController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, SlaSummary>, SasAmlContext, SlaSummary>, IBaseRepo<SasAmlContext, SlaSummary>, SasAmlContext, SlaSummary>
    {
        public SlaSummaryController(IGridConstructor<IBaseRepo<SasAmlContext, SlaSummary>, SasAmlContext, SlaSummary> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }


    }
}

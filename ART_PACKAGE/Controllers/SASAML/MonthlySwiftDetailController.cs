using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    public class MonthlySwiftDetailController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, ArtMonthlySwiftView>, SasAmlContext, ArtMonthlySwiftView>, IBaseRepo<SasAmlContext, ArtMonthlySwiftView>, SasAmlContext, ArtMonthlySwiftView>
    {
        public MonthlySwiftDetailController(IGridConstructor<IBaseRepo<SasAmlContext, ArtMonthlySwiftView>, SasAmlContext, ArtMonthlySwiftView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

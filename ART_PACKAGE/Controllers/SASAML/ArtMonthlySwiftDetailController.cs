using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    public class ArtMonthlySwiftDetailController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, ArtMonthlySwiftViewDetail>, SasAmlContext, ArtMonthlySwiftViewDetail>, IBaseRepo<SasAmlContext, ArtMonthlySwiftViewDetail>, SasAmlContext, ArtMonthlySwiftViewDetail>
    {
        public ArtMonthlySwiftDetailController(IGridConstructor<IBaseRepo<SasAmlContext, ArtMonthlySwiftViewDetail>, SasAmlContext, ArtMonthlySwiftViewDetail> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

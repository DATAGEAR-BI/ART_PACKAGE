using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    public class MakerCheckerPerformenceDetailController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, MakerCheckerPerformanceView>, EcmContext, MakerCheckerPerformanceView>, IBaseRepo<EcmContext, MakerCheckerPerformanceView>, EcmContext, MakerCheckerPerformanceView>
    {
        public MakerCheckerPerformenceDetailController(IGridConstructor<IBaseRepo<EcmContext, MakerCheckerPerformanceView>, EcmContext, MakerCheckerPerformanceView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

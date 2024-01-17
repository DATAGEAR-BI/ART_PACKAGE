using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM.SystemPerformanceSummaryReport
{
    public class SystemPerformancePerDirectionController : BaseReportController<IBaseRepo<EcmContext, ArtSystemPrefPerDirection>, EcmContext, ArtSystemPrefPerDirection>
    {
        public SystemPerformancePerDirectionController(IGridConstructor<IBaseRepo<EcmContext, ArtSystemPrefPerDirection>, EcmContext, ArtSystemPrefPerDirection> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

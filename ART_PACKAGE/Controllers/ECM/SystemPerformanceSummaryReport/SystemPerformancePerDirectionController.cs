using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM.SystemPerformanceSummaryReport
{
    public class SystemPerformancePerDirectionController : BaseReportController<EcmContext, ArtSystemPrefPerDirection>
    {
        public SystemPerformancePerDirectionController(IGridConstructor<EcmContext, ArtSystemPrefPerDirection> gridConstructor) : base(gridConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

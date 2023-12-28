using ART_PACKAGE.Helpers.Chart;
using Data.Data.ECM;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM.SystemPerformanceSummaryReport
{
    public class SystemPerformancePerStatusController : BaseChartController<EcmContext, ArtSystemPrefPerStatus>
    {
        public SystemPerformancePerStatusController(IChartConstructor<ArtSystemPrefPerStatus, EcmContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

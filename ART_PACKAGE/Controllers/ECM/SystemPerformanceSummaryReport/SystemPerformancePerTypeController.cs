using ART_PACKAGE.Helpers.Chart;
using Data.Data.ECM;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM.SystemPerformanceSummaryReport
{
    public class SystemPerformancePerTypeController : BaseChartController<EcmContext, ArtSystemPerfPerType>
    {
        public SystemPerformancePerTypeController(IChartConstructor<ArtSystemPerfPerType, EcmContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

using ART_PACKAGE.Helpers.Chart;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML.AlertSummaryReport
{
    public class AlertsPerStatusController : BaseChartController<SasAmlContext, ArtStAlertsPerStatus>
    {
        public AlertsPerStatusController(IChartConstructor<ArtStAlertsPerStatus, SasAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

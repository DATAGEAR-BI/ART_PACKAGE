using ART_PACKAGE.Helpers.Chart;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML.DGAMLAlertSummary
{
    public class ArtStDgAmlAlertsPerScenarioController : BaseChartController<ArtDgAmlContext, ArtStDgAmlAlertsPerScenario>
    {
        public ArtStDgAmlAlertsPerScenarioController(IChartConstructor<ArtStDgAmlAlertsPerScenario, ArtDgAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

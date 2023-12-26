using ART_PACKAGE.Helpers.Chart;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML.RiskSummaryReport
{
    public class AmlRiskController : BaseChartController<SasAmlContext, ArtStAmlRiskClass>
    {
        public AmlRiskController(IChartConstructor<ArtStAmlRiskClass, SasAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

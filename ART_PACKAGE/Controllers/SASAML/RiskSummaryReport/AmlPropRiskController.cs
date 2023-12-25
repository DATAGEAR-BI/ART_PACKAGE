using ART_PACKAGE.Helpers.Chart;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML.RiskSummaryReport
{
    public class AmlPropRiskController : BaseChartController<SasAmlContext, ArtStAmlPropRiskClass>
    {
        public AmlPropRiskController(IChartConstructor<ArtStAmlPropRiskClass, SasAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

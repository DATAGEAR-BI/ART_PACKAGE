using ART_PACKAGE.Helpers.Chart;
using Data.Data.ARTGOAML;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.GOAML.GOAMLSummaryReport
{
    public class GoAmlReportsPerTypeController : BaseChartController<ArtGoAmlContext, ArtStGoAmlReportsPerType>
    {
        public GoAmlReportsPerTypeController(IChartConstructor<ArtStGoAmlReportsPerType, ArtGoAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

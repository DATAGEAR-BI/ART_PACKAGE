using ART_PACKAGE.Helpers.Chart;
using Data.Data.ARTGOAML;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.GOAML.GOAMLSummaryReport
{
    public class GoAmlReportsPerCreatorController : BaseChartController<ArtGoAmlContext, ArtStGoAmlReportsPerCreator>
    {
        public GoAmlReportsPerCreatorController(IChartConstructor<ArtStGoAmlReportsPerCreator, ArtGoAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

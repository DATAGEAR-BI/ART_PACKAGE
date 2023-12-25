using ART_PACKAGE.Helpers.Chart;
using Data.Data.ARTGOAML;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.GOAML.GOAMLSummaryReport
{
    public class GoAmlReportsPerStatusController : BaseChartController<ArtGoAmlContext, ArtStGoAmlReportsPerStatus>
    {
        public GoAmlReportsPerStatusController(IChartConstructor<ArtStGoAmlReportsPerStatus, ArtGoAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

using ART_PACKAGE.Helpers.Chart;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML.DGAMLCasesSummary
{
    public class ArtStDgAmlCasesPerPriorityController : BaseChartController<ArtDgAmlContext, ArtStDgAmlCasesPerPriority>
    {
        public ArtStDgAmlCasesPerPriorityController(IChartConstructor<ArtStDgAmlCasesPerPriority, ArtDgAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

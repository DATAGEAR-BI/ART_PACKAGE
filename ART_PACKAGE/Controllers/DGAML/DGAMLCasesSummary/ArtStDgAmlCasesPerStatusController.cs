using ART_PACKAGE.Helpers.Chart;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML.DGAMLCasesSummary
{
    public class ArtStDgAmlCasesPerStatusController : BaseChartController<ArtDgAmlContext, ArtStDgAmlCasesPerStatus>
    {
        public ArtStDgAmlCasesPerStatusController(IChartConstructor<ArtStDgAmlCasesPerStatus, ArtDgAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

using ART_PACKAGE.Helpers.Chart;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML.CasesSummaryReport
{
    public class CasesPerStatusController : BaseChartController<SasAmlContext, ArtStCasesPerStatus>
    {

        public CasesPerStatusController(IChartConstructor<ArtStCasesPerStatus, SasAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

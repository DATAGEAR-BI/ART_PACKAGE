using ART_PACKAGE.Helpers.Chart;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML.CasesSummaryReport
{
    public class CasesPerSubCatController : BaseChartController<SasAmlContext, ArtStCasesPerSubcat>
    {
        public CasesPerSubCatController(IChartConstructor<ArtStCasesPerSubcat, SasAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

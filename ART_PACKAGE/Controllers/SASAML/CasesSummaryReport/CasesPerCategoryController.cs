using ART_PACKAGE.Helpers.Chart;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML.CasesSummaryReport
{
    public class CasesPerCategoryController : BaseChartController<SasAmlContext, ArtStCasesPerCategory>
    {
        public CasesPerCategoryController(IChartConstructor<ArtStCasesPerCategory, SasAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

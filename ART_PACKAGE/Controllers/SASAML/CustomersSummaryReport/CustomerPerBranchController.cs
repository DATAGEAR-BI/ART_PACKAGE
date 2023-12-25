using ART_PACKAGE.Helpers.Chart;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML.CustomersSummaryReport
{
    public class CustomerPerBranchController : BaseChartController<SasAmlContext, ArtStCustPerBranch>
    {
        public CustomerPerBranchController(IChartConstructor<ArtStCustPerBranch, SasAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

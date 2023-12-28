using ART_PACKAGE.Helpers.Chart;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML.DGAMLCustomerSummary
{
    public class ArtStDgAmlCustomerPerBranchController : BaseChartController<ArtDgAmlContext, ArtStDgAmlCustomerPerBranch>
    {
        public ArtStDgAmlCustomerPerBranchController(IChartConstructor<ArtStDgAmlCustomerPerBranch, ArtDgAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

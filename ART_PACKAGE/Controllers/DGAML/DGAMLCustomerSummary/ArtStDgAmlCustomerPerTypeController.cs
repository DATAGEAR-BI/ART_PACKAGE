using ART_PACKAGE.Helpers.Chart;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML.DGAMLCustomerSummary
{
    public class ArtStDgAmlCustomerPerTypeController : BaseChartController<ArtDgAmlContext, ArtStDgAmlCustomerPerType>
    {
        public ArtStDgAmlCustomerPerTypeController(IChartConstructor<ArtStDgAmlCustomerPerType, ArtDgAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

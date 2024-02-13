using ART_PACKAGE.Helpers.Chart;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML.DGAMLExternalCustomerSummary
{
    public class DGAmlExternalCustomerPerTypeController : BaseChartController<ArtDgAmlContext, ArtStDgAmlExternalCustomerPerType>
    {
        public DGAmlExternalCustomerPerTypeController(IChartConstructor<ArtStDgAmlExternalCustomerPerType, ArtDgAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}
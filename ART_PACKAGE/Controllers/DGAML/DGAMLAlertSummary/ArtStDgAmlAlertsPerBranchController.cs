using ART_PACKAGE.Helpers.Chart;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGAML.DGAMLAlertSummary
{
    public class ArtStDgAmlAlertsPerBranchController : BaseChartController<ArtDgAmlContext, ArtStDgAmlAlertsPerBranch>
    {
        public ArtStDgAmlAlertsPerBranchController(IChartConstructor<ArtStDgAmlAlertsPerBranch, ArtDgAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

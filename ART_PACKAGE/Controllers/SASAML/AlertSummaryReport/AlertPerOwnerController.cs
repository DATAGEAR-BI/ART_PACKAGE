using ART_PACKAGE.Helpers.Chart;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML.AlertSummaryReport
{
    public class AlertPerOwnerController : BaseChartController<SasAmlContext, ArtStAlertPerOwner>
    {
        public AlertPerOwnerController(IChartConstructor<ArtStAlertPerOwner, SasAmlContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

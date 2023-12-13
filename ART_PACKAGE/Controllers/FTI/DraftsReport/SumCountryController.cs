using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI.DraftsReport
{
    public class SumCountryController : BaseReportController<FTIContext, ArtStTiOdcOutStaSumCountry>
    {
        public SumCountryController(IGridConstructor<FTIContext, ArtStTiOdcOutStaSumCountry> gridConstructor) : base(gridConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

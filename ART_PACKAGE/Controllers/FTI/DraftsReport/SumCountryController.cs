using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI.DraftsReport
{
    public class SumCountryController : BaseReportController<IGridConstructor<IBaseRepo<FTIContext, ArtStTiOdcOutStaSumCountry>, FTIContext, ArtStTiOdcOutStaSumCountry>, IBaseRepo<FTIContext, ArtStTiOdcOutStaSumCountry>, FTIContext, ArtStTiOdcOutStaSumCountry>
    {
        public SumCountryController(IGridConstructor<IBaseRepo<FTIContext, ArtStTiOdcOutStaSumCountry>, FTIContext, ArtStTiOdcOutStaSumCountry> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

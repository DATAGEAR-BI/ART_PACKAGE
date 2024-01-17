using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI.DraftsReport
{
    public class OutStaController : BaseReportController<IBaseRepo<FTIContext, ArtStTiOdcOutSta>, FTIContext, ArtStTiOdcOutSta>
    {
        public OutStaController(IGridConstructor<IBaseRepo<FTIContext, ArtStTiOdcOutSta>, FTIContext, ArtStTiOdcOutSta> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

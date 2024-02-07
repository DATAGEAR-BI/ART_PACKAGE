using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI.DraftsReport
{
    public class DraftTypeController : BaseReportController<IGridConstructor<IBaseRepo<FTIContext, ArtStTiOdcOutStaSumDraftType>, FTIContext, ArtStTiOdcOutStaSumDraftType>, IBaseRepo<FTIContext, ArtStTiOdcOutStaSumDraftType>, FTIContext, ArtStTiOdcOutStaSumDraftType>
    {
        public DraftTypeController(IGridConstructor<IBaseRepo<FTIContext, ArtStTiOdcOutStaSumDraftType>, FTIContext, ArtStTiOdcOutStaSumDraftType> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

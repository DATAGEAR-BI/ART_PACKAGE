using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI.DraftsReport
{
    public class DraftStatusController : BaseReportController<IBaseRepo<FTIContext, ArtStTiOdcOutStaSumDraftStatus>, FTIContext, ArtStTiOdcOutStaSumDraftStatus>
    {
        public DraftStatusController(IGridConstructor<IBaseRepo<FTIContext, ArtStTiOdcOutStaSumDraftStatus>, FTIContext, ArtStTiOdcOutStaSumDraftStatus> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

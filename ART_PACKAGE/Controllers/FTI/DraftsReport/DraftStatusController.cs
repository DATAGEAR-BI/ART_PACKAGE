using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI.DraftsReport
{
    public class DraftStatusController : BaseReportController<FTIContext, ArtStTiOdcOutStaSumDraftStatus>
    {
        public DraftStatusController(IGridConstructor<FTIContext, ArtStTiOdcOutStaSumDraftStatus> gridConstructor) : base(gridConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

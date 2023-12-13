using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI.DraftsReport
{
    public class DraftTypeController : BaseReportController<FTIContext, ArtStTiOdcOutStaSumDraftType>
    {
        public DraftTypeController(IGridConstructor<FTIContext, ArtStTiOdcOutStaSumDraftType> gridConstructor) : base(gridConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

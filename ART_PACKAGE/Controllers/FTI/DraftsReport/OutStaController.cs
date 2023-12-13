using ART_PACKAGE.Helpers.Grid;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.FTI.DraftsReport
{
    public class OutStaController : BaseReportController<FTIContext, ArtStTiOdcOutSta>
    {
        public OutStaController(IGridConstructor<FTIContext, ArtStTiOdcOutSta> gridConstructor) : base(gridConstructor)
        {
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

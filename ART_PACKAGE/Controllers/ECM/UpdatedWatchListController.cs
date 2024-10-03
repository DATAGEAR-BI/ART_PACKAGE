using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "UpdatedWatchList")]
    public class UpdatedWatchListController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtUpdatedWatchList>, EcmContext, ArtUpdatedWatchList>, IBaseRepo<EcmContext, ArtUpdatedWatchList>, EcmContext, ArtUpdatedWatchList>
    {
        public UpdatedWatchListController(IGridConstructor<IBaseRepo<EcmContext, ArtUpdatedWatchList>, EcmContext, ArtUpdatedWatchList> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

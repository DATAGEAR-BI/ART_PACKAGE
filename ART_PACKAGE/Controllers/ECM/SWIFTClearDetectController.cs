using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "SWIFTClearDetect")]
    public class SWIFTClearDetectController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtSwiftClearDetect>, EcmContext, ArtSwiftClearDetect>, IBaseRepo<EcmContext, ArtSwiftClearDetect>, EcmContext, ArtSwiftClearDetect>
    {
        public SWIFTClearDetectController(IGridConstructor<IBaseRepo<EcmContext, ArtSwiftClearDetect>, EcmContext, ArtSwiftClearDetect> gridConstructor, UserManager<Areas.Identity.Data.AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

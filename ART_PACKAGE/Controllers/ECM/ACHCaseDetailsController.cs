using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "ACHCaseDetails")]
    public class ACHCaseDetailsController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtCaseIncidentsInfo>, EcmContext, ArtCaseIncidentsInfo>, IBaseRepo<EcmContext, ArtCaseIncidentsInfo>, EcmContext, ArtCaseIncidentsInfo>
    {
        public ACHCaseDetailsController(IGridConstructor<IBaseRepo<EcmContext, ArtCaseIncidentsInfo>, EcmContext, ArtCaseIncidentsInfo> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }


        public override IActionResult Index()
        {
            return View();
        }
    }
}

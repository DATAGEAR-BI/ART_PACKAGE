using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    public class ArtWebAuditController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtWebAudit>, EcmContext, ArtWebAudit>, IBaseRepo<EcmContext, ArtWebAudit>, EcmContext, ArtWebAudit>
    {
        public ArtWebAuditController(IGridConstructor<IBaseRepo<EcmContext, ArtWebAudit>, EcmContext, ArtWebAudit> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
         }
    }
}

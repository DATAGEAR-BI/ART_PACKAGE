using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTAUDIT;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ARTAUDIT
{
    public class ArtAuditUserAccessController : BaseReportController<IGridConstructor<IBaseRepo<ARTAUDITContext, ArtAuditUserAccessLog>, ARTAUDITContext, ArtAuditUserAccessLog>, IBaseRepo<ARTAUDITContext, ArtAuditUserAccessLog>, ARTAUDITContext, ArtAuditUserAccessLog>
    {
        public ArtAuditUserAccessController(IGridConstructor<IBaseRepo<ARTAUDITContext, ArtAuditUserAccessLog>, ARTAUDITContext, ArtAuditUserAccessLog> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

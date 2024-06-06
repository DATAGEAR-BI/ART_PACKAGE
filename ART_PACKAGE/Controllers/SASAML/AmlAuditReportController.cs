using ART_PACKAGE.Helpers.Grid;
using Data.Data.SASAml;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "AmlAuditReportC")]
    public class AmlAuditReportController : BaseReportController<IGridConstructor<IBaseRepo<SasAmlContext, ArtAuditReportView>, SasAmlContext, ArtAuditReportView>, IBaseRepo<SasAmlContext, ArtAuditReportView>, SasAmlContext, ArtAuditReportView>
    {
        public AmlAuditReportController(IGridConstructor<IBaseRepo<SasAmlContext, ArtAuditReportView>, SasAmlContext, ArtAuditReportView> gridConstructor, UserManager<Areas.Identity.Data.AppUser> um) : base(gridConstructor, um)
        {
        }



        public override IActionResult Index()
        {
            return View();
        }
    }
}

using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ARTDGSupport;
using Data.Data.ARTGOAML;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGSUPPORT
{
    public class TicketDetailsController : BaseReportController<IGridConstructor<IBaseRepo<ARTDGSupportContext, ArtTicketDetail>, ARTDGSupportContext, ArtTicketDetail>, IBaseRepo<ARTDGSupportContext, ArtTicketDetail>, ARTDGSupportContext, ArtTicketDetail>
    {
        public TicketDetailsController(IGridConstructor<IBaseRepo<ARTDGSupportContext, ArtTicketDetail>, ARTDGSupportContext, ArtTicketDetail> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
    }
}

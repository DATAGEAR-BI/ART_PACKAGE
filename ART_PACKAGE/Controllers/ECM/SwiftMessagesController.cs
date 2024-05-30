using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    public class SwiftMessagesController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtSwiftMessagesView>, EcmContext, ArtSwiftMessagesView>, IBaseRepo<EcmContext, ArtSwiftMessagesView>, EcmContext, ArtSwiftMessagesView>
    {
        public SwiftMessagesController(IGridConstructor<IBaseRepo<EcmContext, ArtSwiftMessagesView>, EcmContext, ArtSwiftMessagesView> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}

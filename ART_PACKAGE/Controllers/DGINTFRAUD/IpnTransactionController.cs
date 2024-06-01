using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.DGINTFRAUD;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    public class IpnTransactionController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlIpnTransaction>, DGINTFRAUDContext, ArtDgamlIpnTransaction>, IBaseRepo<DGINTFRAUDContext, ArtDgamlIpnTransaction>, DGINTFRAUDContext, ArtDgamlIpnTransaction>
    {
        public IpnTransactionController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, ArtDgamlIpnTransaction>, DGINTFRAUDContext, ArtDgamlIpnTransaction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }

    }
}

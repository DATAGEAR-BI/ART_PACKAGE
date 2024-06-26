using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.DGINTFRAUD;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.DGINTFRAUD
{
    public class SixMonthTransactionController : BaseReportController<IGridConstructor<IBaseRepo<DGINTFRAUDContext, Art6MonthTransaction>, DGINTFRAUDContext, Art6MonthTransaction>, IBaseRepo<DGINTFRAUDContext, Art6MonthTransaction>, DGINTFRAUDContext, Art6MonthTransaction>
    {
        public SixMonthTransactionController(IGridConstructor<IBaseRepo<DGINTFRAUDContext, Art6MonthTransaction>, DGINTFRAUDContext, Art6MonthTransaction> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }

    }
}

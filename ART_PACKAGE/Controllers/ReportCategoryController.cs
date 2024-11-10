using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data;
using Data.Services.CustomReport;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers
{
    public class ReportCategoryController : BaseReportController<IGridConstructor<IReportCategoryRepo, CustomReportsContext, ReportCategory>, IReportCategoryRepo, CustomReportsContext, ReportCategory>
    {
        public ReportCategoryController(IGridConstructor<IReportCategoryRepo, CustomReportsContext, ReportCategory> gridConstructor) : base(gridConstructor)
        {
                
        }
        public override IActionResult Index()
        {
            return View();
        }
        public  IActionResult Getcategorieslist()
        {
            var categories=_gridConstructor.Repo.GetAll().Select(s => new { s.Id, s.Name, s.ParentId });
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(categories)
            };
        }
    }
}
    
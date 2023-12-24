using ART_PACKAGE.Helpers.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace ART_PACKAGE.Controllers
{
    public abstract class BaseReportController<TContext, TModel> : Controller
        where TContext : DbContext
        where TModel : class
    {
        protected readonly IGridConstructor<TContext, TModel> _gridConstructor;
        protected Expression<Func<TModel, bool>>? baseCondition;

        protected BaseReportController(IGridConstructor<TContext, TModel> gridConstructor)
        {
            _gridConstructor = gridConstructor;
        }

        public abstract IActionResult Index();
        [HttpPost]
        public virtual async Task<IActionResult> GetData([FromBody] GridRequest request)
        {

            if (request.IsIntialize)
            {

                GridIntializationConfiguration res = _gridConstructor.IntializeGrid(GetType().Name, User);
                return new ContentResult
                {
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(res)
                };
            }
            else
            {

                GridResult<TModel> res = _gridConstructor.GetGridData(request, baseCondition);
                return new ContentResult
                {
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(res)
                };
            }
        }




        [HttpPost("[controller]/[action]/{gridId}")]

        public async Task<IActionResult> ExportToCsv([FromBody] GridRequest req, [FromRoute] string gridId)
        {
            string folderGuid = _gridConstructor.ExportGridToCsv(req, User.Identity.Name, gridId);
            return Ok(new { folder = folderGuid });
        }


    }
}

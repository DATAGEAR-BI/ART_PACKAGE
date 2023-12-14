using ART_PACKAGE.Helpers.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers
{
    public abstract class BaseReportController<TContext, TModel> : Controller
        where TContext : DbContext
        where TModel : class
    {
        protected readonly IGridConstructor<TContext, TModel> _gridConstructor;


        protected BaseReportController(IGridConstructor<TContext, TModel> gridConstructor)
        {
            _gridConstructor = gridConstructor;

        }

        public abstract IActionResult Index();
        [HttpPost]
        public async Task<IActionResult> GetData([FromBody] GridRequest request)
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

                GridResult<TModel> res = _gridConstructor.Repo.GetGridData(request);
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

using ART_PACKAGE.Helpers.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;


namespace ART_PACKAGE.Controllers
{
    public abstract class BaseReportController<TRepo, TContext, TModel> : BaseController
        where TContext : DbContext
        where TModel : class where TRepo : IBaseRepo<TContext, TModel>
    {
        protected readonly IGridConstructor<TRepo, TContext, TModel> _gridConstructor;
        protected Expression<Func<TModel, bool>>? baseCondition;
        protected IEnumerable<Expression<Func<TModel, object>>>? includes;


        protected BaseReportController(IGridConstructor<TRepo, TContext, TModel> gridConstructor, UserManager<AppUser> um) : base(um)
        {
            _gridConstructor = gridConstructor;
        }

        public abstract IActionResult Index();
        [HttpPost]
        public virtual async Task<IActionResult> GetData([FromBody] GridRequest request)
        {

            if (request.IsIntialize)
            {

                GridIntializationConfiguration res = _gridConstructor.IntializeGrid(typeof(TModel).Name, User);
                return new ContentResult
                {
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(res)
                };
            }
            else
            {

                GridResult<TModel> res = _gridConstructor.GetGridData(request, baseCondition, includes);
                return new ContentResult
                {
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(res, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
                };
            }
        }




        [HttpPost("[controller]/[action]/{gridId}")]

        public async Task<IActionResult> ExportToCsv([FromBody] ExportRequest req, [FromRoute] string gridId)
        {
            string folderGuid = _gridConstructor.ExportGridToCsv(req, User.Identity.Name, gridId, baseCondition);
            return Ok(new { folder = folderGuid });
        }


    }
}

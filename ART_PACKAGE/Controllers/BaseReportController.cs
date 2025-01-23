using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Services;
using Data.Services.Grid;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace ART_PACKAGE.Controllers
{
    public abstract class BaseReportController<TGridConstuctor, TRepo, TContext, TModel> : BaseController
        where TContext : DbContext
        where TModel : class
        where TRepo : IBaseRepo<TContext, TModel>
        where TGridConstuctor : IGridConstructor<TRepo, TContext, TModel>
    {
        protected readonly TGridConstuctor _gridConstructor;
        protected Expression<Func<TModel, bool>>? baseCondition;
        protected IEnumerable<Expression<Func<TModel, object>>>? includes;


        protected BaseReportController(TGridConstuctor gridConstructor, UserManager<AppUser> um) : base(um)
        {
            _gridConstructor = gridConstructor;


        }

        public abstract IActionResult Index();
        [HttpPost]
        public virtual async Task<IActionResult> GetData([FromBody] GridRequest request)
        {

            if (request.IsIntialize)
            {

                GridIntializationConfiguration res = _gridConstructor.IntializeGrid((typeof(TModel).Name + "Config").ToLower(), User);
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
        public virtual async Task<IActionResult> ExportPdf([FromBody] ExportRequest req, [FromRoute] string gridId, [FromQuery] string reportGUID)
        {
            string Url = $"{Request.Scheme}://{Request.Host}";
            ViewData["Domain"] = Url;
            byte[] pdfBytes = await _gridConstructor.ExportGridToPdf(req, User.Identity.Name, ControllerContext, ViewData, reportGUID);
            return File(pdfBytes, "application/pdf");
        }



        [HttpPost("[controller]/[action]/{gridId}")]

        public virtual async Task<IActionResult> ExportToCsv([FromBody] ExportRequest req, [FromRoute] string gridId, [FromQuery] string reportGUID)
        {

            AppUser user = await GetUser();
            string folderGuid = reportGUID != null ? _gridConstructor.ExportGridToCsv(req, user.UserName, gridId, reportGUID, baseCondition) : _gridConstructor.ExportGridToCsv(req, user.UserName, gridId, baseCondition);

            return Ok(new { folder = folderGuid });
        }


    }
}

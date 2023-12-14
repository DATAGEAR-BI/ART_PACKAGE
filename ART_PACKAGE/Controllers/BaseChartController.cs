using ART_PACKAGE.Helpers.Chart;
using Data.Services;
using Data.Services.QueryBuilder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers
{
    public abstract class BaseChartController<TContext, TModel> : Controller where TContext : DbContext
        where TModel : class, IChartDataEntity
    {
        protected readonly IChartConstructor<TModel, TContext> _chartConstructor;

        public BaseChartController(IChartConstructor<TModel, TContext> chartConstructor)
        {
            _chartConstructor = chartConstructor;
        }

        public abstract IActionResult Index();
        [HttpPost]
        public async Task<IActionResult> GetData([FromBody] List<BuilderFilter> filters)
        {
            IEnumerable<IChartDataEntity> res = _chartConstructor.GetChartData(filters);
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(res)
            };
        }
    }

}


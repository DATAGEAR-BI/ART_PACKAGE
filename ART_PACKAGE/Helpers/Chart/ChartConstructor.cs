using Data.Services;
using Data.Services.QueryBuilder;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.Chart
{
    public class ChartConstructor<TModel, TContext> : IChartConstructor<TModel, TContext>
        where TContext : DbContext
      where TModel : class, IChartDataEntity
    {
        private readonly IBaseRepo<TContext, TModel> repo;

        public ChartConstructor(IBaseRepo<TContext, TModel> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<TModel> GetChartData(List<BuilderFilter> filters)
        {
            IQueryable<TModel> data = repo.ExcueteProc(filters);
            return data;
        }
    }
}

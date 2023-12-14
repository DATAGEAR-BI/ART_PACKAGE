using Data.Services;
using Data.Services.QueryBuilder;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.Chart
{
    public interface IChartConstructor<TModel, TContext> where TContext : DbContext
        where TModel : class, IChartDataEntity

    {
        public IEnumerable<IChartDataEntity> GetChartData(List<BuilderFilter> filters);
    }
}

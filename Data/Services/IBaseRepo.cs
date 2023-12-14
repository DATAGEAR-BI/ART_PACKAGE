using Data.Services.Grid;
using Data.Services.QueryBuilder;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public interface IBaseRepo<TContext, TModel>
        where TContext : DbContext
        where TModel : class
    {
        public GridResult<TModel> GetGridData(GridRequest request, SortOption? defaultSort = null);


        public IQueryable<TModel> ExcueteProc(List<BuilderFilter> QueryBuilderFilters);

        public bool BulkInsert(IEnumerable<TModel> data);
    }
}

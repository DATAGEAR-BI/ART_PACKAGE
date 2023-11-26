using Data.Services.Grid;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public interface IBaseRepo<TContext, TModel>
        where TContext : DbContext
        where TModel : class
    {
        public GridResult<TModel> GetGridData(GridRequest request, SortOption? defaultSort = null);
    }
}

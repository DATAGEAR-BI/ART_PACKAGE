using Data.Services.Grid;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public class BaseRepo<TContext, TModel> : IBaseRepo<TContext, TModel>
        where TContext : DbContext
        where TModel : class
    {
        private readonly TContext _context;

        public BaseRepo(TContext context)
        {
            _context = context;
        }

        public GridResult<TModel> GetGridData(GridRequest request, SortOption? defaultSort = null)
        {
            var data = _context.Set<TModel>().AsQueryable();
            System.Linq.Expressions.Expression<Func<TModel, bool>> ex = request.Filter.ToExpression<TModel>();

            data = data.Where(ex);
            int count = data.Count();


            if (request.Sort is not null && request.Sort.Any())
            {
                SortOption firtsOption = request.Sort[0];
                System.Linq.Expressions.Expression<Func<TModel, object>> sortEx = firtsOption.GetSortExpression<TModel>();

                IOrderedQueryable<TModel>? sortedData = firtsOption.dir.ToLower().Contains("asc") ? data.OrderBy(sortEx) : data.OrderByDescending(sortEx);
                foreach (SortOption? item in request.Sort.Skip(1))
                {
                    sortEx = item.GetSortExpression<TModel>();
                    sortedData = item.dir.ToLower().Contains("asc") ? sortedData.ThenBy(sortEx) : sortedData.ThenByDescending(sortEx);
                }
                data = sortedData;
            }
            else
            {
                if (defaultSort != null)
                {
                    System.Linq.Expressions.Expression<Func<TModel, object>> sortEx = defaultSort.GetSortExpression<TModel>();
                    data = defaultSort.dir.ToLower().Contains("asc") ? data.OrderBy(sortEx) : data.OrderByDescending(sortEx);
                }
            }
            if (request.Skip != 0)
                data = data.Skip(request.Skip);


            if (request.Take < count)
                data = data.Take(request.Take);


            return new GridResult<TModel>
            {
                data = data,
                total = count,
            };
        }

    }
}

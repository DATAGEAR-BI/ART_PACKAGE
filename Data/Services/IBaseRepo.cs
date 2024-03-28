using Data.Services.Grid;
using Data.Services.QueryBuilder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Services
{
    public interface IBaseRepo<TContext, TModel>
        where TContext : DbContext
        where TModel : class
    {
        public GridResult<TModel> GetGridData(GridRequest request, SortOption? defaultSort = null, IEnumerable<Expression<Func<TModel, object>>>? includes = null);


        public IQueryable<TModel> ExcueteProc(List<BuilderFilter> QueryBuilderFilters);

        public bool BulkInsert(IEnumerable<TModel> data);


        public IEnumerable<TModel> GetAll();

        public IEnumerable<TModel> GetByCondition(Expression<Func<TModel, bool>> condition);
        public TModel? GetFirstWithCondition(Expression<Func<TModel, bool>> condition);

        public IEnumerable<object?> GetDistinctValuesOf(Expression<Func<TModel, object>> propertySelector, Expression<Func<TModel, bool>>? condition = null);

        public bool DeleteAll();
    }
}

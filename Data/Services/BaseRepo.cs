using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Services.DbContextExtentions;
using Data.Services.Grid;
using Data.Services.QueryBuilder;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Data.Services
{
    public class BaseRepo<TContext, TModel> : IBaseRepo<TContext, TModel>
        where TContext : DbContext
        where TModel : class
    {
        protected readonly TContext _context;

        public BaseRepo(TContext context)
        {
            _context = context;
        }

        public bool BulkInsert(IEnumerable<TModel> data)
        {
            if (data == null || !data.Any())
            {
                return false;
            }
            try
            {
                _context.BulkInsert(data);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }




        public virtual GridResult<TModel> GetGridData(GridRequest request, Expression<Func<TModel, bool>>? baseCondition = null, SortOption? defaultSort = null, IEnumerable<Expression<Func<TModel, object>>>? includes = null)
        {
            IQueryable<TModel> data;
            if (!request.IsStored)
                data = _context.Set<TModel>().AsQueryable();
            else
                data = ExcueteProc(request.QueryBuilderFilters);

            if (includes is not null)
            {
                foreach (var inculde in includes)
                {
                    data = data.Include(inculde);
                }
            }

            if (baseCondition is not null)
            {
                data = data.Where(baseCondition);
            }
            System.Linq.Expressions.Expression<Func<TModel, bool>> ex = request.Filter.ToExpression<TModel>();

            data = data.Where(ex);
            if (!request.All && request.IdColumn!=null)
            {
                var parameter = Expression.Parameter(typeof(TModel), "item");
                var property = Expression.Property(parameter, request.IdColumn);
                var constantValues = request.SelectedValues.Select(value => Expression.Constant(Convert.ChangeType(value, property.Type)));

                var containsMethod = typeof(Enumerable)
                    .GetMethods()
                    .Where(method => method.Name == "Contains")
                    .Single(method => method.GetParameters().Length == 2)
                    .MakeGenericMethod(property.Type);

                var containsExpression = Expression.Call(
                    containsMethod,
                    Expression.Constant(request.SelectedValues),
                    property
                );

                var predicate = Expression.Lambda<Func<TModel, bool>>(containsExpression, parameter);
                data = data.Where(predicate);
            }
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
                defaultSort = defaultSort ?? getDefaultSortOption();
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

        public IQueryable<TModel> GetScheduleData(List<object> @params)
        {
            Expression<Func<TModel, bool>> clause = FilterExtensions.GenerateExpression<TModel>(@params);
            return _context.Set<TModel>().Where(clause);
        }


        public IQueryable<TModel> ExcueteProc(List<BuilderFilter> QueryBuilderFilters)
        {
            var dbType = _context.Database.IsOracle() ? DbTypes.Oracle : _context.Database.IsSqlServer() ? DbTypes.SqlServer : DbTypes.MySql;
            var @params = QueryBuilderFilters.MapToParameters(dbType);
            var storedName = StoredNameManager.GetStoredName<TModel>(dbType);
            return _context.ExecuteProc<TModel>(storedName, @params.ToArray()).AsQueryable();
        }

        public IEnumerable<TModel> GetAll()
        {
            return _context.Set<TModel>();
        }

        public bool DeleteAll()
        {
            try
            {
                var allData = GetAll();
                _context.Set<TModel>().BulkDelete(allData);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public IEnumerable<TModel> GetByCondition(Expression<Func<TModel, bool>> condition)
        {
            return _context.Set<TModel>().Where(condition);
        }

        public IEnumerable<object?> GetDistinctValuesOf(Expression<Func<TModel, object>> propertySelector, Expression<Func<TModel, bool>>? condition = null)
        {
            var query = _context.Set<TModel>().AsQueryable();

            if (condition != null)
                query = query.Where(condition);


            return query.Select(propertySelector).Distinct();
        }

        public TModel? GetFirstWithCondition(Expression<Func<TModel, bool>> condition)
        {
            return _context.Set<TModel>().FirstOrDefault(condition);
        }

        private SortOption getDefaultSortOption()
        {
            var entityType = _context.Model.FindEntityType(typeof(TModel));
            if (entityType == null)
            {
                Console.WriteLine("Entity type not found.");
                return null;
            }
            // Retrieve indexed columns
            var indexedColumns = entityType.GetIndexes()
                .SelectMany(index => index.Properties)
                .Distinct()
                .Select(property => property.Name).FirstOrDefault();
            if (indexedColumns is not null)
            {
                return new()
                {
                    dir = "asc",
                    field = indexedColumns
                };
            }
            
            Type[] dataTypesOrder = new Type[]
            {
                typeof(int),
                typeof(int?),
                typeof(DateTime),
                typeof(DateTime?),
                typeof(decimal),
                typeof(decimal?),
                typeof(string)
            };
            IProperty firstMatchingColumn = null;
            foreach (var type in dataTypesOrder)
            {
                firstMatchingColumn = entityType.GetProperties().FirstOrDefault(property => property.ClrType == type);
                if (firstMatchingColumn != null)
                {
                    break;
                }
            }
        
            if (firstMatchingColumn != null)
            {
                Console.WriteLine($"\nFirst mached Column: {firstMatchingColumn.Name} has type :{firstMatchingColumn.ClrType.Name}");
                return new()
                {
                    dir = "asc",
                    field = firstMatchingColumn.Name
                }; 
            }
            else
            {
                Console.WriteLine("\nNo Mached column found.");
                return null;
            }
            
        }
    }
}

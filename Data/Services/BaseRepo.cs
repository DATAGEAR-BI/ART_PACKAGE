using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Services.DbContextExtentions;
using Data.Services.Grid;
using Data.Services.QueryBuilder;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;


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


            //if (_context.Database.IsOracle())
            //    return OracleBulkInsert(data);


            //Microsoft.EntityFrameworkCore.Metadata.IEntityType? entityType = _context.Model.FindEntityType(typeof(TModel));
            //string? tableName = entityType?.GetTableName() ?? entityType?.GetViewName();

            //StringBuilder stringBuilder = new();
            //stringBuilder.AppendLine($"INSERT INTO {tableName} (");

            //List<Microsoft.EntityFrameworkCore.Metadata.IProperty> properties = entityType.GetProperties().Where(p => p.PropertyInfo != null && p.Name != "Id").ToList();
            //string columns = string.Join(", ", properties.Select(p => p?.GetColumnName() ?? p.Name));

            //stringBuilder.AppendLine(columns);
            //stringBuilder.AppendLine(") VALUES");

            //List<string> parameterList = new();

            //foreach (TModel entity in data)
            //{
            //    IEnumerable<string> values = properties.Select(p =>
            //    {
            //        object? value = p.PropertyInfo.GetValue(entity);
            //        if (value != null)
            //        {

            //            if (p.PropertyInfo.PropertyType == typeof(string) || Nullable.GetUnderlyingType(p.PropertyInfo.PropertyType) == typeof(string))
            //            {
            //                // Escape single quotes in string values
            //                value = ((string?)value)?.Replace("'", "''"); // Handle nullable string
            //                return $"'{value}'";
            //            }
            //            else if (p.PropertyInfo.PropertyType == typeof(DateTime) || Nullable.GetUnderlyingType(p.PropertyInfo.PropertyType) == typeof(DateTime))
            //            {
            //                return $"'{(DateTime)value:yyyy-MM-dd HH:mm:ss}'";
            //            }
            //            else
            //            {
            //                return $"{value}";
            //            }
            //        }
            //        else
            //        {
            //            return "NULL";
            //        }
            //    });

            //    parameterList.Add($"({string.Join(", ", values)})");
            //}

            //stringBuilder.AppendLine(string.Join(",\n", parameterList));
            //stringBuilder.AppendLine(";");



            //int effected = _context.Database.ExecuteSqlRaw(stringBuilder.ToString());
            //return effected > 0;
        }




        public GridResult<TModel> GetGridData(GridRequest request, SortOption? defaultSort = null)
        {
            IQueryable<TModel> data;
            if (!request.IsStored)
                data = _context.Set<TModel>().AsQueryable();
            else
                data = ExcueteProc(request.QueryBuilderFilters);



            System.Linq.Expressions.Expression<Func<TModel, bool>> ex = request.Filter.ToExpression<TModel>();

            data = data.Where(ex);
            if (!request.All)
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

        public IQueryable<TModel> ExcueteProc(List<BuilderFilter> QueryBuilderFilters)
        {
            var dbType = _context.Database.IsOracle() ? DbTypes.Oracle : DbTypes.SqlServer;
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
    }
}

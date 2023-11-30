using Data.Services.Grid;
using Microsoft.EntityFrameworkCore;
using System.Text;

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

            Microsoft.EntityFrameworkCore.Metadata.IEntityType? entityType = _context.Model.FindEntityType(typeof(TModel));
            string? tableName = entityType?.GetTableName() ?? entityType?.GetViewName();

            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"INSERT INTO {tableName} (");

            List<Microsoft.EntityFrameworkCore.Metadata.IProperty> properties = entityType.GetProperties().Where(p => p.PropertyInfo != null && p.Name != "Id").ToList();
            string columns = string.Join(", ", properties.Select(p => p?.GetColumnName() ?? p.Name));

            stringBuilder.AppendLine(columns);
            stringBuilder.AppendLine(") VALUES");

            List<string> parameterList = new();

            foreach (TModel entity in data)
            {
                IEnumerable<string> values = properties.Select(p =>
                {
                    object? value = p.PropertyInfo.GetValue(entity);
                    if (value != null)
                    {

                        if (p.PropertyInfo.PropertyType == typeof(string) || Nullable.GetUnderlyingType(p.PropertyInfo.PropertyType) == typeof(string))
                        {
                            // Escape single quotes in string values
                            value = ((string?)value)?.Replace("'", "''"); // Handle nullable string
                            return $"'{value}'";
                        }
                        else if (p.PropertyInfo.PropertyType == typeof(DateTime) || Nullable.GetUnderlyingType(p.PropertyInfo.PropertyType) == typeof(DateTime))
                        {
                            return $"'{(DateTime)value:yyyy-MM-dd HH:mm:ss}'";
                        }
                        else
                        {
                            return $"{value}";
                        }
                    }
                    else
                    {
                        return "NULL";
                    }
                });

                parameterList.Add($"({string.Join(", ", values)})");
            }

            stringBuilder.AppendLine(string.Join(",\n", parameterList));
            stringBuilder.AppendLine(";");



            int effected = _context.Database.ExecuteSqlRaw(stringBuilder.ToString());
            return effected > 0;
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

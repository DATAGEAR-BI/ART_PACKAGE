using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Linq.Expressions;
using System.Reflection;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    internal class CurrencyTypeConverter : DefaultTypeConverter
    {
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is double decimalValue)
            {
                // Format the decimal as currency
                return string.Format("{0:n2}", decimalValue);
            }

            return base.ConvertToString(value, row, memberMapData);
        }
    }
    internal class GenericCsvClassMapper<TModel> : ClassMap<TModel>
    {

        protected List<string> _inculdedColumns;
        protected readonly Dictionary<string, (string displayName, PropertyInfo propInfo)> propNameMap;
        public GenericCsvClassMapper(List<string>? includedColumns = null)
        {
            Type modelType = typeof(TModel);
            string modelName = modelType.Name.ToLower();
            PropertyInfo[] properties = modelType.GetProperties();

            if (includedColumns is null)
            {
                List<string> skipList = null;
                if (ReportsConfig.CONFIG.TryGetValue(modelName, out ReportConfig? config))
                {
                    skipList = config.SkipList;
                }

                _inculdedColumns = typeof(TModel).GetProperties().Where(x => !skipList.Contains(x.Name)).Select(x => x.Name)
                    .ToList();
            }
            else
            {
                _inculdedColumns = includedColumns;

            }
            propNameMap = _inculdedColumns
                .Select(columnName => properties.FirstOrDefault(prop => string.Equals(prop.Name, columnName, StringComparison.OrdinalIgnoreCase)))
                .Where(prop => prop != null)
                .ToDictionary(
                    prop => prop.Name,
                    prop =>
                    {
                        string displayName = prop.Name;
                        if (ReportsConfig.CONFIG.TryGetValue(modelName, out ReportConfig? config) && config.DisplayNames.TryGetValue(prop.Name, out GridColumnConfiguration? displayNameConfig))
                        {
                            displayName = displayNameConfig.DisplayName;
                        }
                        return (displayName, prop);
                    }
                );
            ConfigureCsv();
        }



        private Expression<Func<TModel, object>> GenerateExpression(PropertyInfo prop)
        {
            ParameterExpression arg = Expression.Parameter(typeof(TModel), "x");
            MemberExpression property = Expression.Property(arg, prop.Name);
            UnaryExpression conv = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<TModel, object>>(conv, arg);
        }

        private void ConfigureCsv()
        {
            foreach ((string propertyName, (string displayName, PropertyInfo propInfo)) in propNameMap)
            {
                Expression<Func<TModel, object>> exp = GenerateExpression(propInfo);
                MemberMap memberMap = Map(exp).Name(displayName);

                if (propertyName.ToLower().Contains("amount"))
                {
                    _ = memberMap.TypeConverter<CurrencyTypeConverter>();
                }
            }
        }
    }
}

using ART_PACKAGE.Extentions.IServiceCollectionExtentions;
using ART_PACKAGE.Extentions.StringExtentions;
using ART_PACKAGE.Helpers.ReportsConfigurations;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Data.Services.Grid;
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
        private readonly ReportConfigResolver _reportsConfigResolver;

        public GenericCsvClassMapper()
        {

            string name = typeof(TModel).Name.ToLower();

            PropertyInfo[] props = typeof(TModel).GetProperties();
            List<string> skip = ReportsConfigm.CONFIG.ContainsKey(name) ? ReportsConfigm.CONFIG[name]?.SkipList : null;
            Dictionary<string, GridColumnConfiguration> displaynames = ReportsConfigm.CONFIG.ContainsKey(name) ? ReportsConfigm.CONFIG[name]?.DisplayNames : null;

            if (skip is null)
            {
                props.ToList().ForEach(x =>
                {


                    Expression<Func<TModel, object>> exp = GenerateExpression(x);
                    string displayName = displaynames is not null && displaynames.Keys.Contains(x.Name) ? displaynames[x.Name]?.DisplayName : x.Name;
                    MemberMap memberMap = Map(exp).Name(displayName);

                    if (x.Name.ToLower().Contains("hour"))
                    {
                        _ = memberMap.TypeConverter<CurrencyTypeConverter>();
                    }



                });
            }
            else
            {
                foreach (PropertyInfo prop in props)
                {
                    Expression<Func<TModel, object>> exp = GenerateExpression(prop);
                    MemberMap memeberMap = Map(exp);
                    if (!skip.Contains(prop.Name))
                    {
                        string displayName = displaynames is not null && displaynames.Keys.Contains(prop.Name) ? displaynames[prop.Name]?.DisplayName : prop.Name;
                        _ = memeberMap.Name(displayName);
                    }
                    else
                    {
                        _ = memeberMap.Ignore();
                    }

                    if (prop.Name.ToLower().Contains("hour"))
                    {
                        _ = memeberMap.TypeConverter<CurrencyTypeConverter>();
                    }
                }
            }

        }

        public GenericCsvClassMapper(ReportConfigService reportsConfigResolver, List<string>? includedColumns = null)
        {
            ReportConfig? reportConfig = ReportConfigService.GetConfigs<TModel>();

            Type modelType = typeof(TModel);

            string modelName = modelType.Name.ToLower();
            PropertyInfo[] properties = modelType.GetProperties();

            if (includedColumns is null)
            {
                /*List<string> skipList = null;
                if (ReportsConfigm.CONFIG.TryGetValue(modelName, out ReportConfig? config))
                {
                    skipList = config.SkipList;
                }*/

                _inculdedColumns = typeof(TModel).GetProperties().Where(x => !reportConfig.SkipList.Contains(x.Name)).Select(x => x.Name)
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
                        /*if (ReportsConfigm.CONFIG.TryGetValue(modelName, out ReportConfig? config) && config.DisplayNames.TryGetValue(prop.Name, out GridColumnConfiguration? displayNameConfig))
                        {
                            displayName = displayNameConfig.DisplayName;
                        }*/
                        if (reportConfig is not null && reportConfig.DisplayNames is not null && reportConfig.DisplayNames.ContainsKey(prop.Name) && reportConfig.DisplayNames.TryGetValue(prop.Name, out GridColumnConfiguration? displayNameConfig))
                        {
                            displayName = displayNameConfig.DisplayName;

                        }
                        return (displayName, prop);
                    }
                );
            ConfigureCsv();
        }


        public GenericCsvClassMapper(List<string>? includedColumns = null)
        {
            Type modelType = typeof(TModel);
            string modelName = modelType.Name.ToLower();
            PropertyInfo[] properties = modelType.GetProperties();

            if (includedColumns is null)
            {
                List<string> skipList = null;
                if (ReportsConfigm.CONFIG.TryGetValue(modelName, out ReportConfig? config))
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
                        string displayName = prop.Name.MapToHeaderName();
                        if (ReportsConfigm.CONFIG.TryGetValue(modelName, out ReportConfig? config) && config.DisplayNames.TryGetValue(prop.Name, out GridColumnConfiguration? displayNameConfig))
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
    /*public class GenericCsvClassMapper<TModel, TController> : ClassMap<TModel>
    {
        public GenericCsvClassMapper()
        {
            string name = typeof(TModel).Name.ToLower();
            PropertyInfo[] props = typeof(TModel).GetProperties();
            List<string> skip = ReportsConfigm.CONFIG.ContainsKey(name) ? ReportsConfigm.CONFIG[name]?.SkipList : null;
            Dictionary<string, GridColumnConfiguration> displaynames = ReportsConfigm.CONFIG.ContainsKey(name) ? ReportsConfigm.CONFIG[name]?.DisplayNames : null;

            if (skip is null)
            {
                props.ToList().ForEach(x =>
                {


                    Expression<Func<TModel, object>> exp = GenerateExpression(x);
                    string displayName = displaynames is not null && displaynames.Keys.Contains(x.Name) ? displaynames[x.Name]?.DisplayName : x.Name;
                    MemberMap memberMap = Map(exp).Name(displayName);

                    if (x.Name.ToLower().Contains("hour"))
                    {
                        _ = memberMap.TypeConverter<CurrencyTypeConverter>();
                    }



                });
            }
            else
            {
                foreach (PropertyInfo prop in props)
                {
                    Expression<Func<TModel, object>> exp = GenerateExpression(prop);
                    MemberMap memeberMap = Map(exp);
                    if (!skip.Contains(prop.Name))
                    {
                        string displayName = displaynames is not null && displaynames.Keys.Contains(prop.Name) ? displaynames[prop.Name]?.DisplayName : prop.Name;
                        _ = memeberMap.Name(displayName);
                    }
                    else
                    {
                        _ = memeberMap.Ignore();
                    }

                    if (prop.Name.ToLower().Contains("hour"))
                    {
                        _ = memeberMap.TypeConverter<CurrencyTypeConverter>();
                    }
                }
            }

        }
        private Expression<Func<TModel, object>> GenerateExpression(PropertyInfo prop)
        {
            ParameterExpression arg = Expression.Parameter(typeof(TModel), "x");
            MemberExpression property = Expression.Property(arg, prop.Name);
            //return the property as object
            UnaryExpression conv = Expression.Convert(property, typeof(object));
            Expression<Func<TModel, object>> exp = Expression.Lambda<Func<TModel, object>>(conv, new ParameterExpression[] { arg });

            return exp;
        }
    }*/
}

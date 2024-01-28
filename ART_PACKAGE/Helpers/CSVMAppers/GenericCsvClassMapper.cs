using ART_PACKAGE.Helpers.CustomReport;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Linq.Expressions;
using System.Reflection;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class CurrencyTypeConverter : DefaultTypeConverter
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
    public class GenericCsvClassMapper<TModel, TController> : ClassMap<TModel>
    {
        public GenericCsvClassMapper()
        {
            string name = typeof(TController).Name.ToLower();
            PropertyInfo[] props = typeof(TModel).GetProperties();
            List<string> skip = ReportsConfig.CONFIG.ContainsKey(name) ? ReportsConfig.CONFIG[name]?.SkipList : null;
            Dictionary<string, DisplayNameAndFormat> displaynames = ReportsConfig.CONFIG.ContainsKey(name) ? ReportsConfig.CONFIG[name]?.DisplayNames : null;
            if (skip is null)
            {
                props.ToList().ForEach(x =>
                {
                    Expression<Func<TModel, object>> exp = GenerateExpression(x);
                    string displayName = displaynames is not null && displaynames.Keys.Contains(x.Name) ? displaynames[x.Name]?.DisplayName : x.Name;
                    MemberMap memberMap = Map(exp).Name(displayName);
                    
                    if (x.Name.ToLower().Contains("amount"))
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

                    if (prop.Name.ToLower().Contains("amount"))
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
    }
}

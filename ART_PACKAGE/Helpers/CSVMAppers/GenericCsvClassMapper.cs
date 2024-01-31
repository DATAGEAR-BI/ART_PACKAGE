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
    internal class GenericCsvClassMapper<TModel> : BaseClassMap<TModel>
    {


        public GenericCsvClassMapper(List<string> includedColumns) : base(includedColumns)
        {

        }

        private Expression<Func<TModel, object>> GenerateExpression(PropertyInfo prop)
        {
            ParameterExpression arg = Expression.Parameter(typeof(TModel), "x");
            MemberExpression property = Expression.Property(arg, prop.Name);
            UnaryExpression conv = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<TModel, object>>(conv, arg);
        }

        public override void ConfigureCsv()
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

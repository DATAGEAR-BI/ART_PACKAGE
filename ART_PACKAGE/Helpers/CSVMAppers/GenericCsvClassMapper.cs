using CsvHelper.Configuration;
using System.Linq.Expressions;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using System.Reflection;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class GenericCsvClassMapper<T, T1> : ClassMap<T>
    {
        public GenericCsvClassMapper()
        {
            string name = typeof(T1).Name.ToLower();
            PropertyInfo[] props = typeof(T).GetProperties();
            List<string> skip = ReportsConfig.CONFIG.ContainsKey(name) ? ReportsConfig.CONFIG[name]?.SkipList : null;
            Dictionary<string, DisplayNameAndFormat> displaynames = ReportsConfig.CONFIG.ContainsKey(name) ? ReportsConfig.CONFIG[name]?.DisplayNames : null;

            if (skip is null)
            {
                props.ToList().ForEach(x =>
                {


                    Expression<Func<T, object>> exp = GenerateExpression(x);
                    string displayName = displaynames is not null && displaynames.Keys.Contains(x.Name) ? displaynames[x.Name]?.DisplayName : x.Name;
                    _ = Map(exp).Name(displayName);



                });
            }
            else
            {
                foreach (PropertyInfo prop in props)
                {
                    Expression<Func<T, object>> exp = GenerateExpression(prop);
                    if (!skip.Contains(prop.Name))
                    {
                        string displayName = displaynames is not null && displaynames.Keys.Contains(prop.Name) ? displaynames[prop.Name]?.DisplayName : prop.Name;
                        _ = Map(exp).Name(displayName);
                    }
                    else
                    {
                        _ = Map(exp).Ignore();
                    }
                }
            }

        }
        private Expression<Func<T, object>> GenerateExpression(PropertyInfo prop)
        {
            ParameterExpression arg = Expression.Parameter(typeof(T), "x");
            MemberExpression property = Expression.Property(arg, prop.Name);
            //return the property as object
            UnaryExpression conv = Expression.Convert(property, typeof(object));
            Expression<Func<T, object>> exp = Expression.Lambda<Func<T, object>>(conv, new ParameterExpression[] { arg });

            return exp;
        }
    }
}

using CsvHelper.Configuration;
using System.Linq.Expressions;
using System.Reflection;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class GenericCsvClassMapper<TModel, TController> : ClassMap<TModel>
    {
        public GenericCsvClassMapper()
        {
            string name = typeof(TModel).Name.ToLower();
            PropertyInfo[] props = typeof(TModel).GetProperties();
            List<string> skip = ReportsConfig.CONFIG.ContainsKey(name) ? ReportsConfig.CONFIG[name]?.SkipList : null;
            Dictionary<string, GridColumnConfiguration> displaynames = ReportsConfig.CONFIG.ContainsKey(name) ? ReportsConfig.CONFIG[name]?.DisplayNames : null;

            if (skip is null)
            {
                props.ToList().ForEach(x =>
                {


                    Expression<Func<TModel, object>> exp = GenerateExpression(x);
                    string displayName = displaynames is not null && displaynames.Keys.Contains(x.Name) ? displaynames[x.Name]?.DisplayName : x.Name;
                    _ = Map(exp).Name(displayName);



                });
            }
            else
            {
                foreach (PropertyInfo prop in props)
                {
                    Expression<Func<TModel, object>> exp = GenerateExpression(prop);
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

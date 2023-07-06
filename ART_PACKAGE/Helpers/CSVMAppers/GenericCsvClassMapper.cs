using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using System.Linq;
using System.Reflection;
using ART_PACKAGE.Helpers.CSVMAppers;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class GenericCsvClassMapper<T, T1> : ClassMap<T>
    {
        public GenericCsvClassMapper()
        {
            var name = typeof(T1).Name.ToLower();
            var props = typeof(T).GetProperties();
            List<string> skip = ReportsConfig.CONFIG.ContainsKey(name) ? ReportsConfig.CONFIG[name]?.SkipList : null;
            Dictionary<string, DisplayNameAndFormat> displaynames = ReportsConfig.CONFIG.ContainsKey(name) ? ReportsConfig.CONFIG[name]?.DisplayNames : null;

            if (skip is null)
            {
                props.ToList().ForEach(x =>
                {


                    var exp = GenerateExpression(x);
                    string displayName = displaynames is not null && displaynames.Keys.Contains(x.Name) ? displaynames[x.Name]?.DisplayName : x.Name;
                    Map(exp).Name(displayName);



                });
            }
            else
            {
                foreach (var prop in props)
                {
                    var exp = GenerateExpression(prop);
                    if (!skip.Contains(prop.Name))
                    {
                        string displayName = displaynames is not null && displaynames.Keys.Contains(prop.Name) ? displaynames[prop.Name]?.DisplayName : prop.Name;
                        Map(exp).Name(displayName);
                    }
                    else
                    {
                        Map(exp).Ignore();
                    }
                }
            }

        }
        private Expression<Func<T, object>> GenerateExpression(PropertyInfo prop)
        {
            var arg = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(arg, prop.Name);
            //return the property as object
            var conv = Expression.Convert(property, typeof(object));
            var exp = Expression.Lambda<Func<T, object>>(conv, new ParameterExpression[] { arg });

            return exp;
        }
    }
}

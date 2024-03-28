using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Data.Services.Grid
{
    public static class GridHelprs
    {
        public static List<GridColumn> GetColumns<T>(Dictionary<string, List<SelectItem>> columnsToDropDownd = null, Dictionary<string, GridColumnConfiguration> DisplayNamesAndFormat = null, List<string> propertiesToSkip = null)
        {
            IEnumerable<PropertyInfo> props = propertiesToSkip is null ? typeof(T).GetProperties() : typeof(T).GetProperties().Where(x => !propertiesToSkip.Contains(x.Name));

            List<GridColumn> columns = props.Select(x =>
            {
                string Type = "";
                Type? nullableType = Nullable.GetUnderlyingType(x.PropertyType);
                if (nullableType != null)
                {
                    if (nullableType.Name == nameof(String))
                    {
                        Type = "string";
                    }
                    else if (nullableType.Name == nameof(DateTime))
                    {
                        Type = "date";
                    }
                    else if (nullableType.Name == nameof(Boolean))
                    {
                        Type = "boolean";
                    }
                    else if (nullableType.IsNumericType())
                    {
                        Type = "number";
                    }
                }
                else
                {
                    if (x.PropertyType.Name == nameof(String))
                    {
                        Type = "string";
                    }
                    else if (x.PropertyType.Name == nameof(DateTime))
                    {
                        Type = "date";
                    }
                    else if (x.PropertyType.Name == nameof(Boolean))
                    {
                        Type = "boolean";
                    }
                    else if (x.PropertyType.IsNumericType())
                    {
                        Type = "number";
                    }
                }
                string name = x.Name;
                bool propDisplayExists = DisplayNamesAndFormat is not null && DisplayNamesAndFormat.ContainsKey(name);
                List<Type> collectionTypes = new() { typeof(ICollection<>), typeof(IEnumerable<>), typeof(List<>) };
                bool isCollection = x.PropertyType.IsGenericType && collectionTypes.Contains(x.PropertyType.GetGenericTypeDefinition());
                bool isDropDown = columnsToDropDownd is not null && columnsToDropDownd.Keys.Contains(x.Name.ToLower());
                List<SelectItem>? dropdownvalues = isDropDown ? columnsToDropDownd[name.ToLower()] : null;
                bool isnullabe = nullableType != null;
                string? agg = propDisplayExists && DisplayNamesAndFormat[name].AggType != GridAggregateType.none ?
                DisplayNamesAndFormat[name].AggType.ToString() : null;
                string? aggText = propDisplayExists && !string.IsNullOrEmpty(DisplayNamesAndFormat[name].AggText) ? DisplayNamesAndFormat[name].AggText : null;
                return new GridColumn
                {
                    name = name,
                    isDropDown = isDropDown,
                    menu = dropdownvalues,
                    displayName = DisplayNamesAndFormat is not null ? DisplayNamesAndFormat.Keys.Contains(name) ? DisplayNamesAndFormat[name].DisplayName : name : null,
                    format = DisplayNamesAndFormat is not null ? DisplayNamesAndFormat.Keys.Contains(name) ? DisplayNamesAndFormat[name].Format : null : null,
                    isCollection = isCollection,
                    CollectionPropertyName = isCollection ? x.PropertyType.GetGenericArguments().First().GetProperties()[0].Name : null,
                    isNullable = isnullabe,
                    type = Type,
                    template = propDisplayExists ? DisplayNamesAndFormat[name].Template : null,
                    AggType = agg,
                    AggTitle = aggText,
                };

            }).ToList();


            return columns;
        }
        private static bool IsNumericType(this Type o)
        {
            return Type.GetTypeCode(o) switch
            {
                TypeCode.Byte or TypeCode.SByte or TypeCode.UInt16 or TypeCode.UInt32 or TypeCode.UInt64 or TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64 or TypeCode.Decimal or TypeCode.Double or TypeCode.Single => true,
                _ => false,
            };
        }
    }
}

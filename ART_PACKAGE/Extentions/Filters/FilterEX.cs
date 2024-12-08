using ART_PACKAGE.Extentions.StringExtentions;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Services.Grid;
using Google.Protobuf.WellKnownTypes;
using System.Reflection;
using System.Text.Json;

namespace ART_PACKAGE.Extentions.Filters
{
    public static  class FilterEX
    {
        private static readonly Dictionary<string, string> readableOperators = new()
        {
            {"eq" , "Is Equal To" },
            {"neq" , "Is Not Equal To" },
            {"gt" , "Is Greater Than" },
            {"gte" , "Is Greater Than Or Equal" },
            {"lt" , "Is Less Than" },
            {"lte" , "Is Less Than Or Equal" },
            {"isnull" , "Is Null" },
            {"isnotnull" , "Is Not Null" },
            {"isempty" , "Is Empty" },
            {"isnotempty" , "Is Not Empty" },
            {"startswith" , "Starts With" },
            {"doesnotstartwith" , "Doesn't Start With" },
            {"contains" , "Contains" },
            {"doesnotcontain" , "Doesn't Contain" },
            {"endswith" , "Ends With" },
            {"doesnotendwith" , "Doesn't End With" },
            {"isnullorempty", "Has No Value" },
            {"isnotnullorempty","Has Value" }

        };
        public static List<List<string>> ToList(this Filter filter, Dictionary<string, GridColumnConfiguration>? displayNames = null)
        {

            var list = new List<List<string>>();
            if (filter == null)
                return new();
            if (filter.filters == null || !filter.filters.Any())
            {
                var fileldType = filter.value.GetType();
                MethodInfo? method = typeof(FilterExtensions)
                    ?.GetMethod(nameof(FilterExtensions.ToObject))
                    ?.MakeGenericMethod(fileldType);

                
                var vlue = method?.Invoke(null, new object[] { (JsonElement)filter.value });
                var stringValue = Convert.ChangeType(vlue, fileldType).ToString();
                try
                {
                    
                    if (DateTime.TryParse(stringValue, out _))
                    {
                        var Date= DateTime.Parse(stringValue).ToLocalTime();
                        stringValue = Date.ToString();
                    }

                    // Check if it's a Number
                    if (double.TryParse(stringValue, out _))
                    {
                         
                    }
                    
                    
                }
                catch (Exception)
                {}
                    
                var field = displayNames is not null ? displayNames.ContainsKey(filter.field) ? displayNames[filter.field].DisplayName : filter.field : filter.field.MapToHeaderName();

                list.Add(new() { field, readableOperators[filter.@operator], stringValue });
                return list;
            }




            foreach (var fltr in filter.filters)
            {
                list.AddRange(ToList(fltr, displayNames));

            }
            return list;


        }
    }
}

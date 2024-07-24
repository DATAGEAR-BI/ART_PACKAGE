using ART_PACKAGE.Helpers.CSVMAppers;
using CsvHelper;
using Data.Services.Grid;
using System.Reflection;
using System.Text;
using System.Text.Json;
using KendoFilterExtention = ART_PACKAGE.Helpers.CustomReport;

namespace ART_PACKAGE.Extentions.CSV
{
    public static class SW
    {
        private static readonly Dictionary<string, string> StringOp = new()
        {
            { "eq"              , "{1} = '{0}'" },
            { "neq"             , "{1} <> '{0}'" },
            { "isnull"          , "{1} IS NULL" },
            { "isnotnull"       , "{1} IS NOT NULL" },
            { "isempty"         , $@"{{1}} = ''" },
            { "isnotempty"      , $@"{{1}} <> ''" },
            { "startswith"      , "{1} LIKE '{0}%'" },
            { "doesnotstartwith", "{1} NOT LIKE '{0}%'" },
            { "contains"        , "{1} LIKE '%{0}%'" },
            { "doesnotcontain"  , "{1} NOT LIKE '%{0}%'" },
            { "endswith"        , "{1} LIKE '%{0}'" },
            { "doesnotendwith"  , "{1} NOT LIKE '%{0}'" },
            { "isnullorempty"  , $@"{{1}} = '' or {{1}} IS NULL" },
            { "isnotnullorempty"  , $@"{{1}} != '' and {{1}} IS NOT NULL" },
        };
        private static readonly Dictionary<string, string> StringOpForC = new()
        {
            { "eq"              , "{0}==\"{1}\"" },
            { "neq"             , "{0}!=\"{1}\"" },
            { "isnull"          , "{0}== null" },
            { "isnotnull"       , "{0}!= null" },
            { "isempty"         , "{0}==\"\"" },
            { "isnotempty"      , "{0}!=\"\"" },
            { "startswith"      , "{0}.StartsWith(\"{1}\")" },
            { "doesnotstartwith", "!{0}.StartsWith(\"{1}\")" },
            { "contains"        , "{0}.Contains(\"{1}\")" },
            { "doesnotcontain"  , "!{0}.Contains(\"{1}\")" },
            { "endswith"        , "{0}.EndsWith(\"{1}\")" },
            { "doesnotendwith"  , "!{0}.EndsWith(\"{1}\")" },
            { "isnullorempty"  , "{0}== null || {0}==\"\"" },
            { "isnotnullorempty"  ,"{0}!= null && {0}!=\"\"" },
        };
        private static readonly Dictionary<string, string> NumberOp = new()
        {
            { "eq", "{1} = {0}" },
            { "neq", "{1} <> {0}" },
            { "isnull", "{1} IS NULL" },
            { "isnotnull", "{1} IS NOT NULL" },
            {"gte"  ,"{1} >= {0}"},
            {"gt"   ,"{1} > {0}"},
            {"lte"  ,"{1} <= {0}"},
            { "lt"  , "{1} < {0}" },
        };
        private static readonly Dictionary<string, string> NumberOpForC = new()
        {
            { "eq", "{0} == {1}" },
            { "neq", "{0} != {1}" },
            { "isnull", "{0} == null" },
            { "isnotnull", "{0} != null" },
            {"gte"  ,"{0} >= {1}"},
            {"gt"   ,"{0} > {1}"},
            {"lte"  ,"{0} <= {1}"},
            { "lt"  , "{0} < {1}" },
        };
        private static readonly Dictionary<string, string> DateOpForC = new()
        {
            { "eq", "{0} == \"{1}\"" },
            { "neq", "{0} != \"{1}\"" },
            { "isnull", "{0} == null" },
            { "isnotnull", "{0} != null" },
            {"gte"  , "{0} >= \"{1}\"" },
            {"gt"   , "{0} > \"{1}\"" },
            {"lte"  , "{0} <= \"{1}\"" },
            { "lt"  , "{0} < \"{1}\"" },
        };
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

        public static void WriteFilters<TModel>(this CsvWriter cw, Filter filters)
        {
            foreach (var filter in filters.GetFilterTextForCsv<TModel>())
            {
                foreach (var filterGrediant in filter)
                {
                    cw.WriteField(filterGrediant.ToString());
                    //cw.WriteComment(filterGrediant.ToString());
                }
                cw.NextRecord();


            }


        }
        private static string GetFiltersString<T>(this Filter Filters)
        {
            if (Filters == null || Filters.filters.Count == 0)
            {
                return string.Empty;
            }

            string? logic = Filters.logic;

            if (logic is null)
            {
                return string.Empty;
            }
            StringBuilder _sb = new();
            foreach (object? item in Filters.filters)
            {
                JsonElement t = (JsonElement)item;
                KendoFilterExtention.FilterData i = t.ToObject<KendoFilterExtention.FilterData>();
                if (i.field == null)
                {
                    Filter filter = t.ToObject<Filter>();
                    _ = _sb.Append(GetFiltersString<T>(filter));

                }
                else
                {
                    Type propType = typeof(T).GetProperty(i.field).PropertyType;
                    string query = "";
                    Type? underlyingType = Nullable.GetUnderlyingType(propType);
                    if (underlyingType != null)
                    {

                        query = $"para.{i.field}.HasValue && ";
                        if (underlyingType.Name == nameof(String))
                        {




                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                query = string.Format(StringOpForC[i.@operator], $"para.{i.field}");

                            }
                            else
                            {
                                string value = ((JsonElement)i.value).ToObject<string>();
                                query += string.Format(StringOpForC[i.@operator], $"para.{i.field}.Value", value);

                            }
                        }
                        else if (underlyingType.Name == nameof(DateTime))
                        {

                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                query = string.Format(DateOpForC[i.@operator], $"para.{i.field}");

                            }
                            else
                            {
                                DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                                value = value.ToLocalTime();
                                query += string.Format(DateOpForC[i.@operator], $"para.{i.field}.Value.Date", value.Date.ToString());

                            }
                        }
                        else if (underlyingType.IsEnum)
                        {

                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                query = string.Format(StringOpForC[i.@operator], $"para.{i.field}");

                            }
                            else
                            {
                                MethodInfo? method = typeof(SW).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                                MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);
                                object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), underlyingType);

                                query += string.Format(StringOpForC[i.@operator], $"para.{i.field}.Value", value.ToString());

                            }
                        }
                        else
                        {
                            MethodInfo? method = typeof(SW).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);


                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                query = string.Format(NumberOpForC[i.@operator], $"para.{i.field}");


                            }
                            else
                            {
                                object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), underlyingType);
                                query += string.Format(NumberOpForC[i.@operator], $"para.{i.field}.Value", value);

                            }
                        }
                        _ = _sb.Append(query);
                    }
                    else
                    {
                        if (propType.Name == nameof(String))
                        {
                            string value = ((JsonElement)i.value).ToObject<string>();
                            query += string.Format(StringOpForC[i.@operator], $"para.{i.field}", value);
                        }
                        else if (propType.Name == nameof(DateTime))
                        {
                            DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                            value = value.ToLocalTime();
                            query += string.Format(DateOpForC[i.@operator], $"para.{i.field}.Date", value.Date.ToString());
                        }
                        else if (propType.IsEnum)
                        {
                            MethodInfo? method = typeof(SW).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);
                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), propType);

                            query += string.Format(StringOpForC[i.@operator], $"para.{i.field}", value.ToString());
                        }
                        else
                        {
                            MethodInfo? method = typeof(SW).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);

                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), propType);
                            query += string.Format(NumberOpForC[i.@operator], $"para.{i.field}", value);
                        }
                        _ = _sb.Append(query);
                    }



                }
                if (Filters.filters.IndexOf((Filter)item) != Filters.filters.Count - 1)
                {
                    string l = logic == "and" ? "&&" : "||";
                    _ = _sb.Append($" {l} ");
                }

            }

            return "(" + _sb.ToString() + ")";
        }
        public static T ToObject<T>(this string json)
        {

            //string json = element.GetRawText();
            return JsonSerializer.Deserialize<T>(json);
        }
        public static List<List<object>> GetFilterTextForCsv<TModel>(this Filter Filters)
        {
            Dictionary<string, GridColumnConfiguration> displayNames = new();
            displayNames = ReportConfigService.GetConfigs<TModel>() is not null ? ReportConfigService.GetConfigs<TModel>().DisplayNames : null;
            List<List<object>> returnList = new();
            if (Filters is null)
            {
                return returnList;
            }

            string? logic = Filters.logic;

            if (logic is null)
            {
                return returnList;
            }


            foreach (object? item in Filters.filters)
            {
                string t = JsonSerializer.Serialize(item);
                ///JsonElement t = JsonSerializer.Serialize(item);
                KendoFilterExtention.FilterData i = t.ToObject<KendoFilterExtention.FilterData>();
                if (i.field == null)
                {
                    Filter filter = t.ToObject<Filter>();
                    returnList.AddRange(GetFilterTextForCsv<TModel>(filter));

                }
                else
                {
                    Type propType = typeof(TModel).GetProperty(i.field).PropertyType;
                    Type? underlyingType = Nullable.GetUnderlyingType(propType);
                    if (underlyingType != null)
                    {
                        if ( underlyingType.Name == nameof(DateTime))
                        {
                            DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                            i.value = value.ToLocalTime();
                        }
                    }
                    else
                    {
                        if (propType.Name == nameof(DateTime))
                        {
                            DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                            i.value = value.ToLocalTime();
                        }
                    }
                    
                    List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field, readableOperators[i.@operator], i.value };
                    returnList.Add(v);
                }


            }


            return returnList;




        }

    }


}

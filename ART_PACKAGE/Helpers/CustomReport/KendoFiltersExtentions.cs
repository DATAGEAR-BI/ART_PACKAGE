using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace ART_PACKAGE.Helpers.CustomReport
{
    public static partial class KendoFiltersExtentions
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
        };

        private static readonly Dictionary<string, Dictionary<string, string>> DateOp = new()
        {
            {

                "sqlServer"
            ,
            new Dictionary<string, string> {
            { "eq", "Convert(date , {1} , 105) = Convert(date,'{0}',105)" },
            { "neq", "Convert(date , {1} , 105) <> Convert(date,'{0}',105)" },
            { "isnull", "{1} IS NULL" },
            { "isnotnull", "{1} IS NOT NULL" },
            {"gte","Convert(date , {1} , 105) >= Convert(date,'{0}',105)"},
            {"gt","Convert(date , {1} , 105) > Convert(date,'{0}',105)"},
            {"lte","Convert(date , {1} , 105) <= Convert(date,'{0}',105)"},
            { "lt", "Convert(date , {1} , 105) < Convert(date,'{0}',105)" },
                }
            }

            ,

            {

                "oracle"
            ,
                new Dictionary<string, string> {
            { "eq", "TRUNC({1}) =  to_date('{0}', 'dd-MM-yyyy')" },
            { "neq", "TRUNC({1}) <> to_date('{0}', 'dd-MM-yyyy')" },
            { "isnull", "{1} IS NULL" },
            { "isnotnull", "{1} IS NOT NULL" },
            {"gte","TRUNC({1}) >= to_date('{0}', 'dd-MM-yyyy')"},
            {"gt","TRUNC({1}) > to_date('{0}', 'dd-MM-yyyy')"},
            {"lte","TRUNC({1}) <= to_date('{0}', 'dd-MM-yyyy')"},
            { "lt", "TRUNC({1}) < to_date('{0}', 'dd-MM-yyyy')" },
            }
            }
        };

        public static T ToObject<T>(this JsonElement element)
        {

            string json = element.GetRawText();
            return JsonSerializer.Deserialize<T>(json);
        }
        public static string GetFiltersString(this Filter Filters, string dbtype, IEnumerable<ColumnsDto> columns)
        {
            if (Filters is null)
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
                FilterData i = t.ToObject<FilterData>();
                if (i.field == null)
                {
                    Filter filter = t.ToObject<Filter>();
                    _ = _sb.Append(GetFiltersString(filter, dbtype, columns));

                }
                else
                {
                    string v = "";


                    ColumnsDto? column = columns.FirstOrDefault(x => x.name == i.field);

                    if (column.type.ToLower() == "number".ToLower())
                    {
                        v = i.value is not null
                            ? string.Format(NumberOp[i.@operator], ((JsonElement)i.value).ToObject<int>().ToString(), i.field)
                            : NumberOp[i.@operator];
                    }
                    else if (column.type.ToLower() == "date".ToLower())
                    {
                        DateTime dt = ((JsonElement)i.value).ToObject<DateTime>().ToLocalTime();
                        v = string.Format(DateOp[dbtype][i.@operator], dt.Date.ToString("dd-MM-yyyy"), i.field);
                    }
                    else if (column.type.ToLower() == "string".ToLower())
                    {
                        string value = ((JsonElement)i.value).ToObject<string>();
                        _ = DateTime.TryParse(value, out DateTime dt);
                        v = string.Format(StringOp[i.@operator], value, i.field);

                    }
                    _ = _sb.Append($"{v}");

                }
                if (Filters.filters.IndexOf(item) != Filters.filters.Count - 1)
                {
                    _ = _sb.Append($" {logic} ");
                }
            }

            return "(" + _sb.ToString() + ")";
        }
        //public static string GetFiltersString(this Filter Filters, string dbtype, IEnumerable<ColumnsDto> columns)
        //{
        //    _ = _sb.Clear();
        //    Filters.constructQuery(dbtype, columns);
        //    return _sb.ToString();
        //}


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
                FilterData i = t.ToObject<FilterData>();
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
                                MethodInfo? method = typeof(KendoFiltersExtentions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                                MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);
                                object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), underlyingType);

                                query += string.Format(StringOpForC[i.@operator], $"para.{i.field}.Value", value.ToString());

                            }
                        }
                        else
                        {
                            MethodInfo? method = typeof(KendoFiltersExtentions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
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
                            MethodInfo? method = typeof(KendoFiltersExtentions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);
                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), propType);

                            query += string.Format(StringOpForC[i.@operator], $"para.{i.field}", value.ToString());
                        }
                        else
                        {
                            MethodInfo? method = typeof(KendoFiltersExtentions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);

                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), propType);
                            query += string.Format(NumberOpForC[i.@operator], $"para.{i.field}", value);
                        }
                        _ = _sb.Append(query);
                    }



                }
                if (Filters.filters.IndexOf(item) != Filters.filters.Count - 1)
                {
                    string l = logic == "and" ? "&&" : "||";
                    _ = _sb.Append($" {l} ");
                }

            }

            return "(" + _sb.ToString() + ")";
        }



        private static BinaryExpression GetFilterLamdbaEx<T>(this Filter Filters, ParameterExpression parameterExpression)
        {

            if (Filters == null || Filters.filters.Count == 0)
            {
                return null;
            }

            string? logic = Filters.logic;

            if (logic is null)
            {
                return null;
            }

            BinaryExpression Ex = null;

            MethodInfo? method = typeof(KendoFiltersExtentions).GetMethod(nameof(GetConstEx), BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo? mapMethod = typeof(KendoFiltersExtentions).GetMethod(nameof(MapOp), BindingFlags.Static | BindingFlags.NonPublic);

            FilterData firstFilter = ((JsonElement)Filters.filters[0]).ToObject<FilterData>();
            if (firstFilter.field == null)
            {
                Filter filter = ((JsonElement)Filters.filters[0]).ToObject<Filter>();

                Ex = filter.GetFilterLamdbaEx<T>(parameterExpression);


            }
            else
            {

                Type fieldType = typeof(T).GetProperty(firstFilter.field).PropertyType;

                MethodInfo Gmethod = method.MakeGenericMethod(fieldType);
                MethodInfo GmapMethod = mapMethod.MakeGenericMethod(fieldType);
                ConstantExpression? constEx = (ConstantExpression)Gmethod.Invoke(null, new object[] { firstFilter });
                MemberExpression propEx = firstFilter.field.GetPropertyEx(parameterExpression);

                Ex = (BinaryExpression)GmapMethod.Invoke(null, new object[] { propEx, constEx, firstFilter.@operator });
            }

            foreach (object? item in Filters.filters)
            {
                if (item.GetHashCode() == Filters.filters[0].GetHashCode())
                {
                    continue;
                }

                JsonElement t = (JsonElement)item;
                FilterData i = t.ToObject<FilterData>();
                if (i.field == null)
                {
                    Filter filter = t.ToObject<Filter>();

                    Ex = logic.ToLower() == "and" ? Expression.And(Ex, filter.GetFilterLamdbaEx<T>(parameterExpression))
                         : Expression.Or(Ex, filter.GetFilterLamdbaEx<T>(parameterExpression));

                }
                else
                {
                    Type iType = typeof(T).GetProperty(i.field).PropertyType;
                    MethodInfo? imethod = typeof(KendoFiltersExtentions).GetMethod(nameof(GetConstEx), BindingFlags.Static | BindingFlags.NonPublic);
                    MethodInfo IGmethod = method.MakeGenericMethod(iType);
                    MethodInfo GmapMethod = mapMethod.MakeGenericMethod(iType);
                    ConstantExpression? itemConst = (ConstantExpression)IGmethod.Invoke(null, new object[] { i });
                    MemberExpression prop = i.field.GetPropertyEx(parameterExpression);

                    BinaryExpression? itemEx = (BinaryExpression)GmapMethod.Invoke(null, new object[] { prop, itemConst, i.@operator });

                    Ex = logic.ToLower() == "and" ? Expression.And(Ex, itemEx)
                        : Expression.Or(Ex, itemEx);

                }
            }
            return Ex;
        }


        public static Func<T, bool> GetFunc<T>(this Filter Filters)
        {
            if (Filters == null || Filters.filters.Count == 0)
            {
                return null;
            }

            Type type = typeof(T);
            ParameterExpression parameterExpression = Expression.Parameter(type, "para");
            BinaryExpression Ex = Filters.GetFilterLamdbaEx<T>(parameterExpression);
            Expression<Func<T, bool>> e = Expression.Lambda<Func<T, bool>>(Ex, parameterExpression);
            return e.Compile();
        }

        private static MemberExpression GetPropertyEx(this string PropertyName, ParameterExpression param)
        {

            return Expression.Property(param, PropertyName);
        }


        private static ConstantExpression GetConstEx<T>(this FilterData fd)
        {


            try
            {
                T? Const = ((JsonElement)fd.value).ToObject<T>();
                if (typeof(T).Name == nameof(DateTime))
                {
                    DateTime c = ((JsonElement)fd.value).ToObject<DateTime>();
                    c = c.ToLocalTime();
                    return Expression.Constant(c, typeof(DateTime));
                }

                return Expression.Constant(Const, typeof(T));
            }
            catch (Exception)
            {
                if (Nullable.GetUnderlyingType(typeof(T)) != null)
                {
                    return Expression.Constant(null, typeof(T));
                }
                else
                {
                    object? defult = Activator.CreateInstance(typeof(T));
                    return Expression.Constant(defult, typeof(T));
                }

            }




        }



        public static List<ColumnsDto> GetColumns<T>(Dictionary<string, List<dynamic>> columnsToDropDownd = null, Dictionary<string, DisplayNameAndFormat> DisplayNamesAndFormat = null, List<string> propertiesToSkip = null)
        {
            IEnumerable<PropertyInfo> props = propertiesToSkip is null ? typeof(T).GetProperties() : typeof(T).GetProperties().Where(x => !propertiesToSkip.Contains(x.Name));

            List<ColumnsDto> columns = props.Select(x =>
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
                List<dynamic>? dropdownvalues = isDropDown ? columnsToDropDownd[name.ToLower()] : null;
                bool isnullabe = nullableType != null;
                string? agg = propDisplayExists && DisplayNamesAndFormat[name].AggType != GridAggregateType.none ?
                DisplayNamesAndFormat[name].AggType.ToString() : null;
                string? aggText = propDisplayExists && !string.IsNullOrEmpty(DisplayNamesAndFormat[name].AggText) ? DisplayNamesAndFormat[name].AggText : null;
                return new ColumnsDto
                {
                    name = name,
                    isDropDown = isDropDown,
                    menu = dropdownvalues,
                    displayName = DisplayNamesAndFormat is not null ? DisplayNamesAndFormat.Keys.Contains(name) ? DisplayNamesAndFormat[name].DisplayName : name : null,
                    format = DisplayNamesAndFormat is not null ? DisplayNamesAndFormat.Keys.Contains(name) ? DisplayNamesAndFormat[name].Format : null : null,
                    isCollection = isCollection,
                    CollectionPropertyName = isCollection ? x.PropertyType.GetGenericArguments().First().GetProperties()[0].Name : null
                                        ,
                    isNullable = isnullabe,
                    type = Type,

                    AggType = agg,
                    AggTitle = aggText,
                };

            }).ToList();


            return columns;
        }
        public static bool IsNumericType(this Type o)
        {
            return Type.GetTypeCode(o) switch
            {
                TypeCode.Byte or TypeCode.SByte or TypeCode.UInt16 or TypeCode.UInt32 or TypeCode.UInt64 or TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64 or TypeCode.Decimal or TypeCode.Double or TypeCode.Single => true,
                _ => false,
            };
        }
        public static KendoDataDesc<T> CallData<T>(this IQueryable<T> data, KendoRequest obj, Dictionary<string, List<dynamic>> columnsToDropDownd = null, Dictionary<string, DisplayNameAndFormat> DisplayNames = null, List<string> propertiesToSkip = null)
        {
            List<ColumnsDto> columns = null;
            if (obj.IsIntialize)
            {
                columns = GetColumns<T>(columnsToDropDownd, DisplayNames, propertiesToSkip);
                return new KendoDataDesc<T>
                {
                    Data = null,
                    Columns = columns,
                    Total = data.Count(),
                };
            }





            string filter = obj.Filter.GetFiltersString<T>();





            if (!string.IsNullOrEmpty(filter))
            {
                data = data.Where("para => " + filter).AsQueryable();
            }

            string? sortString = obj.Sort.GetSortString();
            if (sortString is not null)
            {
                data = data.OrderBy(sortString).AsQueryable();
            }
            else
            {
                string sort = typeof(T).GetProperties().First().Name;
                data = data.OrderBy(sort).AsQueryable();
            }




            int Count = 0;
            if (!obj.IsIntialize)
            {
                Count = data.Count();
            }
            if (obj.Take > 0)
            {
                data = data.Skip(obj.Skip).Take(obj.Take);
            }
            return new KendoDataDesc<T>
            {
                Data = data,
                Columns = columns,
                Total = Count,
            };


        }
        public static async Task<byte[]> ExportToCSV<T>(this IQueryable<T> data, KendoRequest obj = null, bool all = true)
        {
            decimal total = 0;
            if (all)
            {
                KendoDataDesc<T> calldata = data.CallData(obj);
                data = calldata.Data;
                total = calldata.Total;

            }
            else
            {
                total = data.Count();
            }

            CsvConfiguration config = new(CultureInfo.CurrentCulture)
            {
                IgnoreReferences = true,
            };
            int skip = 0;
            List<Task<byte[]>> tasks = new() { };
            byte[] bytes = new byte[] { };
            using MemoryStream stream = new();
            using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
            using (CsvWriter cw = new(sw, config))
            {
                sw.Write("");
                cw.WriteHeader<T>();
                bytes = stream.ToArray();
            }
            while (total > 0)
            {
                List<T> tempData = data.Skip(skip).Take(100000).ToList();
                Task<byte[]> task = Task.Run(() =>
                {
                    using MemoryStream stream = new();
                    using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
                    using (CsvWriter cw = new(sw, config))
                    {
                        sw.Write("");
                        cw.WriteHeader<T>();
                        cw.NextRecord();
                        foreach (T? elm in tempData)
                        {
                            cw.WriteRecord(elm);
                            cw.NextRecord();
                        }
                    }
                    byte[] b = stream.ToArray();
                    return b;
                });
                tasks.Add(task);
                total -= 100000;
                skip += 100000;
            }
            byte[][] results = await Task.WhenAll(tasks);
            tasks.ForEach(x =>
            {
                Console.WriteLine(x.Result.Length);
                bytes = bytes.Concat(x.Result).ToArray();
            }
            );
            return bytes;
        }

        public static async Task<byte[]> ExportToCSV<T, T1>(this IQueryable<T> data, KendoRequest obj = null, bool all = true) where T1 : ClassMap
        {
            decimal total = 0;
            if (all)
            {
                KendoDataDesc<T> calldata = data.CallData(obj);
                data = calldata.Data;
                total = calldata.Total;

            }
            else
            {
                total = data.Count();
            }


            CsvConfiguration config = new(CultureInfo.CurrentCulture)
            {

            };
            int skip = 0;
            List<Task<byte[]>> tasks = new() { };
            byte[] bytes = new byte[] { };
            using MemoryStream stream = new();
            using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
            using (CsvWriter cw = new(sw, config))
            {
                sw.Write("");
                _ = cw.Context.RegisterClassMap<T1>();
                cw.WriteHeader<T>();
                bytes = stream.ToArray();
            }
            while (total > 0)
            {
                string datasql = data.ToQueryString();
                IQueryable<T> tempDData = data.Skip(skip).Take(100000);
                string sql = tempDData.ToQueryString();
                List<T> tempData = tempDData.ToList();
                Task<byte[]> task = Task.Run(() =>
                {
                    using MemoryStream stream = new();
                    using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
                    using (CsvWriter cw = new(sw, config))
                    {
                        sw.Write("");
                        _ = cw.Context.RegisterClassMap<T1>();
                        cw.WriteHeader<T>();
                        cw.NextRecord();
                        foreach (T? elm in tempData)
                        {
                            cw.WriteRecord(elm);
                            cw.NextRecord();
                        }
                    }
                    byte[] b = stream.ToArray();
                    return b;
                });
                tasks.Add(task);
                total -= 100000;
                skip += 100000;
            }
            byte[][] results = await Task.WhenAll(tasks);
            tasks.ForEach(x =>
            {
                bytes = bytes.Concat(x.Result).ToArray();
            }
            );
            return bytes;

        }
        public static async Task<byte[]> ExportToCSV<T>(this IQueryable<T> data, KendoRequest obj)
        {
            KendoDataDesc<T> calldata = data.CallData(obj);
            data = calldata.Data;
            decimal total = calldata.Total;
            CsvConfiguration config = new(CultureInfo.CurrentCulture)
            {
                IgnoreReferences = true,
            };
            int skip = 0;
            List<Task<byte[]>> tasks = new() { };
            byte[] bytes = new byte[] { };
            using MemoryStream stream = new();
            using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
            using (CsvWriter cw = new(sw, config))
            {
                sw.Write("");
                cw.WriteHeader<T>();
                bytes = stream.ToArray();
            }
            while (total > 0)
            {
                List<T> tempData = data.Skip(skip).Take(100000).ToList();
                Task<byte[]> task = Task.Run(() =>
                {
                    using MemoryStream stream = new();
                    using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
                    using (CsvWriter cw = new(sw, config))
                    {
                        sw.Write("");
                        cw.WriteHeader<T>();
                        cw.NextRecord();
                        foreach (T? elm in tempData)
                        {
                            cw.WriteRecord(elm);
                            cw.NextRecord();
                        }
                    }
                    byte[] b = stream.ToArray();
                    return b;
                });
                tasks.Add(task);
                total -= 100000;
                skip += 100000;
            }
            byte[][] results = await Task.WhenAll(tasks);
            tasks.ForEach(x =>
            {
                Console.WriteLine(x.Result.Length);
                bytes = bytes.Concat(x.Result).ToArray();
            }
            );
            return bytes;
        }

        public static List<List<object>> GetFilterTextForCsv(this Filter Filters)
        {
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
                JsonElement t = (JsonElement)item;
                FilterData i = t.ToObject<FilterData>();
                if (i.field == null)
                {
                    Filter filter = t.ToObject<Filter>();
                    returnList.AddRange(GetFilterTextForCsv(filter));

                }
                else
                {
                    List<object> v = new() { i.field, readableOperators[i.@operator], i.value };
                    returnList.Add(v);
                }


            }


            return returnList;




        }
        public static IEnumerable<Task<byte[]>> ExportToCSVE<T, T1>(this IQueryable<T> data, KendoRequest obj = null, bool all = true) where T1 : ClassMap
        {
            List<List<object>> filterCells = GetFilterTextForCsv(obj.Filter);
            decimal total = 0;
            if (all)
            {
                KendoDataDesc<T> calldata = data.CallData(obj);
                data = calldata.Data;
                total = calldata.Total;
            }
            else
            {
                total = data.Count();
            }

            CsvConfiguration config = new(CultureInfo.CurrentCulture)
            {
                Encoding = Encoding.UTF8,
                IgnoreBlankLines = true,
                AllowComments = true,
            };

            int batch = 100000;
            int skip = 0;
            while (total > 0)
            {
                IQueryable<T> tempDData = data.Skip(skip).Take(batch);
                List<T> tempData = tempDData.ToList();
                yield return Task.Run(() =>
                {
                    using MemoryStream stream = new();
                    using (StreamWriter sw = new(stream, new UTF8Encoding(false)))
                    using (CsvWriter cw = new(sw, config))
                    {
                        // Register custom class map
                        _ = cw.Context.RegisterClassMap<T1>();

                        if (filterCells is not null && filterCells.Count != 0)
                        {
                            foreach (List<object> item in filterCells)
                            {
                                cw.WriteComment(string.Join(",", item));
                            }
                            cw.NextRecord();
                        }

                        // Manually configure headers
                        ClassMap<T>? headerMap = cw.Context.Maps.Find<T>();
                        foreach (MemberMap? memberMap in headerMap.MemberMaps)
                        {
                            MemberInfo? property = memberMap.Data.Member;

                            // Add custom type converters for specific properties
                            if (property.Name.ToLower().Contains("amount"))
                            {
                                memberMap.TypeConverter<CurrencyTypeConverter>();
                            }

                            cw.WriteField(property.Name); // Write custom headers if needed
                        }
                        cw.NextRecord();

                        // Write records
                        foreach (T? elm in tempData)
                        {
                            cw.WriteRecord(elm);
                            cw.NextRecord();
                        }
                    }
                    byte[] b = stream.ToArray();
                    return b;
                });

                total -= batch;
                skip += batch;
            }
        }

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


        public static byte[] ExportCustomReportToCSV(List<dynamic> data, List<List<dynamic>> Chartdata = null, List<List<object>> filterCells = null)
        {
            CsvConfiguration config = new(CultureInfo.CurrentCulture)
            {
                Encoding = new UTF8Encoding(false),
                IgnoreBlankLines = true,
                AllowComments = true,
            };

            MemoryStream stream = new();
            using (StreamWriter sw = new(stream, new UTF8Encoding(false)))
            using (CsvWriter cw = new(sw, config))
            {
                foreach (List<object> item in filterCells)
                {
                    cw.WriteComment(string.Join(",", item));
                }
                cw.WriteRecords(data);
                if (Chartdata is not null)
                {
                    cw.WriteComment("Charts Data");
                    foreach (List<dynamic> chart in Chartdata)
                    {
                        cw.WriteRecords(chart);
                    }
                }


            }

            return stream.ToArray();
        }
        public static string GetSortString(this List<SortOptions> opt)
        {
            if (opt is null || opt.Count() == 0)
            {
                return null;
            }

            string sort = string.Join(" , ", opt.Select(x =>
            {
                //string dir = x.dir == "desc" ? " " + x.dir : "";
                return $"{x.field} {x.dir}";
            }));
            return sort;
        }

        private static BinaryExpression MapOp<T>(MemberExpression prop, ConstantExpression constant, string op)
        {
            switch (op)
            {
                case "eq":
                    if ((Nullable.GetUnderlyingType(typeof(T)) != null && Nullable.GetUnderlyingType(typeof(T)).Name == nameof(DateTime)) || (typeof(T).Name == nameof(DateTime)))
                    {
                        DateTime datecosnt;

                        if (Nullable.GetUnderlyingType(typeof(T)) != null)
                        {
                            datecosnt = ((DateTime?)constant.Value).Value.Date;
                            MemberExpression nulableValue = Expression.Property(prop, "Value");
                            MemberExpression nullableEx = Expression.Property(nulableValue, "Date");
                            BinaryExpression nullescapeEx = Expression.NotEqual(prop, Expression.Constant(null));
                            BinaryExpression actualEx = Expression.Equal(nullableEx, Expression.Constant(datecosnt, typeof(DateTime)));
                            return Expression.And(nullescapeEx, actualEx);
                        }
                        else
                        {
                            datecosnt = ((DateTime)constant.Value).Date;
                            MemberExpression DateEx = Expression.Property(prop, "Date");
                            return Expression.Equal(DateEx, Expression.Constant(datecosnt, typeof(DateTime)));
                        }




                    }
                    return Expression.Equal(prop, constant);
                case "neq":
                    if (typeof(T).Name == nameof(DateTime))
                    {
                        string datecosnt = ((DateTime)constant.Value).ToShortDateString();
                        MethodInfo? ToShortDateMethod = typeof(DateTime).GetMethod("ToShortDateString");
                        MethodCallExpression CallToshortDate = Expression.Call(prop, ToShortDateMethod);
                        return Expression.NotEqual(CallToshortDate, Expression.Constant(datecosnt, typeof(string)));

                    }
                    return Expression.NotEqual(prop, constant);
                case "gte":
                    return Expression.GreaterThanOrEqual(prop, constant);
                case "gt":
                    return Expression.GreaterThan(prop, constant);
                case "lt":
                    return Expression.LessThan(prop, constant);
                case "lte":
                    return Expression.LessThanOrEqual(prop, constant);
                case "isnull":
                    return Expression.Equal(prop, constant);
                case "isnotnull":
                    return Expression.NotEqual(prop, constant);
                case "isempty":
                    return Expression.Equal(prop, Expression.Constant(""));
                case "isnotempty":
                    return Expression.NotEqual(prop, Expression.Constant(""));
                case "startswith":
                    MethodInfo? StartsWith = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
                    MethodCallExpression call = Expression.Call(prop, StartsWith, constant);
                    return Expression.Equal(call, Expression.Constant(true));
                case "doesnotstartwith":
                    MethodInfo? StartsWith1 = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
                    MethodCallExpression call1 = Expression.Call(prop, StartsWith1, constant);
                    return Expression.Equal(call1, Expression.Constant(false));
                case "contains":
                    MethodInfo? Contains = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
                    MethodCallExpression callContains = Expression.Call(prop, Contains, constant);
                    return Expression.Equal(callContains, Expression.Constant(true));
                case "doesnotcontain":
                    MethodInfo? DoesNotContain = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
                    MethodCallExpression callDoesNotContain = Expression.Call(prop, DoesNotContain, constant);
                    return Expression.Equal(callDoesNotContain, Expression.Constant(false));
                case "endswith":
                    MethodInfo? EndsWith = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
                    MethodCallExpression callEndsWith = Expression.Call(prop, EndsWith, constant);
                    return Expression.Equal(callEndsWith, Expression.Constant(true));
                case "doesnotendwith":
                    MethodInfo? DoesNotEndsWith = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
                    MethodCallExpression callDoesNotEndsWith = Expression.Call(prop, DoesNotEndsWith, constant);
                    return Expression.Equal(callDoesNotEndsWith, Expression.Constant(false));
                default:
                    return null;



            }
        }
    }
}

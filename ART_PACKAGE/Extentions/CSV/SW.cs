using ART_PACKAGE.Extentions.StringExtentions;
using ART_PACKAGE.Helpers.CSVMAppers;
using CsvHelper;
using Data.Constants.db;
using Data.Services.Grid;
using Data.Services.QueryBuilder;
using System.Reflection;
using System.Text;
using System.Text.Json;
using KendoFilterExtention = ART_PACKAGE.Helpers.CustomReport;

namespace ART_PACKAGE.Extentions.CSV
{
    public static class SW
    {
        private static readonly Dictionary<string, Type> TypesMySql = new()
        {
             // Numeric Types
            { "TINYINT", typeof(sbyte) },        // TINYINT is mapped to sbyte (for 1-byte signed integer)
            { "SMALLINT", typeof(short) },       // SMALLINT is mapped to short (for 2-byte signed integer)
            { "MEDIUMINT", typeof(int) },        // MEDIUMINT is mapped to int (for 3-byte signed integer)
            { "INT", typeof(int) },              // INT is mapped to int (4-byte signed integer)
            { "INTEGER", typeof(int) },          // INTEGER is mapped to int (synonym for INT)
            { "BIGINT", typeof(long) },          // BIGINT is mapped to long (8-byte signed integer)
            { "DECIMAL", typeof(decimal) },      // DECIMAL is mapped to decimal (for high precision numbers)
            { "NUMERIC", typeof(decimal) },      // NUMERIC is mapped to decimal (synonym for DECIMAL)
            { "FLOAT", typeof(float) },          // FLOAT is mapped to float (4-byte single precision floating point)
            { "DOUBLE", typeof(double) },        // DOUBLE is mapped to double (8-byte double precision floating point)
            { "BIT", typeof(bool) },             // BIT is mapped to bool (bit value 0 or 1)

            // Date and Time Types
            { "DATE", typeof(DateTime) },        // DATE is mapped to DateTime
            { "DATETIME", typeof(DateTime) },    // DATETIME is mapped to DateTime
            { "TIMESTAMP", typeof(DateTime) },   // TIMESTAMP is mapped to DateTime
            { "TIME", typeof(TimeSpan) },        // TIME is mapped to TimeSpan
            { "YEAR", typeof(short) },           // YEAR is mapped to short (4-byte year value)

            // String Types
            { "CHAR", typeof(string) },          // CHAR is mapped to string
            { "VARCHAR", typeof(string) },       // VARCHAR is mapped to string
            { "TEXT", typeof(string) },          // TEXT is mapped to string
            { "TINYTEXT", typeof(string) },      // TINYTEXT is mapped to string
            { "MEDIUMTEXT", typeof(string) },    // MEDIUMTEXT is mapped to string
            { "LONGTEXT", typeof(string) },      // LONGTEXT is mapped to string
            { "ENUM", typeof(string) },          // ENUM is mapped to string (it can hold one value from a predefined list)
            { "SET", typeof(string) },           // SET is mapped to string (it can hold multiple values from a predefined list)

            // Binary Types
            { "BINARY", typeof(byte[]) },        // BINARY is mapped to byte[]
            { "VARBINARY", typeof(byte[]) },     // VARBINARY is mapped to byte[]
            { "BLOB", typeof(byte[]) },          // BLOB is mapped to byte[]
            { "TINYBLOB", typeof(byte[]) },      // TINYBLOB is mapped to byte[]
            { "MEDIUMBLOB", typeof(byte[]) },    // MEDIUMBLOB is mapped to byte[]
            { "LONGBLOB", typeof(byte[]) },      // LONGBLOB is mapped to byte[]

            // UUID Types
            { "UUID", typeof(Guid) },            // UUID is mapped to Guid (for globally unique identifier)

            // JSON Types
            { "JSON", typeof(string) },          // JSON is mapped to string (handling as raw JSON string)
        };
        private static readonly Dictionary<string, Type> TypesOracle = new()
        {
             // Numeric Types
            { "NUMBER", typeof(decimal) },        // NUMBER can represent various numeric types, often mapped to decimal
            { "FLOAT", typeof(double) },          // FLOAT in Oracle is mapped to double
            { "BINARY_FLOAT", typeof(float) },    // BINARY_FLOAT is mapped to float
            { "BINARY_DOUBLE", typeof(double) },  // BINARY_DOUBLE is mapped to double
            { "INTEGER", typeof(int) },           // INTEGER maps to int
            { "SMALLINT", typeof(short) },        // SMALLINT maps to short
            { "BIGINT", typeof(long) },           // BIGINT maps to long
            { "NUMBER(1)", typeof(bool) },        // NUMBER(1) can be used for boolean representation (1 = true, 0 = false)

            // Date and Time Types
            { "DATE", typeof(DateTime) },         // DATE in Oracle maps to DateTime
            { "TIMESTAMP", typeof(DateTime) },    // TIMESTAMP maps to DateTime
            { "TIMESTAMP WITH TIME ZONE", typeof(DateTimeOffset) }, // Maps to DateTimeOffset
            { "TIMESTAMP WITH LOCAL TIME ZONE", typeof(DateTime) }, // Maps to DateTime
            { "INTERVAL YEAR TO MONTH", typeof(string) }, // Maps to string (or custom structure)
            { "INTERVAL DAY TO SECOND", typeof(TimeSpan) }, // Maps to TimeSpan

            // String Types
            { "VARCHAR2", typeof(string) },       // VARCHAR2 maps to string
            { "VARCHAR", typeof(string) },        // VARCHAR maps to string
            { "CHAR", typeof(string) },           // CHAR maps to string
            { "NCHAR", typeof(string) },          // NCHAR maps to string
            { "NVARCHAR2", typeof(string) },      // NVARCHAR2 maps to string
            { "CLOB", typeof(string) },           // CLOB (Character Large Object) maps to string
            { "NCLOB", typeof(string) },          // NCLOB maps to string
            { "LONG", typeof(string) },           // LONG maps to string
            { "LONG RAW", typeof(byte[]) },       // LONG RAW maps to byte[]
            
            // Binary Types
            { "RAW", typeof(byte[]) },            // RAW maps to byte[]
            { "BLOB", typeof(byte[]) },           // BLOB (Binary Large Object) maps to byte[]
            { "BFILE", typeof(byte[]) },          // BFILE maps to byte[]
            { "XMLTYPE", typeof(string) },        // XMLTYPE can be mapped to string (or XDocument for XML parsing)

            // GUID Types
            { "ROWID", typeof(string) },          // ROWID maps to string (since it's not a standard GUID, it's a unique identifier)
            { "UROWID", typeof(string) },         // UROWID maps to string

            // Miscellaneous Types
            { "BOOLEAN", typeof(bool) },          // BOOLEAN (Oracle's internal boolean type)
            { "SYS.XMLTYPE", typeof(string) },    // SYS.XMLTYPE maps to string (or you can use XmlDocument or XDocument)
            { "OBJECT", typeof(object) },         // OBJECT maps to object, can be complex
            { "ANYDATA", typeof(object) },        // ANYDATA maps to object
            { "ANYTYPE", typeof(object) },        // ANYTYPE maps to object
            { "RAW(16)", typeof(Guid) },
        };
        private static readonly Dictionary<string, Type> TypesSqlServer = new()
        {
             // Numeric Types
            { "int", typeof(int) },
            { "bigint", typeof(long) },
            { "smallint", typeof(short) },
            { "tinyint", typeof(byte) },
            { "bit", typeof(bool) },
            { "decimal", typeof(decimal) },
            { "numeric", typeof(decimal) },
            { "float", typeof(double) },
            { "real", typeof(float) },

            // Money and Currency Types
            { "money", typeof(decimal) },
            { "smallmoney", typeof(decimal) },

            // Date and Time Types
            { "datetime", typeof(DateTime) },
            { "datetime2", typeof(DateTime) },
            { "smalldatetime", typeof(DateTime) },
            { "date", typeof(DateTime) },
            { "time", typeof(TimeSpan) },
            { "datetimeoffset", typeof(DateTimeOffset) },

            // String Types
            { "varchar", typeof(string) },
            { "nvarchar", typeof(string) },
            { "char", typeof(string) },
            { "nchar", typeof(string) },
            { "text", typeof(string) },
            { "ntext", typeof(string) },

            // Binary Types
            { "varbinary", typeof(byte[]) },
            { "binary", typeof(byte[]) },
            { "image", typeof(byte[]) },

            // GUID Type
            { "uniqueidentifier", typeof(Guid) },

            // Other Types
            { "xml", typeof(string) }, // For simplicity, treating XML as string.
            { "sql_variant", typeof(object) }, // Could be anything (handled as object)
            { "rowversion", typeof(byte[]) }, // 8-byte timestamp value
            { "timestamp", typeof(byte[]) }
        };
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
            if (filters is null ) return ;
            cw.WriteField("Table Filters");
            cw.NextRecord();
            cw.WriteField("Field");
            cw.WriteField("Operator");
            cw.WriteField("Value");
            cw.NextRecord();
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
        public static void WriteFilters<TModel>(this CsvWriter cw, Filter filters, Dictionary<string, string?> dataTypeColumns, string dbType)
        {
            if (filters is null) return;
            cw.WriteField("Table Filters");
            cw.NextRecord();
            cw.WriteField("Field");
            cw.WriteField("Operator");
            cw.WriteField("Value");
            cw.NextRecord();
            foreach (var filter in filters.GetFilterTextForCsv<TModel>(dataTypeColumns, dbType))
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
                                value = value.ToUniversalTime();
                                query += string.Format(DateOpForC[i.@operator], $"para.{i.field}.Value.Date", value.Date.ToString());;

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
                                MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                                MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);
                                object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { (JsonElement)i.value }), underlyingType);

                                query += string.Format(StringOpForC[i.@operator], $"para.{i.field}.Value", value.ToString());

                            }
                        }
                        else
                        {
                            MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);


                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                query = string.Format(NumberOpForC[i.@operator], $"para.{i.field}");


                            }
                            else
                            {
                                object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { (JsonElement)i.value }), underlyingType);
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
                            MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);
                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { (JsonElement)i.value }), propType);

                            query += string.Format(StringOpForC[i.@operator], $"para.{i.field}", value.ToString());
                        }
                        else
                        {
                            MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);

                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { (JsonElement)i.value }), propType);
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

                        if (underlyingType.Name == nameof(String))
                        {




                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);

                            }
                            else
                            {
                                string value = ((JsonElement)i.value).ToObject<string>();
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);

                            }
                        }
                        else if (underlyingType.Name == nameof(DateTime))
                        {

                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);
                            }
                            else
                            {
                                DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                                value = value.ToLocalTime();
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);
                            }
                        }
                        else if (underlyingType.IsEnum)
                        {

                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);
                            }
                            else
                            {
                                MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                                MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);
                                object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { (JsonElement)i.value }), underlyingType);

                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);
                            }
                        }
                        else
                        {
                            MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);


                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);

                            }
                            else
                            {
                                object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { (JsonElement)i.value }), underlyingType);
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);
                            }
                        }
                    }
                    else
                    {
                        if (propType.Name == nameof(String))
                        {
                            string value = ((JsonElement)i.value).ToObject<string>();
                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                        else if (propType.Name == nameof(DateTime))
                        {
                            DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                            value = value.ToLocalTime();
                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                        else if (propType.IsEnum)
                        {
                            MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);
                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { (JsonElement)i.value }), propType);

                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                        else
                        {
                            MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);

                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { (JsonElement)i.value }), propType);
                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                    }

                    ///////////////
                    /*  List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], i.value };
                      returnList.Add(v);*/
                }


            }


            return returnList;




        }
        public static List<List<object>> GetFilterTextForCsv<TModel>(this Filter Filters, Dictionary<string, string?> dataTypeColumns, string dbType)
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
                    returnList.AddRange(GetFilterTextForCsv<TModel>(filter, dataTypeColumns, dbType));

                }
                else
                {
                    string? columnType = dataTypeColumns[i.field];
                    Type propType = dbType == DbTypes.SqlServer ? TypesSqlServer[columnType] : dbType == DbTypes.Oracle ? TypesOracle[columnType] : TypesMySql[columnType];
                    Type? underlyingType = Nullable.GetUnderlyingType(propType);
                    if (underlyingType != null)
                    {

                        if (underlyingType.Name == nameof(String))
                        {




                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);

                            }
                            else
                            {
                                string value = ((JsonElement)i.value).ToObject<string>();
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);

                            }
                        }
                        else if (underlyingType.Name == nameof(DateTime))
                        {

                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);
                            }
                            else
                            {
                                DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                                value = value.ToLocalTime();
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);
                            }
                        }
                        else if (underlyingType.IsEnum)
                        {

                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);
                            }
                            else
                            {
                                MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                                MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);
                                object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { (JsonElement)i.value }), underlyingType);

                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);
                            }
                        }
                        else
                        {
                            MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);


                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);

                            }
                            else
                            {
                                object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { (JsonElement)i.value }), underlyingType);
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);
                            }
                        }
                    }
                    else
                    {
                        if (propType.Name == nameof(String))
                        {
                            string value = ((JsonElement)i.value).ToObject<string>();
                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                        else if (propType.Name == nameof(DateTime))
                        {
                            DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                            value = value.ToLocalTime();
                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                        else if (propType.IsEnum)
                        {
                            MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);
                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { (JsonElement)i.value }), propType);

                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                        else
                        {
                            MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);

                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { (JsonElement)i.value }), propType);
                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                    }

                    ///////////////
                    /*  List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], i.value };
                      returnList.Add(v);*/
                }


            }


            return returnList;




        }
        public static CsvWriter WriteQueryBuilderFilters(this CsvWriter cw, List<BuilderFilter> filters)
        {
            if (filters is null || filters.Count() == 0) return cw;
            cw.WriteField("Global Filters");
            cw.NextRecord();
            cw.WriteField("Field");
            cw.WriteField("Operator");
            cw.WriteField("Value");
            cw.NextRecord();
            foreach (var filter in filters)
            {
                
                    cw.WriteField(filter.Field.ToString());
                    cw.WriteField(filter.Operator.ToString());
                    cw.WriteField(filter.Value.ToString());
                    cw.NextRecord();
            }
            return cw;         }

    }


}

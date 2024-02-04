using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Hubs;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Newtonsoft.Json.Linq;
using Type = System.Type;

namespace ART_PACKAGE.Helpers.Csv
{
    public class CsvExport : ICsvExport
    {
        private static readonly Dictionary<string, string> StringOperations = new()
        {
            { "="              , "{1} = '{0}'" },
            { "<>"             , "{1} <> '{0}'" },
            { "isblank"          , "{1} IS NULL" },
            { "isnotblank"       , "{1} IS NOT NULL" },
            { "is_empty"         , $@"{{1}} = ''" },
            { "is_not_empty"      , $@"{{1}} <> ''" },
            { "startswith"      , "{1} LIKE '{0}%'" },
            { "not_begins_with", "{1} NOT LIKE '{0}%'" },
            { "contains"        , "{1} LIKE '%{0}%'" },
            { "notcontains"  , "{1} NOT LIKE '%{0}%'" },
            { "endswith"        , "{1} LIKE '%{0}'" },
            { "not_ends_with"  , "{1} NOT LIKE '%{0}'" },
            { "in"  , "{1} IN ({0})" },
            { "not_in"  , "{1} NOT IN ({0})" },
        };

        private static readonly Dictionary<string, string> NumberOperations = new()
        {
            { "=", "{1} = {0}" },
            { "<>", "{1} <> {0}" },
            { "isblank", "{1} IS NULL" },
            { "isnotblank", "{1} IS NOT NULL" },
            {">="  ,"{1} >= {0}"},
            {">"   ,"{1} > {0}"},
            {"<="  ,"{1} <= {0}"},
            { "<"  , "{1} < {0}" },
              { "in"  , "{1} IN ({0})" },
              { "not_in"  , "{1} NOT IN ({0})" },
        };

        private static readonly Dictionary<string, Dictionary<string, string>> DateOperations = new()
        {
            {
                "sqlServer"
            ,
            new Dictionary<string, string> {
            { "=", "Convert(date , {1} , 105) = Convert(date,'{0}',105)" },
            { "<>", "Convert(date , {1} , 105) <> Convert(date,'{0}',105)" },
            { "isblank", "{1} IS NULL" },
            { "isnotblank", "{1} IS NOT NULL" },
            {">=","Convert(date , {1} , 105) >= Convert(date,'{0}',105)"},
            {">","Convert(date , {1} , 105) > Convert(date,'{0}',105)"},
            {"<=","Convert(date , {1} , 105) <= Convert(date,'{0}',105)"},
            { "<", "Convert(date , {1} , 105) < Convert(date,'{0}',105)" },
              { "in"  , "Convert(date , {1} , 105) IN ({0})" },
              { "not_in"  , "Convert(date , {1} , 105) NOT IN ({0})" },
                }
            }

            ,

            {
                "oracle"
            ,
                new Dictionary<string, string> {
            { "=", "TRUNC({1}) =  to_date('{0}', 'dd-MM-yyyy')" },
            { "<>", "TRUNC({1}) <> to_date('{0}', 'dd-MM-yyyy')" },
            { "isblank", "{1} IS NULL" },
            { "isnotblank", "{1} IS NOT NULL" },
            {">=","TRUNC({1}) >= to_date('{0}', 'dd-MM-yyyy')"},
            {">","TRUNC({1}) > to_date('{0}', 'dd-MM-yyyy')"},
            {"<=","TRUNC({1}) <= to_date('{0}', 'dd-MM-yyyy')"},
            { "<", "TRUNC({1}) < to_date('{0}', 'dd-MM-yyyy')" },
              { "in"  , "TRUNC({1}) IN ({0})" },
              { "not_in"  , "TRUNC({1}) NOT IN ({0})" },
            }
            }
        };




        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ICsvExport> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly object _locker = new();
        public event Action<int, int> OnProgressChanged;

        public CsvExport(IHubContext<ExportHub> exportHub, UsersConnectionIds connections, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory, IWebHostEnvironment webHostEnvironment, ILogger<ICsvExport> logger)
        {
            _exportHub = exportHub;
            this.connections = connections;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            OnProgressChanged = (rd, fn) => _logger.LogInformation("file ({fn}) is being exported : {p}", fn, rd);

        }


        public async Task<IEnumerable<DataFile>> ExportForSchedulaedTask<TModel>(DbContext db, string parameterJson) where TModel : class
        {
            // IEntityType? tableData = db.Model.FindEntityType(typeof(TModel));
            // string? tbName = tableData.GetTableName() ?? tableData.GetViewName();
            // string dbtype = db.Database.IsSqlServer() ? "sqlServer" : "oracle";
            List<object>? @params = JsonConvert.DeserializeObject<List<object>>(parameterJson);
            ParameterExpression param = Expression.Parameter(typeof(TModel), "t");
            Expression<Func<TModel, bool>> clause = GenerateWhereClause<TModel>(param, @params);
            //string where = string.IsNullOrEmpty(clause) ? "" : "Where " + clause;
            IQueryable<TModel> data = db.Set<TModel>().Where(clause);
            byte[][] bytes = await Task.WhenAll(ExportDataToCsv(data));
            string currentDate = DateTime.UtcNow.ToString("dd-MM-yyyy-HH-mm");
            IEnumerable<DataFile> files = bytes.Select((b, i) => new DataFile(i + 1 + ".Report_" + currentDate + ".csv"
                , "text/csv", b));

            return files;
        }

        private IEnumerable<Task<byte[]>> ExportDataToCsv<TModel>(IQueryable<TModel> data)
        {
            CsvConfiguration config = new(CultureInfo.CurrentCulture)
            {
                Encoding = Encoding.UTF8,
                IgnoreBlankLines = true,
                AllowComments = true,

            };
            int total = data.Count();
            int batch = 1_048_576;
            int skip = 0;
            List<Task<byte[]>> tasks = new() { };
            while (total > 0)
            {
                IQueryable<TModel> tempData = data.Skip(skip).Take(batch);

                yield return Task.Run(() =>
                {
                    using MemoryStream stream = new();
                    using (StreamWriter sw = new(stream, new UTF8Encoding(false)))
                    using (CsvWriter cw = new(sw, config))
                    {

                        BaseClassMap<TModel> mapperInstance = new CsvClassMapFactory().CreateInstance<TModel>();

                        cw.Context.RegisterClassMap(mapperInstance);
                        cw.WriteHeader<TModel>();
                        cw.NextRecord();
                        foreach (TModel? elm in tempData)
                        {
                            cw.WriteRecord(elm);
                            cw.NextRecord();
                        }
                    }
                    byte[] b = stream.ToArray();
                    return b;
                });
                //tasks.Add(task);
                total -= batch;
                skip += batch;
            }


        }
        // Check if the property is of a specific type
        private bool IsPropertyOfType<T>(PropertyInfo propertyInfo)
        {
            Type type = propertyInfo.PropertyType;
            Type? underlyingType = Nullable.GetUnderlyingType(type);
            return type == typeof(T) || underlyingType == typeof(T);
        }

        // Generate the WHERE clause
        public Expression<Func<TModel, bool>> GenerateWhereClause<TModel>(ParameterExpression param, List<object> parameters)
        {


            Expression Exp = null;
            for (int i = 0; i < parameters.Count; i++)
            {
                JArray f = (JArray)parameters[i];
                if (i == 0 && TryParse(f, out List<object> filterList))
                    Exp = ProcessFilterGroup<TModel>(param, filterList);

                if (TryParse(f, out string op))
                {
                    _ = TryParse((JArray)parameters[i + 1], out List<object> nextFilterList);
                    Expression nextExp = ProcessFilterGroup<TModel>(param, nextFilterList);
                    Exp = op == "and" ? Expression.AndAlso(Exp, nextExp) : Expression.OrElse(Exp, nextExp);
                    i++;
                }
            }
            return Exp is null ? x => true : Expression.Lambda<Func<TModel, bool>>(Exp, param);
        }

        private bool TryParse<T>(JArray jarr, out T output)
        {
            try
            {
                output = jarr.ToObject<T>();
                return true;
            }
            catch (Exception e)
            {
                output = default;
                return false;
            }
        }

        private Expression ProcessFilterGroup<TModel>(ParameterExpression param, List<object> filterGroup)
        {
            Expression Exp = null;
            for (int i = 0; i < filterGroup.Count; i++)
            {
                if (filterGroup[i] is not string)
                {
                    JArray f = (JArray)filterGroup[i];
                    if (i == 0 && TryParse(f, out List<string> filterList))
                        Exp = ProcessFilterList<TModel>(param, filterList);
                    continue;
                }


                if (filterGroup[i] is string op)
                {
                    _ = TryParse((JArray)filterGroup[i + 1], out List<string> nextFilterList);
                    Expression nextExp = ProcessFilterList<TModel>(param, nextFilterList);
                    Exp = op == "and" ? Expression.AndAlso(Exp, nextExp) : Expression.OrElse(Exp, nextExp);
                    i++;
                }
            }

            return Exp;
        }

        // Process filter when it's a list
        private Expression ProcessFilterList<TModel>(ParameterExpression param, List<string> filterList)
        {

            Filter filter = new()
            {
                @operator = filterList[1],
                field = filterList[0],
                value = filterList[2]
            };
            if (filterList[1].StartsWith("in", StringComparison.OrdinalIgnoreCase))
            {
                filter.@operator = "in";
                filter.value = filterList[2].Split(",").ToList();
            }
            return FilterExtensions.BuildIndividualExpression<TModel>(param, filter);
            // string propertyName = filterList[0];
            // IProperty property = tableData.GetProperty(propertyName);
            // PropertyInfo propInfo = typeof(TModel).GetProperty(propertyName) ?? throw new ArgumentException($"Property '{propertyName}' not found on '{typeof(TModel).Name}'");
            // string columnName = property.GetColumnName();
            // bool isNumber = IsPropertyOfType<decimal>(propInfo);
            // bool isDate = IsPropertyOfType<DateTime>(propInfo);
            //
            // string clause;
            //
            // if (filterList[1].StartsWith("in", StringComparison.OrdinalIgnoreCase))
            // {
            //     filterList[1] = "in";
            //     filterList[2] = FormatInClauseValues(filterList[2], isNumber);
            // }
            //
            // clause = isNumber
            //     ? string.Format(NumberOperations[filterList[1]], filterList[2], columnName)
            //     : isDate
            //         ? string.Format(DateOperations[dbType][filterList[1]], filterList[2], columnName)
            //         : string.Format(StringOperations[filterList[1]], filterList[2], columnName);
            //
            // return clause;
        }

        // Format values for IN clause
        private string FormatInClauseValues(string values, bool isNumber)
        {
            return isNumber
                ? values
                : string.Join(",", values.Split(',').Select(x => $"'{x.Trim()}'"));
        }
        public bool ExportData<TContext, TModel>(ExportRequest exportRequest, int total, string folderPath, string fileName, int fileNumber, string userName, Expression<Func<TModel, bool>> baseCondition = null)
         where TContext : DbContext
            where TModel : class
        {
            IBaseRepo<TContext, TModel> Repo = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IBaseRepo<TContext, TModel>>();
            GridResult<TModel> dataRes = Repo.GetGridData(exportRequest.DataReq, baseCondition: baseCondition);
            IQueryable<TModel>? data = dataRes.data;
            return ExportToFolder(data, exportRequest.IncludedColumns, dataRes.total, folderPath, fileName, fileNumber);
        }



        private bool ExportToFolder<TModel>(IQueryable<TModel> data, List<string> inculdedColumns, int dataCount, string folderPath, string fileName, int fileNumber = 1)
        {
            CsvConfiguration config = new(CultureInfo.CurrentCulture)
            {
                IgnoreReferences = true,
            };
            using MemoryStream stream = new();
            using StreamWriter sw = new(stream, new UTF8Encoding(true));
            using CsvWriter cw = new(sw, config);

            BaseClassMap<TModel> mapperInstance = new CsvClassMapFactory(inculdedColumns).CreateInstance<TModel>();

            cw.Context.RegisterClassMap(mapperInstance);

            cw.WriteHeader<TModel>();

            cw.NextRecord();
            int index = 0;
            float progress = 0;
            foreach (TModel item in data)
            {
                cw.WriteRecord(item);
                cw.NextRecord();
                index++; // Increment the index for each item
                if (dataCount > 100)
                {
                    if (index % 100 == 0 || index == dataCount) // Also check progress at the last item
                    {
                        //progress = (float)(index / (float)total * 100);
                        int recordsDone = index + 1;
                        lock (_locker)
                        {
                            OnProgressChanged(recordsDone, fileNumber);
                        }
                    }
                }
                else
                {
                    int recordsDone = index + 1;
                    lock (_locker)
                    {
                        OnProgressChanged(recordsDone, fileNumber);
                    }
                }

            }


            cw.Flush();
            sw.Flush();
            stream.Flush();

            // Reset the position of the MemoryStream to the beginning
            stream.Position = 0;


            if (!Directory.Exists(folderPath))
                _ = Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, $"{fileNumber}.{fileName}");
            try
            {
                File.WriteAllBytes(filePath, stream.ToArray());
                return true;
            }

            catch (Exception ex)
            {
                _logger.LogError("some thing wrong happend while saving the file : {err}", ex.Message);
                return false;

            }
        }

    }
}

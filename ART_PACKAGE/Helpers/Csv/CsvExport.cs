using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Hubs;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using Expression = System.Linq.Expressions.Expression;
using Type = System.Type;

namespace ART_PACKAGE.Helpers.Csv
{
    public class CsvExport : ICsvExport
    {

        private static readonly Dictionary<string, string> StringOp = new()
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

        private static readonly Dictionary<string, string> NumberOp = new()
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

        private static readonly Dictionary<string, Dictionary<string, string>> DateOp = new()
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
        public event Action<float> OnProgressChanged = (p) =>
        {
            Console.WriteLine("test :" + p);
        };

        public CsvExport(IHubContext<ExportHub> exportHub, UsersConnectionIds connections, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory, IWebHostEnvironment webHostEnvironment, ILogger<ICsvExport> logger)
        {
            _exportHub = exportHub;
            this.connections = connections;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        public async Task Export<TModel, TController>(DbContext _db, string userName, ExportDto<object> obj) where TModel : class
        {
            await Export<TModel, TController, object>(_db, userName, obj);
        }

        public async Task Export<TModel, TController, TColumn>(DbContext _db, string userName, ExportDto<object> obj, string idColumn = null) where TModel : class
        {
            IEntityType? tableData = _db.Model.FindEntityType(typeof(TModel));
            string? tbName = tableData.GetTableName() ?? tableData.GetViewName();
            IQueryable<TModel> data = null;
            if (idColumn is not null && obj.SelectedIdz is not null && obj.SelectedIdz.Count() > 0)
            {
                string columnName = tableData.GetProperty(idColumn).GetColumnName();
                IEnumerable<TColumn> idz = obj.SelectedIdz.Select(x => ((JsonElement)x).ToObject<TColumn>());
                string idzForSql = !typeof(TColumn).IsNumericType() ? string.Join(",", idz.Select(x => $"'{x}'")) : string.Join(",", idz);
                data = _db.Set<TModel>().FromSqlRaw($@"SELECT * FROM {tableData.GetSchema()}.{tbName}
                                                        WHERE {columnName} IN ({idzForSql})");
            }
            else
            {
                data = _db.Set<TModel>();
            }
            await ExportAllCsv<TModel, TController, object>(data, userName, obj);

        }


        public async Task ExportAllCsv<T, T1, T2>(IQueryable<T> data, string userName, ExportDto<T2> obj = null, bool all = true)
        {
            int i = 0;
            string reqId = Guid.NewGuid().ToString();
            string Date = DateTime.UtcNow.ToString("dd-MM-yyyy-HH-mm");
            foreach (Task<byte[]> item in data.ExportToCSVE<T, GenericCsvClassMapper<T, T1>>(obj.Req))
            {
                try
                {

                    byte[] bytes = await item;
                    string FileName = i + 1 + "." + typeof(T1).Name.Replace("Controller", "") + "_" + Date + ".csv";
                    SaveByteArrayAsCsv(bytes, FileName, reqId);


                    await _exportHub.Clients.Clients(connections.GetConnections(userName))
                                .SendAsync("csvRecevied", bytes, FileName, i, reqId);
                    i++;
                }
                catch (Exception)
                {
                    await _exportHub.Clients.Clients(connections.GetConnections(userName))
                                .SendAsync("csvErrorRecevied", i);

                }

            }
            await _exportHub.Clients.Clients(connections.GetConnections(userName))
                               .SendAsync("FinishedExportFor", reqId, i);
        }
        private void SaveByteArrayAsCsv(byte[] byteArray, string fileName, string folderGuid)
        {
            try
            {
                // Create a directory with the GUID as its name
                string folderPath = Path.Combine(Path.Combine(_webHostEnvironment.WebRootPath, "CSV"), folderGuid);
                if (!Directory.Exists(folderPath))
                    _ = Directory.CreateDirectory(folderPath);

                // Create a file path within the directory using the provided file name
                string filePath = Path.Combine(folderPath, fileName);

                // Write the byte array to the CSV file
                File.WriteAllBytes(filePath, byteArray);

                Console.WriteLine($"Byte array saved as '{fileName}' in folder '{folderGuid}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public Func<T, ExportDto<T2>, bool> GetContainsExpression<T, T2>(string propName)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "x");
            ParameterExpression objParam = Expression.Parameter(typeof(ExportDto<T2>), "obj");
            MemberExpression prop = Expression.Property(param, propName);
            MemberExpression objProp = Expression.Property(objParam, "SelectedIdz");
            MethodCallExpression containsEx = Expression.Call(
        typeof(Enumerable),  // Assuming SelectedIdz is IEnumerable
        "Contains",
        new[] { typeof(T2) },  // Adjust this if SelectedIdz is of a different type
        objProp,
        prop
    );

            Expression<Func<T, ExportDto<T2>, bool>> lambda = Expression.Lambda<Func<T, ExportDto<T2>, bool>>(containsEx, param, objParam);

            return lambda.Compile();
        }
        public async Task ExportSelectedCsv<T, T1, T2>(IQueryable<T> data, string propName, string userName, ExportDto<T2> obj = null, bool all = true)
        {
            IEnumerable<Task> tasks;
            int i = 1;
            if (obj.All)
            {
                tasks = data.ExportToCSVE<T, GenericCsvClassMapper<T, T1>>(obj.Req);


            }
            else
            {
                Type type = typeof(T);
                System.Reflection.PropertyInfo? prop = type.GetProperty(propName);
                Func<T, ExportDto<T2>, bool> crt = GetContainsExpression<T, T2>(propName);
                tasks = data.ToList().Where(x => crt(x, obj)).AsQueryable().ExportToCSVE<T, GenericCsvClassMapper<T, T1>>(obj.Req);
            }

            foreach (Task<byte[]> item in tasks.Cast<Task<byte[]>>())
            {
                try
                {
                    byte[] bytes = await item;
                    string FileName = typeof(T1).Name.Replace("Controller", "") + "_" + i + "_" + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";



                    await _exportHub.Clients.Clients(connections.GetConnections(userName))
                                .SendAsync("csvRecevied", bytes, FileName);

                    i++;
                }
                catch (Exception ex)
                {
                    await _exportHub.Clients.Clients(connections.GetConnections(userName))
                                .SendAsync("csvErrorRecevied", i);

                }

            }
        }

        public async Task ExportMissed(string reqId, string UserName, List<int> missedFiles)
        {
            string folderPath = Path.Combine(Path.Combine(_webHostEnvironment.WebRootPath, "CSV"), reqId);
            IEnumerable<string> FilesNames = Directory.EnumerateFiles(folderPath);
            IEnumerable<string> missedFilesNames = FilesNames.Where(f => missedFiles.Any(x => Path.GetFileName(f).StartsWith(x.ToString())));

            var files = missedFilesNames.Select(x => new { file = File.ReadAllBytes(x), fileName = Path.GetFileName(x) });
            await _exportHub.Clients.Clients(connections.GetConnections(UserName))
                                .SendAsync("missedFilesRecived", files, reqId);
        }

        public void ClearExportFolder(string reqId)
        {
            string folderPath = Path.Combine(Path.Combine(_webHostEnvironment.WebRootPath, "CSV"), reqId);
            Directory.Delete(folderPath, true);
        }

        public async Task<IEnumerable<DataFile>> ExportForSchedulaedTask<TModel, TController>(DbContext db, string parameterJson) where TModel : class
        {
            IEntityType? tableData = db.Model.FindEntityType(typeof(TModel));
            string? tbName = tableData.GetTableName() ?? tableData.GetViewName();
            string dbtype = db.Database.IsSqlServer() ? "sqlServer" : "oracle";
            List<object>? param = JsonConvert.DeserializeObject<List<object>>(parameterJson);
            string clause = GenerateWhereClause<TModel>(db, tableData, dbtype, param);
            string where = string.IsNullOrEmpty(clause) ? "" : "Where " + clause;
            IQueryable<TModel> data = db.Set<TModel>().FromSqlRaw($@"SELECT * FROM {tableData.GetSchemaQualifiedViewName()}
                                                       {where}");
            byte[][] bytes = await Task.WhenAll(ExportDataToCsv<TModel, TController>(data));
            string currentDate = DateTime.UtcNow.ToString("dd-MM-yyyy-HH-mm");
            IEnumerable<DataFile> files = bytes.Select((b, i) => new DataFile(i + 1 + "." + typeof(TController).Name.Replace("Controller", "") + "_" + currentDate + ".csv"
                , "text/csv", b));

            return files;
        }

        private IEnumerable<Task<byte[]>> ExportDataToCsv<TModel, TController>(IQueryable<TModel> data)
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

                        //_ = cw.Context.RegisterClassMap<GenericCsvClassMapper<TController, TModel>>();
                        //if (filterCells is not null && filterCells.Count != 0)
                        //{
                        //    foreach (List<object> item in filterCells)
                        //    {
                        //        cw.WriteComment(string.Join(",", item));
                        //    }
                        //    cw.NextRecord();
                        //}



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
        private bool IsPropertyOfType<T>(Type type)
        {
            Type? underlyingType = Nullable.GetUnderlyingType(type);
            return type.Name == typeof(T).Name || underlyingType?.Name == typeof(T).Name;
        }

        private string GenerateWhereClause<TModel>(DbContext db, IEntityType? tableData, string dbtype, List<object> param)
        {


            StringBuilder sb = new();
            foreach (object filter in param)
            {

                try
                {
                    List<string>? filterarr = filter as List<string> ?? (filter as JArray)?.ToObject<List<string>>();
                    if (filterarr is not null)
                    {
                        IProperty prop = tableData.GetProperty(filterarr[0]);
                        Type paramType = typeof(TModel).GetProperty(filterarr[0]).PropertyType;
                        bool isNumber = paramType.IsNumericType();
                        bool isDate = IsPropertyOfType<DateTime>(paramType);
                        string columnName = prop.GetColumnName();
                        string clause = string.Empty;
                        clause = isNumber
                            ? string.Format(NumberOp[filterarr[1]], filterarr[2], columnName)
                            : isDate
                            ? string.Format(DateOp[dbtype][filterarr[1]], filterarr[2], columnName)
                            : string.Format(StringOp[filterarr[1]], filterarr[2], columnName);
                        _ = sb.Append(clause);
                    }
                    else
                    {
                        string? op = filter as string ?? (filter as JArray)?.ToObject<string>();
                        _ = sb.Append(" " + op + " ");
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        string? op = filter as string ?? (filter as JArray)?.ToObject<string>();

                        _ = sb.Append(" " + op + " ");
                    }
                    catch (Exception opex)
                    {
                        try
                        {
                            List<object>? para = filter as List<object> ?? (filter as JArray)?.ToObject<List<object>>();
                            _ = sb.Append("(" + GenerateWhereClause<TModel>(db, tableData, dbtype, para) + ")");
                        }
                        catch (Exception pex)
                        {

                            throw;
                        }

                    }
                }

            }
            string returnClause = sb.ToString();
            return returnClause;

            //var groupedParams = parameters.GroupBy(x => new { x.ParameterName, x.Operator });
            //foreach (var paramGroup in groupedParams)
            //{
            //    IProperty prop = tableData.GetProperty(paramGroup.Key.ParameterName);
            //    Type paramType = prop.GetType();
            //    bool isNumber = paramType.IsNumericType();
            //    bool isDate = paramType.Name == nameof(DateTime);
            //    string values = string.Empty;
            //    if (paramGroup.Key.Operator.Contains("in", StringComparison.OrdinalIgnoreCase))
            //    {
            //        values = string.Join(",", groupedParams.SelectMany(x => x.Select(p => isNumber ? p.ParameterValue : $"'{p.ParameterValue}'")));
            //    }
            //    values = groupedParams.FirstOrDefault().FirstOrDefault().ParameterValue;
            //    string columnName = prop.GetColumnName();
            //    if (isNumber)
            //        whereClause.Add(string.Format(NumberOp[paramGroup.Key.Operator], values, columnName));
            //    else if (isDate)
            //    {
            //        string sql = DateOp[dbtype][paramGroup.Key.Operator];
            //        whereClause.Add(string.Format(sql, values, columnName));
            //    }
            //    else
            //        whereClause.Add(string.Format(StringOp[paramGroup.Key.Operator], values, columnName));
            //}

            //return whereClause.Count < 0 ? string.Empty : "WHERE " + string.Join(" AND ", whereClause);
        }

        public bool ExportData<TModel>(IEnumerable<TModel> data, int total, string folderPath, string fileName)
        {
            this.OnProgressChanged += OnProgressChanged;
            CsvConfiguration config = new(CultureInfo.CurrentCulture)
            {
                IgnoreReferences = true,
            };
            using MemoryStream stream = new();
            using StreamWriter sw = new(stream, new UTF8Encoding(true));
            using CsvWriter cw = new(sw, config);


            cw.WriteHeader<TModel>();
            cw.NextRecord();
            float progress = 0;
            int index = 0;
            foreach (TModel item in data)
            {
                cw.WriteRecord(item);
                cw.NextRecord();
                index++; // Increment the index for each item

                if (index % 100 == 0 || index == total) // Also check progress at the last item
                {
                    progress = (float)(index / (float)total * 100);
                    OnProgressChanged?.Invoke(progress);
                    //_exportHub.Clients.Clients(connections.GetConnections(user))
                    //               .SendAsync("updateExportProgress", progress);
                }
            }


            cw.Flush();
            sw.Flush();
            stream.Flush();

            // Reset the position of the MemoryStream to the beginning
            stream.Position = 0;


            if (!Directory.Exists(folderPath))
                _ = Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);
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

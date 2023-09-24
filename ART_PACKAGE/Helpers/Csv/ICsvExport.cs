using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.Json;

namespace ART_PACKAGE.Helpers.Csv
{
    public class CsvExport : ICsvExport
    {
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CsvExport(IHubContext<ExportHub> exportHub, UsersConnectionIds connections, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory, IWebHostEnvironment webHostEnvironment)
        {
            _exportHub = exportHub;
            this.connections = connections;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task Export<TModel, TController>(DbContext _db, string userName, ExportDto<object> obj) where TModel : class
        {
            await Export<TModel, TController, object>(_db, userName, obj);
        }

        public async Task Export<TModel, TController, TColumn>(DbContext _db, string userName, ExportDto<object> obj, string idColumn = null) where TModel : class
        {
            Microsoft.EntityFrameworkCore.Metadata.IEntityType? tableData = _db.Model.FindEntityType(typeof(TModel));
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


    }
}
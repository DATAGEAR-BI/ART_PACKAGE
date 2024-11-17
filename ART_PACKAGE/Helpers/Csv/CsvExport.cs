using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Extentions.CSV;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Handlers;
using ART_PACKAGE.Hubs;
using CsvHelper;
using CsvHelper.Configuration;
using Data.Services;
using Data.Services.CustomReport;
using Data.Services.Grid;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using ART_PACKAGE.Helpers.DBService;
using Filter = Data.Services.Grid.Filter;

namespace ART_PACKAGE.Helpers.Csv
{
    public class CsvExport : ICsvExport
    {
        private readonly ILogger<ICsvExport> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly object _locker = new();
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ReportConfigService _reportConfigService;
        private readonly ProcessesHandler _processesHandler;




        public event Action<int, int> OnProgressChanged;

        public CsvExport(IServiceScopeFactory serviceScopeFactory, ILogger<ICsvExport> logger, IHubContext<ExportHub> exportHub, UsersConnectionIds connections, IWebHostEnvironment webHostEnvironment, ReportConfigService reportConfigService, ProcessesHandler processesHandler)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            OnProgressChanged = (rd, fn) => _logger.LogInformation("file ({fn}) is being exported : {p}", fn, rd);
            this.connections = connections;
            _webHostEnvironment = webHostEnvironment;
            _exportHub = exportHub;
            _reportConfigService = reportConfigService;
            _processesHandler = processesHandler;


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
                string idzForSql = !GridHelprs.IsNumericType(typeof(TColumn)) ? string.Join(",", idz.Select(x => $"'{x}'")) : string.Join(",", idz);
                data = _db.Set<TModel>().FromSqlRaw($@"SELECT * FROM {tableData.GetSchema()}.{tbName}
                                                        WHERE {columnName} IN ({idzForSql})");
            }
            else
            {
                data = _db.Set<TModel>();
            }
            await ExportAllCsv<TModel, TController, object>(data, userName, obj);

        }


        public async Task<IEnumerable<DataFile>> ExportForSchedulaedTask<TModel, TContext>(string parameterJson) where TModel : class where TContext : DbContext
        {
            IBaseRepo<TContext, TModel> Repo = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IBaseRepo<TContext, TModel>>();
            List<object>? @params = JsonConvert.DeserializeObject<List<object>>(parameterJson);
            IQueryable<TModel> data = Repo.GetScheduleData(@params);
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
            if (total == 0)
            {
                yield return Task.Run(() =>
                {
                    using MemoryStream stream = new();
                    using (StreamWriter sw = new(stream, new UTF8Encoding(false)))
                    using (CsvWriter cw = new(sw, config))
                    {
                        var reC = ReportConfigService.GetConfigs<TModel>();
                        ClassMap mapperInstance = new CsvClassMapFactory().CreateInstance<TModel>(_reportConfigService);

                        cw.Context.RegisterClassMap(mapperInstance);
                        cw.WriteHeader<TModel>();
                        cw.NextRecord();
                    }
                    byte[] b = stream.ToArray();
                    return b;
                });
            }
            while (total > 0)
            {
                IQueryable<TModel> tempData = data.Skip(skip).Take(batch);

                yield return Task.Run(() =>
                {
                    using MemoryStream stream = new();
                    using (StreamWriter sw = new(stream, new UTF8Encoding(false)))
                    using (CsvWriter cw = new(sw, config))
                    {

                        ClassMap mapperInstance = new CsvClassMapFactory().CreateInstance<TModel>(_reportConfigService);

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

        public bool ExportData<TRepo, TContext, TModel>(ExportRequest exportRequest, string folderPath, string fileName, int fileNumber,string tenantId, Expression<Func<TModel, bool>> baseCondition = null, SortOption? defaultSort = null)
            where TContext : DbContext
            where TModel : class
            where TRepo : IBaseRepo<TContext, TModel>
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                ITenantService tenantService = scope.ServiceProvider.GetRequiredService<ITenantService>();
                tenantService.ManiualSetCurrentTenant(tenantId);


                TRepo Repo = scope.ServiceProvider.GetRequiredService<TRepo>();
                GridResult<TModel> dataRes = Repo.GetGridData(exportRequest.DataReq, baseCondition: baseCondition, defaultSort: defaultSort);
                IQueryable<TModel>? data = dataRes.data;
                int total = dataRes.total;
                return ExportToFolder(data, exportRequest.IncludedColumns, dataRes.total, folderPath, fileName, exportRequest.DataReq.Filter, fileNumber);
            }
        }
        public bool ExportData<TRepo, TContext, TModel>(ExportRequest exportRequest, string folderPath, string fileName, int fileNumber, string reportGUID, string tenantId,Expression<Func<TModel, bool>> baseCondition = null, SortOption? defaultSort = null)
            where TContext : DbContext
            where TModel : class
            where TRepo : IBaseRepo<TContext, TModel>
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                ITenantService tenantService = scope.ServiceProvider.GetRequiredService<ITenantService>();
                tenantService.ManiualSetCurrentTenant(tenantId);


                TRepo Repo = scope.ServiceProvider.GetRequiredService<TRepo>();
            GridResult<TModel> dataRes = Repo.GetGridData(exportRequest.DataReq, baseCondition: baseCondition, defaultSort: defaultSort);
            IQueryable<TModel>? data = dataRes.data;
            int total = dataRes.total;



            return ExportToFolder(data, exportRequest.IncludedColumns, dataRes.total, folderPath, fileName, exportRequest.DataReq.Filter, reportGUID, fileNumber);
                 }
        }

        public bool ExportCustomData(ArtCustomReport report, ExportRequest exportRequest, string folderPath, string fileName,
            int fileNumber)
        {

            DBFactory dbFactory = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<DBFactory>();
            ICustomReportRepo Repo = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ICustomReportRepo>();
            DbContext? schemaContext = dbFactory.GetDbInstance(report.Schema.ToString());
            GridResult<Dictionary<string, object>> dataRes = Repo.GetGridData(schemaContext, report, exportRequest.DataReq);
            IQueryable<CustomReportRecord> data = dataRes.data.Select(x => new CustomReportRecord() { Data = x });
            return ExportToFolder(data, exportRequest.IncludedColumns,
                dataRes.total, folderPath, fileName, exportRequest.DataReq.Filter, fileNumber);

        }

        public bool ExportCustomData(ArtCustomReport report, ExportRequest exportRequest, string folderPath, string fileName,
           int fileNumber, string reportGUID,string tenantId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                ITenantService tenantService = scope.ServiceProvider.GetRequiredService<ITenantService>();
                tenantService.ManiualSetCurrentTenant(tenantId);
                IDbService dbService = scope.ServiceProvider.GetRequiredService<IDbService>();
                DBFactory dbFactory = scope.ServiceProvider.GetRequiredService<DBFactory>();
                
                ICustomReportRepo Repo = scope.ServiceProvider.GetRequiredService<ICustomReportRepo>();
                DbContext? schemaContext = dbFactory.GetDbInstance(report.Schema.ToString());
                GridResult<Dictionary<string, object>> dataRes = Repo.GetGridData(schemaContext, report, exportRequest.DataReq);
                IQueryable<CustomReportRecord> data = dataRes.data.Select(x => new CustomReportRecord() { Data = x });
                return ExportToFolder(data, exportRequest.IncludedColumns,
                    dataRes.total, folderPath, fileName, exportRequest.DataReq.Filter, reportGUID, fileNumber);
            }
           

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

            ClassMap mapperInstance = new CsvClassMapFactory(inculdedColumns).CreateInstance<TModel>(_reportConfigService);

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

            if (!data.Any())
                OnProgressChanged(0, fileNumber);

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

        private bool ExportToFolder<TModel>(IQueryable<TModel> data, List<string> inculdedColumns, int dataCount, string folderPath, string fileName, Filter filters, int fileNumber = 1)
        {

            CsvConfiguration config = new(CultureInfo.CurrentCulture)
            {
                IgnoreReferences = true,
            };
            using MemoryStream stream = new();
            using StreamWriter sw = new(stream, new UTF8Encoding(true));
            using CsvWriter cw = new(sw, config);

            ClassMap mapperInstance = new CsvClassMapFactory(inculdedColumns).CreateInstance<TModel>(_reportConfigService);

            cw.Context.RegisterClassMap(mapperInstance);
            cw.WriteFilters<TModel>(filters);
            cw.WriteHeader<TModel>();
            cw.NextRecord();


            if (!data.Any())
                OnProgressChanged(0, fileNumber);
            int index = 0;
            int datacount = data.Count();
            float progress = 0;

            foreach (TModel item in data)
            {

                //_logger.LogCritical("csv debug " + DateTime.Now.ToString());
                cw.WriteRecord(item);
                cw.NextRecord();
                //d_logger.LogCritical("csv debug " + DateTime.Now.ToString());

                index++; // Increment the index for each item
                if (dataCount > 100)
                {

                    if (index % 100 == 0 || index == datacount) // Also check progress at the last item
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

        private bool ExportToFolder<TModel>(IQueryable<TModel> data, List<string> inculdedColumns, int dataCount, string folderPath, string fileName, Filter filters, string reportGUID, int fileNumber = 1)
        {

            CsvConfiguration config = new(CultureInfo.CurrentCulture)
            {
                IgnoreReferences = true,
            };
            using MemoryStream stream = new();
            using StreamWriter sw = new(stream, new UTF8Encoding(true));
            using CsvWriter cw = new(sw, config);

            ClassMap mapperInstance = new CsvClassMapFactory(inculdedColumns).CreateInstance<TModel>(_reportConfigService);

            cw.Context.RegisterClassMap(mapperInstance);
            cw.WriteFilters<TModel>(filters);
            cw.WriteHeader<TModel>();
            cw.NextRecord();


            if (!data.Any())
                OnProgressChanged(0, fileNumber);
            int index = 0;
            int datacount = data.Count();
            float progress = 0;

            foreach (TModel item in data)
            {
                if (_processesHandler.isProcessCanceld(reportGUID))
                {
                    cw.Flush();
                    sw.Flush();
                    stream.Flush();

                    // Reset the position of the MemoryStream to the beginning
                    stream.Position = 0;


                    if (!Directory.Exists(folderPath))
                        _ = Directory.CreateDirectory(folderPath);

                    string returnedFilePath = Path.Combine(folderPath, $"{fileNumber}.{fileName}");
                    try
                    {
                        File.WriteAllBytes(returnedFilePath, stream.ToArray());
                        return true;
                    }

                    catch (Exception ex)
                    {
                        _logger.LogError("some thing wrong happend while saving the file : {err}", ex.Message);
                        return false;

                    }
                }
                //_logger.LogCritical("csv debug " + DateTime.Now.ToString());
                cw.WriteRecord(item);
                cw.NextRecord();
                //d_logger.LogCritical("csv debug " + DateTime.Now.ToString());

                if (dataCount > 100)
                {

                    if (index % 100 == 0 || index == datacount) // Also check progress at the last item
                    {

                        //progress = (float)(index / (float)total * 100);
                        lock (_locker)
                        {
                            OnProgressChanged(index, fileNumber);
                        }
                        //int recordsDone = index + 1;

                    }

                }
                else
                {
                    lock (_locker)
                    {
                        OnProgressChanged(index, fileNumber);
                    }
                    //int recordsDone = index + 1;

                }
                index++; // Increment the index for each item

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
                lock (_locker)
                {
                    OnProgressChanged(index, fileNumber);
                }
                return true;
            }

            catch (Exception ex)
            {
                _logger.LogError("some thing wrong happend while saving the file : {err}", ex.Message);
                return false;

            }
        }



        public async Task ExportAllCsv<T, T1, T2>(IQueryable<T> data, string userName, ExportDto<T2> obj = null, bool all = true)
        {
            int i = 0;
            string reqId = Guid.NewGuid().ToString();
            string Date = DateTime.UtcNow.ToString("dd-MM-yyyy-HH-mm");
            foreach (Task<byte[]> item in data.ExportToCSVE<T, GenericCsvClassMapper<T>>(obj.Req))
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
    }
}

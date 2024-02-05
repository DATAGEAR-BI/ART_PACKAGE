using ART_PACKAGE.Helpers.CSVMAppers;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;

namespace ART_PACKAGE.Helpers.Csv
{
    public class CsvExport : ICsvExport
    {
        private readonly ILogger<ICsvExport> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly object _locker = new();
        public event Action<int, int> OnProgressChanged;

        public CsvExport(IServiceScopeFactory serviceScopeFactory, ILogger<ICsvExport> logger)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            OnProgressChanged = (rd, fn) => _logger.LogInformation("file ({fn}) is being exported : {p}", fn, rd);

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

                        BaseClassMap<TModel> mapperInstance = new CsvClassMapFactory().CreateInstance<TModel>();

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

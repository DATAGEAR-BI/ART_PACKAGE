using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ART_PACKAGE.Helpers.Csv
{
    public class CsvExport : ICsvExport
    {
        private readonly IHubContext<ExportHub> _exportHub;

        public CsvExport(IHubContext<ExportHub> exportHub)
        {
            _exportHub = exportHub;
        }

        public async Task ExportAllCsv<T, T1, T2>(IQueryable<T> data, string userName, ExportDto<T2> obj = null, bool all = true)
        {
            int i = 1;
            foreach (Task<byte[]> item in data.ExportToCSVE<T, GenericCsvClassMapper<T, T1>>(obj.Req))
            {
                try
                {
                    byte[] bytes = await item;
                    string FileName = typeof(T1).Name.Replace("Controller", "") + "_" + i + "_" + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
                    await _exportHub.Clients.Client(ExportHub.Connections[userName])
                                .SendAsync("csvRecevied", bytes, FileName);
                    i++;
                }
                catch (Exception)
                {
                    await _exportHub.Clients.Client(ExportHub.Connections[userName])
                                .SendAsync("csvErrorRecevied", i);

                }

            }
        }
    }
}

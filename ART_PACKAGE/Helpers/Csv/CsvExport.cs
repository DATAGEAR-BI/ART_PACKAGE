using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Linq.Expressions;

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
                    await _exportHub.Clients.Client(ExportHub.Connections[userName])
                                .SendAsync("csvRecevied", bytes, FileName);
                    i++;
                }
                catch (Exception ex)
                {
                    await _exportHub.Clients.Client(ExportHub.Connections[userName])
                                .SendAsync("csvErrorRecevied", i);

                }

            }
        }

    }
}

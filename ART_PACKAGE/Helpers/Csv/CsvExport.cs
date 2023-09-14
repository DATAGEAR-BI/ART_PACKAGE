using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ART_PACKAGE.Helpers.Csv
{
    public class CsvExport : ICsvExport
    {
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;
        public CsvExport(IHubContext<ExportHub> exportHub, UsersConnectionIds connections, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
        {
            _exportHub = exportHub;
            this.connections = connections;

        }
        public async Task Export<TModel, TController>(DbContext _db, string userName, ExportDto<object> obj) where TModel : class
        {
            DbSet<TModel> data = _db.Set<TModel>();
            await ExportAllCsv<TModel, TController, object>(data, userName, obj);

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
                    await _exportHub.Clients.Clients(connections.GetConnections(userName))
                                .SendAsync("csvRecevied", bytes, FileName);
                    i++;
                }
                catch (Exception)
                {
                    await _exportHub.Clients.Clients(connections.GetConnections(userName))
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
        public async Task ExportSelectedCsv<T, T1, T2>(IQueryable<T> data, Func<T, bool> crt, string userName, ExportDto<T2> obj = null, bool all = true)
        {
            IEnumerable<Task> tasks;
            int i = 1;
            if (obj.All)
            {
                tasks = data.ExportToCSVE<T, GenericCsvClassMapper<T, T1>>(obj.Req);
            }
            else
            {


                // Modify the LINQ expression to use Any and Contains
                tasks = data
                    .Where(x => crt(x))
                    .ExportToCSVE<T, GenericCsvClassMapper<T, T1>>(obj.Req);
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

    }
}

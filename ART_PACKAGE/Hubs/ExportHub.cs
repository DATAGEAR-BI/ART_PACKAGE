using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Controllers;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data.ECM;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Hubs
{
    public class ExportHub : Hub
    {
        private readonly AuthContext db;
        private readonly UsersConnectionIds connections;
        private readonly ICsvExport _csvSrv;
        private readonly EcmContext _db;
        private readonly SasAmlContext _dbAml;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;
        private readonly ArtDgAmlContext _dgaml;
        private readonly ArtAuditContext _dbAd;
        private readonly List<string>? modules;
        private readonly DBFactory dBFactory;
        private DbContext dbInstance;

        public ExportHub(UsersConnectionIds connections, ICsvExport csvSrv, EcmContext context, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory, DBFactory dBFactory, AuthContext db)
        {
            this.connections = connections;
            _csvSrv = csvSrv;
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
            modules = _configuration.GetSection("Modules").Get<List<string>>();
            if (modules.Contains("SASAML"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                SasAmlContext amlService = scope.ServiceProvider.GetRequiredService<SasAmlContext>();
                _dbAml = amlService;
            }
            if (modules.Contains("ECM"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                EcmContext ecmService = scope.ServiceProvider.GetRequiredService<EcmContext>();
                _db = ecmService;
            }
            if (modules.Contains("DGAML"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                ArtDgAmlContext dgamlService = scope.ServiceProvider.GetRequiredService<ArtDgAmlContext>();
                _dgaml = dgamlService;
            }
            if (modules.Contains("DGAUDIT"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                ArtAuditContext dgamlService = scope.ServiceProvider.GetRequiredService<ArtAuditContext>();
                _dbAd = dgamlService;
            }
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
            this.dBFactory = dBFactory;
            this.db = db;
        }
        public override Task OnConnectedAsync()
        {

            string? user = Context.User.Identity.Name;
            connections.AddConnctionIdFor(user, Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async Task KeepAlive()
        {
            await Clients.Caller.SendAsync("iAmAlive");
        }

        public async Task GetMissedFiles(string reqId, List<int> missedFiles)
        {
            await _csvSrv.ExportMissed(reqId, Context.User.Identity.Name, missedFiles);

        }

        public async Task ClearExportFolder(string reqId)
        {
            _csvSrv.ClearExportFolder(reqId);

        }

        public async Task Export(ExportDto<object> para, string controller, string method)
        {
            if (nameof(ReportController).ToLower().Replace("controller", "") == controller.ToLower())
            {
                if (method == "MyReports")
                {
                    await _csvSrv.Export<ArtSavedCustomReport, ReportController>(db, Context.User.Identity.Name, para);
                }
                else
                {
                    await ExportCustomReport(para);
                }

            }

            #region ECM
            if (nameof(SystemPerformanceController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtSystemPerformanceNcba, SystemPerformanceController>(_db, Context.User.Identity.Name, para);
            if (nameof(AlertedEntitiesController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAlertedEntity, AlertedEntitiesController>(_db, Context.User.Identity.Name, para);
            #endregion



        }


        private async Task ExportCustomReport(ExportDto<object> exportDto)
        {
            string orderBy = exportDto.Req.Sort is null ? null : string.Join(" , ", exportDto.Req.Sort.Select(x => $"{x.field} {x.dir}"));
            ArtSavedCustomReport? Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == exportDto.Req.Id);
            List<ArtSavedReportsChart> charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == exportDto.Req.Id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
            dbInstance = dBFactory.GetDbInstance(Report.Schema.ToString());
            string dbtype = dbInstance.Database.IsOracle() ? "oracle" : dbInstance.Database.IsSqlServer() ? "sqlServer" : "";
            string filter = exportDto.Req.Filter.GetFiltersString(dbtype);
            List<ChartData<dynamic>> chartsdata = charts is not null && charts.Count > 0 ? dbInstance.GetChartData(charts, filter) : null;
            ColumnsDto[] columns = Report.Columns.Select(x => new ColumnsDto
            {
                name = x.Column
            }).ToArray();

            List<List<object>> filterCells = exportDto.Req.Filter.GetFilterTextForCsv();

            DataResult data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, exportDto.Req.Take, exportDto.Req.Skip, orderBy);
            byte[] bytes = KendoFiltersExtentions.ExportCustomReportToCSV(data.Data, chartsdata?.Select(x => x.Data).ToList(), filterCells);
            string FileName = Report.Name + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
            await Clients.Clients(connections.GetConnections(Context.User.Identity.Name))
                                .SendAsync("csvRecevied", bytes, FileName);
        }


        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string? user = Context.User.Identity.Name;
            connections.RemoveConnection(user, Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}

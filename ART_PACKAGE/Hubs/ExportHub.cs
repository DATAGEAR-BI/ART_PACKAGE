using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Controllers;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data.ARTDGAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.SASAml;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static ART_PACKAGE.Helpers.CustomReport.DbContextExtentions;

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
            if (nameof(SystemPerformanceController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtSystemPerformance, SystemPerformanceController>(_db, Context.User.Identity.Name, para);
            if (nameof(UserPerformanceController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtUserPerformance, UserPerformanceController>(_db, Context.User.Identity.Name, para);
            if (nameof(AlertDetailsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAmlAlertDetailView, AlertDetailsController, long?>(_dbAml, Context.User.Identity.Name, para, nameof(ArtAmlAlertDetailView.AlertId));
            if (nameof(TriageController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAmlTriageView, TriageController, string>(_dbAml, Context.User.Identity.Name, para, nameof(ArtAmlTriageView.AlertedEntityNumber));
            if (nameof(CasesDetailsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAmlCaseDetailsView, CasesDetailsController>(_dbAml, Context.User.Identity.Name, para);
            if (nameof(CustomersController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAmlCustomersDetailsView, CustomersController>(_dbAml, Context.User.Identity.Name, para);
            if (nameof(RiskAssessmentController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtRiskAssessmentView, RiskAssessmentController>(_dbAml, Context.User.Identity.Name, para);
            if (nameof(HighRiskController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtAmlHighRiskCustView, HighRiskController>(_dbAml, Context.User.Identity.Name, para);
            if (nameof(ListOfUserController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfUser, ListOfUserController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListOfGroupsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfGroup, ListOfGroupsController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListOfRoleController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfRole, ListOfRoleController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListOfUsersAndGroupsRoleController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfUsersAndGroupsRole, ListOfUsersAndGroupsRoleController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListOfUsersGroupController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfUsersGroup, ListOfUsersGroupController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListOfUsersRolesController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfUsersRole, ListOfUsersRolesController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListGroupsRolesSummaryController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListGroupsRolesSummary, ListGroupsRolesSummaryController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListGroupsSubGroupsSummaryController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListGroupsSubGroupsSummary, ListGroupsSubGroupsSummaryController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(ListOfDeletedUsersController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ListOfDeletedUser, ListOfDeletedUsersController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(LastLoginPerDayController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<LastLoginPerDayView, LastLoginPerDayController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(AuditUsersController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtUsersAuditView, AuditUsersController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(AuditGroupsController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtGroupsAuditView, AuditGroupsController>(_dbAd, Context.User.Identity.Name, para);
            if (nameof(AuditRolesController).ToLower().Replace("controller", "") == controller.ToLower()) await _csvSrv.Export<ArtRolesAuditView, AuditRolesController>(_dbAd, Context.User.Identity.Name, para);

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

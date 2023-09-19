using ART_PACKAGE.Controllers;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data.ARTDGAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.SASAml;
using Microsoft.AspNetCore.SignalR;

namespace ART_PACKAGE.Hubs
{
    public class ExportHub : Hub
    {
        private readonly UsersConnectionIds connections;
        private readonly ICsvExport _csvSrv;
        private readonly EcmContext _db;
        private readonly SasAmlContext _dbAml;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;
        private readonly ArtDgAmlContext _dgaml;
        private readonly ArtAuditContext _dbAd;
        private readonly List<string>? modules;

        public ExportHub(UsersConnectionIds connections, ICsvExport csvSrv, EcmContext context, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
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


        public async Task Export(ExportDto<object> para, string controller)
        {
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

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string? user = Context.User.Identity.Name;
            connections.RemoveConnection(user, Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}

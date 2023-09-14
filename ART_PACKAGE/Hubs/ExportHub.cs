using ART_PACKAGE.Controllers;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data.ARTDGAML;
using Data.Data.ECM;
using Data.Data.FTI;
using Data.Data.SASAml;
using Microsoft.AspNetCore.SignalR;

namespace ART_PACKAGE.Hubs
{
    public class ExportHub : Hub
    {
        private readonly UsersConnectionIds connections;
        private readonly ICsvExport _csvSrv;
        private readonly EcmContext _ecm;
        private readonly SasAmlContext _dbAml;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;
        private readonly ArtDgAmlContext _dgaml;
        private readonly FTIContext _fti;
        private readonly List<string>? modules;

        public ExportHub(UsersConnectionIds connections, ICsvExport csvSrv, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
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
                _ecm = ecmService;
            }
            if (modules.Contains("DGAML"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                ArtDgAmlContext dgamlService = scope.ServiceProvider.GetRequiredService<ArtDgAmlContext>();
                _dgaml = dgamlService;
            }

            if (modules.Contains("FTI"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                FTIContext fticontext = scope.ServiceProvider.GetRequiredService<FTIContext>();
                _fti = fticontext;
            }
            _serviceScopeFactory = serviceScopeFactory;
            _configuration = configuration;
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
            if (nameof(SystemPerformanceController).ToLower().Replace("controller", "") == controller.ToLower())
                await _csvSrv.Export<ArtSystemPerformanceNcba, SystemPerformanceController>(_ecm, Context.User.Identity.Name, para);
        }


        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string? user = Context.User.Identity.Name;
            connections.RemoveConnection(user, Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}

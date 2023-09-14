using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data.ECM;
using Microsoft.AspNetCore.SignalR;

namespace ART_PACKAGE.Hubs
{
    public class ExportHub : Hub
    {
        private readonly UsersConnectionIds connections;
        private readonly ICsvExport _csvSrv;
        private readonly EcmContext context;

        public ExportHub(UsersConnectionIds connections, ICsvExport csvSrv, EcmContext context)
        {
            this.connections = connections;
            _csvSrv = csvSrv;
            this.context = context;
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
            await _csvSrv.Export(controller, Context.User.Identity.Name, para);
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string? user = Context.User.Identity.Name;
            connections.RemoveConnection(user, Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}

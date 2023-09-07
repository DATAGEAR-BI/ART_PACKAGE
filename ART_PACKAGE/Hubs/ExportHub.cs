using ART_PACKAGE.Helpers;
using Microsoft.AspNetCore.SignalR;

namespace ART_PACKAGE.Hubs
{
    public class ExportHub : Hub
    {
        private readonly UsersConnectionIds connections;

        public ExportHub(UsersConnectionIds connections)
        {
            this.connections = connections;
        }
        public override Task OnConnectedAsync()
        {

            string? user = Context.User.Identity.Name;
            connections.AddConnctionIdFor(user, Context.ConnectionId);
            return base.OnConnectedAsync();
        }


        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string? user = Context.User.Identity.Name;
            connections.RemoveConnection(user, Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}

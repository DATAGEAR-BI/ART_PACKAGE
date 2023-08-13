using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace ART_PACKAGE.Hubs
{

    public class AmlAnalysisHub : Hub
    {
        public static ConcurrentDictionary<string, string> Connections = new();
        public override Task OnConnectedAsync()
        {

            string? user = Context.User.Identity.Name;

            _ = Connections.AddOrUpdate(user, Context.ConnectionId, (key, oldValue) => Context.ConnectionId);

            return base.OnConnectedAsync();
        }
    }


}

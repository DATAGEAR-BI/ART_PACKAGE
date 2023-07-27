using Microsoft.AspNetCore.SignalR;

namespace ART_PACKAGE.Hubs
{
    public class LicenseHub : Hub
    {
        public async Task AlertMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveAlert", message);
        }


        public async Task ClearLiceMsg()
        {
            await Clients.All.SendAsync("ClrLiceMsg");
        }
    }
}

using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace eIdeas.Hubs
{
    public class SubscribeHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

using eIdeas.Areas.Identity.Data;
using eIdeas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace eIdeas.Hubs
{
    public class SubscribeHub : Hub
    {
        private readonly eIdeasUsersContext _context;
        private readonly UserManager<eIdeasUser> _userManager;
        private readonly SignInManager<eIdeasUser> _signInManager;


        public SubscribeHub(eIdeasUsersContext context, UserManager<eIdeasUser> userManager, SignInManager<eIdeasUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

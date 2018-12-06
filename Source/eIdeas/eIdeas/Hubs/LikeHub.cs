using eIdeas.Areas.Identity.Data;
using eIdeas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace eIdeas.Hubs
{
    public class LikeHub : Hub
    {
        private readonly eIdeasUsersContext _context;
        private readonly UserManager<eIdeasUser> _userManager;
        private readonly SignInManager<eIdeasUser> _signInManager;

        public LikeHub(eIdeasUsersContext context, UserManager<eIdeasUser> userManager, SignInManager<eIdeasUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task SendUpdateLike(string userId, string ideaId)
        {
            var user = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
            await Clients.All.SendAsync("RecieveUpdateLike", user, ideaId);
        }
    }
}

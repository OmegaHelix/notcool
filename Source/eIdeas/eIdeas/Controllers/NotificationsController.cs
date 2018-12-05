using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eIdeas.Data;
using eIdeas.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace eIdeas.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly IdeasContext _context;
        private readonly UserManager<eIdeasUser> _userManager;
        private readonly SignInManager<eIdeasUser> _signInManager;

        public NotificationsController(IdeasContext context, UserManager<eIdeasUser> userManager, SignInManager<eIdeasUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Notifications()
        {
            var notifications = from i in _context.Notifcation select i;
            var subscriptions = from i in _context.Subscribe select i;
            var user = await _userManager.GetUserAsync(User);
            List<Models.Notification> newlist = new List<Models.Notification>();

            subscriptions = subscriptions.Where(i => i.UserID.Equals(user.Id));
            foreach(var subscription in subscriptions)
            {
                foreach(var notification in notifications)
                {
                    if(subscription.IdeaID.Equals(notification.IdeaID))
                    {
                        newlist.Add(notification);
                    }
                }
            }
            return View(newlist);
        }


    }
}
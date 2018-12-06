using System.Linq;
using System.Threading.Tasks;
using eIdeas.Areas.Identity.Data;
using eIdeas.Data;
using eIdeas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eIdeas.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly IdeasContext _context;
        private readonly UserManager<eIdeasUser> _userManager;
        private readonly SignInManager<eIdeasUser> _signInManager;

        public SubscriptionsController(IdeasContext context, UserManager<eIdeasUser> userManager, SignInManager<eIdeasUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeToIdea([Bind("SubscriptionID,UserID,Subscribed,IdeaID")] Subscribe subscribe)
        {
            var user = await _userManager.GetUserAsync(User);
            subscribe.UserID = user.Id;
            string message = "";
            if (subscribe.Subscribed == true)
            {
                subscribe.Subscribed = false;
                message = user.Firstname + " " + user.Lastname + " has Unsubscribed to the idea: " + _context.Idea.Where(i => i.ID == subscribe.IdeaID).FirstOrDefault().Title;
            }
            else if (subscribe.Subscribed == false)
            {
                subscribe.Subscribed = true;
                message = user.Firstname + " " + user.Lastname + " has Subscribed to the idea: " + _context.Idea.Where(i => i.ID == subscribe.IdeaID).FirstOrDefault().Title;
            }
            if (ModelState.IsValid)
            {
                if (!_context.Subscribe.Any(e => e.UserID.Equals(user.Id) && e.IdeaID == subscribe.IdeaID))
                {
                    _context.Add(subscribe);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Subscribe.Update(subscribe);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SubscribeExists(subscribe.SubscriptionID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                Notification newNotification = new Notification
                {
                    IdeaID = subscribe.IdeaID,
                    UserID = subscribe.UserID,
                    Username = user.Firstname + " " + user.Lastname,
                    NotificationMessage = message,
                    NotificationDate = System.DateTime.Now
                };
                _context.Notifcation.Add(newNotification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IdeasController.Index), "Ideas");
            }
            return RedirectToAction(nameof(HomeController.Error), "Error");
        }


        private bool SubscribeExists(int id)
        {
            return _context.Subscribe.Any(e => e.SubscriptionID == id);
        }
    }
}
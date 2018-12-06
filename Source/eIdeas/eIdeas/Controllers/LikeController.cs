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
    public class LikeController : Controller
    {
        private readonly IdeasContext _context;
        private readonly UserManager<eIdeasUser> _userManager;
        private readonly SignInManager<eIdeasUser> _signInManager;

        public LikeController(IdeasContext context, UserManager<eIdeasUser> userManager, SignInManager<eIdeasUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> LikeIdea([Bind("LikeID,UserID,Liked,IdeaID")] Like like)
        {
            var user = await _userManager.GetUserAsync(User);
            var subscriptions = from i in _context.Subscribe select i;
            var idea = from i in _context.Idea select i;
            Idea userIdea;
            userIdea = await idea.Where(i => i.ID.Equals(like.IdeaID)).FirstOrDefaultAsync();
            subscriptions = subscriptions.Where(i => i.IdeaID.Equals(like.IdeaID) && i.Subscribed == true);
            like.UserID = user.Id;
            string message = "";
            if (like.Liked == true)
            {
                like.Liked = false;
                message = user.Firstname + " " + user.Lastname + " has unliked the idea: " + _context.Idea.Where(i => i.ID == like.IdeaID).FirstOrDefault().Title;
            }
            else if(like.Liked == false)
            {
                like.Liked = true;
                message = user.Firstname + " " + user.Lastname + " has liked the idea: " + _context.Idea.Where(i => i.ID == like.IdeaID).FirstOrDefault().Title;
            }
            if (ModelState.IsValid)
            {
                if (!_context.Like.Any(e => e.UserID.Equals(user.Id) && e.IdeaID == like.IdeaID))
                {
                    _context.Add(like);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Like.Update(like);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LikeExists(like.LikeID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                foreach (var subscription in subscriptions)
                {
                    Notification newNotification = new Notification
                    {
                        IdeaID = like.IdeaID,
                        UserID = like.UserID,
                        TargetUserID = subscription.UserID,
                        Username = userIdea.Name,
                        NotificationMessage = message,
                        Checked = false,
                        NotificationDate = System.DateTime.Now
                    };
                    _context.Notifcation.Add(newNotification);
                    
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IdeasController.Index), "Ideas");
            }
            return RedirectToAction(nameof(HomeController.Error), "Error");
        }
        

        private bool LikeExists(int id)
        {
            return _context.Like.Any(e => e.LikeID == id);
        }
    }
}
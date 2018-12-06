using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eIdeas.Data;
using eIdeas.Models;
using eIdeas.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Dynamic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eIdeas.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly IdeasContext _context;
        private readonly UserManager<eIdeasUser> _userManager;
        private readonly SignInManager<eIdeasUser> _signInManager;

        public CommentsController(IdeasContext context, UserManager<eIdeasUser> userManager, SignInManager<eIdeasUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> CreateComment([Bind("CommentID,IdeaID,UserID,UserComment")] Comment comment)
        {
            var user = await _userManager.FindByIdAsync(comment.UserID) ;
            var subscriptions = from i in _context.Subscribe select i;
            var idea = from i in _context.Idea select i;
            Idea userIdea;
            userIdea = await idea.Where(i => i.ID.Equals(comment.IdeaID)).FirstOrDefaultAsync();
            subscriptions = subscriptions.Where(i => i.IdeaID.Equals(comment.IdeaID) && i.Subscribed == true);
            comment.UserID = user.Id;
            comment.UserName = user.Firstname + " " + user.Lastname;
            string message = user.Firstname + " " + user.Lastname + " has commented on idea: " + _context.Idea.Where(i => i.ID == comment.IdeaID).FirstOrDefault().Title;
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                foreach (var subscription in subscriptions)
                {
                    Notification newNotification = new Notification
                    {
                        IdeaID = comment.IdeaID,
                        UserID = comment.UserID,
                        TargetUserID = subscription.UserID,
                        Username = userIdea.Name,
                        NotificationMessage = message,
                        Checked = false,
                        NotificationDate = System.DateTime.Now
                    };
                    _context.Notifcation.Add(newNotification);
                    
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IdeasController.Index),"Ideas");
            }
            return RedirectToAction(nameof(HomeController.Error), "Error");
        }

    }
}

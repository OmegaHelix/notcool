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

        // GET: /<controller>/
        public async Task<IActionResult> ViewComment(int ideaID)
        {
            var comments = from i in _context.Comment select i;
            comments = comments.Where(i => i.IdeaID.Equals(ideaID));
            return View(await comments.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([Bind("CommentID,IdeaID,UserID,UserComment")] Comment comment)
        {
            var user = await _userManager.GetUserAsync(User);
            comment.UserID = user.Id;
            comment.UserName = user.Firstname + " " + user.Lastname;
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IdeasController.Index),"Ideas");
            }
            return View(comment);
        }

    }
}

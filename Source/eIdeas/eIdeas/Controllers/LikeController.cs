using System;
using System.Collections.Generic;
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
            like.UserID = user.Id;
            
            if(like.Liked)
            {
                like.Liked = false;
            }
            else
            {
                like.Liked = true;
            }
            var thingy = "Nothing";
            //if (ModelState.IsValid)
            //{
                if(!_context.Like.Any(e => e.UserID.Equals(user.Id) && e.IdeaID == like.IdeaID))
                {
                thingy = "Add";
                    _context.Add(like);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                    thingy = "Update";
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
               
            bool stupid = _context.Like.Any(e => e.UserID.Equals(user.Id) && e.IdeaID == like.IdeaID);
            like.Liked = stupid;
            like.UserID = thingy;
            //return RedirectToAction(nameof(IdeasController.Index),"Ideas");
            return View(like);
            //}
            //return View(like);
        }
        

        private bool LikeExists(int id)
        {
            return _context.Like.Any(e => e.LikeID == id);
        }
    }
}
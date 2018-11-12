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
        public async Task<IActionResult> LikeIdea([Bind("LikeID,UserID,Liked,UserID")] Like like)
        {
            return RedirectToAction(nameof(IdeasController.Index));
        }
        

        private bool IdeaExists(int id)
        {
            return _context.Like.Any(e => e.LikeID == id);
        }
    }
}
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

namespace eIdeas.Controllers
{
    [Authorize]
    public class IdeasController : Controller
    {
        private readonly IdeasContext _context;
        private readonly UserManager<eIdeasUser> _userManager;
        private readonly SignInManager<eIdeasUser> _signInManager;

        public IdeasController(IdeasContext context, UserManager<eIdeasUser> userManager, SignInManager<eIdeasUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Ideas
        public async Task<IActionResult> Index(string searchFilter, string searchString)
        {
            var ideas = from i in _context.Idea select i;
            var comments = from i in _context.Comment select i;
            var likes = from i in _context.Like select i;
  
            if (!String.IsNullOrEmpty(searchFilter))
            {
                if(searchFilter.Equals("Pending") || searchFilter.Equals("Plan") || searchFilter.Equals("Do") ||
                    searchFilter.Equals("Check") || searchFilter.Equals("Act") || searchFilter.Equals("Park") ||
                    searchFilter.Equals("Abandon"))
                {
                    ideas = ideas.Where(i => i.Status.Contains(searchFilter));
                }
                if (searchFilter.Equals("ID"))
                {
                    ideas = ideas.Where(i => i.ID.ToString().Contains(searchString));
                }
                if (searchFilter.Equals("Subscribed"))
                {
                    //TODO Filter by subscriptions
                }
                if (searchFilter.Equals("TeamMember"))
                {
                    //TODO Filter by Team member
                }
                if (searchFilter.Equals("TeamName"))
                {
                    //TODO Filter by Team Name
                }

            }

            if (!String.IsNullOrEmpty(searchString) && searchFilter != "ID")
            {
                ideas = ideas.Where(i => i.Title.Contains(searchString));
            }

            List<IdeaViewModel> ideasModel = new List<IdeaViewModel>();
            foreach(var item in ideas)
            {
                var ideaComments = comments.Where(i => i.IdeaID.Equals(item.ID));
                var ideaLikes = likes.Where(i => i.IdeaID.Equals(item.ID));

                IdeaViewModel formattedIdea = new IdeaViewModel
                {
                    Idea = item,
                    Comments = await ideaComments.ToListAsync(),
                    Likes = await ideaLikes.ToListAsync()
                };

                ideasModel.Add(formattedIdea);
            }
            //List<Comment> commentsList = await comments.ToListAsync();
            //dynamic myModel = new ExpandoObject();
            //myModel.Ideas = await ideas.ToListAsync();
            //myModel.Comments = commentsList;
            //myModel.Likes = await likes.ToListAsync();
            return View(ideasModel);
        }

        // GET: Ideas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idea = await _context.Idea
                .FirstOrDefaultAsync(m => m.ID == id);
            if (idea == null)
            {
                return NotFound();
            }

            return View(idea);
        }

        // GET: Ideas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ideas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,UserID,Title,Problem,Solution,Status,Team,UploadDate")] Idea idea)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.Firstname != null)
            {
                idea.Name = user.Firstname + " " + user.Lastname;
            }
            else
            {
                idea.Name = "Anon";
            }
            idea.UserID = user.Id;
            idea.Status = "Pending";
            idea.Team = user.Team;
            idea.UploadDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(idea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(idea);
        }

        // GET: Ideas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idea = await _context.Idea.FindAsync(id);
            if (idea == null)
            {
                return NotFound();
            }
            return View(idea);
        }

        // POST: Ideas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,UserID,Title,Problem,Solution,Status,Team,UploadDate")] Idea idea)
        {
            var user = await _userManager.GetUserAsync(User);
            if (id != idea.ID)
            {
                return NotFound();
            }
            if (user.Firstname != null)
            {
                idea.Name = user.Firstname + " " + user.Lastname;
            }
            else
            {
                idea.Name = "Anon";
            }
            idea.UploadDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(idea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeaExists(idea.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(idea);
        }

        // GET: Ideas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idea = await _context.Idea
                .FirstOrDefaultAsync(m => m.ID == id);
            if (idea == null)
            {
                return NotFound();
            }

            return View(idea);
        }

        // POST: Ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var idea = await _context.Idea.FindAsync(id);
            _context.Idea.Remove(idea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdeaExists(int id)
        {
            return _context.Idea.Any(e => e.ID == id);
        }
    }
}

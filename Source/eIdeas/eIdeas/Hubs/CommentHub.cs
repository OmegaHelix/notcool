using eIdeas.Areas.Identity.Data;
using eIdeas.Data;
using eIdeas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;
using eIdeas.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace eIdeas.Hubs
{
    public class CommentHub : Hub
    {
        private readonly eIdeasUsersContext _context;
        private readonly UserManager<eIdeasUser> _userManager;
        private readonly SignInManager<eIdeasUser> _signInManager;
        private readonly IdeasContext _ideasContext;

        public CommentHub(eIdeasUsersContext context, UserManager<eIdeasUser> userManager, SignInManager<eIdeasUser> signInManager, IdeasContext ideasContext)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _ideasContext = ideasContext;
        }

        public async Task SendUpdateComment(string userId, string ideaId, string userComment)
        {
            var commentsController = new CommentsController(_ideasContext, _userManager, _signInManager);
            var user = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
            var comment = new Comment
            {
                IdeaID = Convert.ToInt32(ideaId),
                UserID = user.Id,
                UserComment = userComment,
                UserName = user.Firstname + " " + user.Lastname,
                UploadDate = System.DateTime.Now
            };
            
            await commentsController.CreateComment(comment);
            var getPic = "\"Photo\", \"eIdeasUser\" , new { UserId =" + userId + " }";
            await Clients.All.SendAsync("ReceiveUpdateComment", comment.UserName, ideaId, userComment, getPic);
        }
    }
}

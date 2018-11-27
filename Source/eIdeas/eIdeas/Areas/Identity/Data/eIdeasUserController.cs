using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eIdeas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace eIdeas.Areas.Identity.Data
{
    public class eIdeasUserController : Controller
    {
        private readonly eIdeasUsersContext _context;
        private readonly UserManager<eIdeasUser> _userManager;
        private readonly SignInManager<eIdeasUser> _signInManager;

        public eIdeasUserController(eIdeasUsersContext context, UserManager<eIdeasUser> userManager, SignInManager<eIdeasUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public FileContentResult Photo(String userId = "1fcd8510-61de-4280-a488-eb9b88a968a0")
        {
            
            var user =  _context.Users.Where(x => x.Id == userId).FirstOrDefault();
                return new FileContentResult(user.Picture, "image/jpeg");
        }
    }
}
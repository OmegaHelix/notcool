using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eIdeas.Areas.Identity.Data
{
    public class eIdeasUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<eIdeasUser, IdentityRole>
    {
        public eIdeasUserClaimsPrincipalFactory(
            UserManager<eIdeasUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
        }

        public async override Task<ClaimsPrincipal> CreateAsync(eIdeasUser user)
        {
            var principal = await base.CreateAsync(user);

            //Putting our Property to Claims
            //I'm using ClaimType.Email, but you may use any other or your own
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
        new Claim(ClaimTypes.GivenName, user.Firstname)
    });

            return principal;
        }
    }
}

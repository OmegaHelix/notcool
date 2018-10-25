using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eIdeas.Areas.Identity.Utilities
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetGivenName(this ClaimsPrincipal principal)
        {
            var GivenName = principal.Claims.FirstOrDefault(c => c.Type == "GivenName");
            return GivenName?.Value;
        }
    }
}

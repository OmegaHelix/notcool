using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eIdeas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace eIdeas.Data
{
     public class AppUserDbContext : IdentityDbContext<AppUser>
    {
        public AppUserDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

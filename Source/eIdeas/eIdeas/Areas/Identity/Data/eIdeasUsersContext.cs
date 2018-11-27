using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eIdeas.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eIdeas.Models
{
    public class eIdeasUsersContext : IdentityDbContext<eIdeasUser>
    {
        public eIdeasUsersContext(DbContextOptions<eIdeasUsersContext> options)
            : base(options)
        {
        }
        public DbSet<eIdeas.Areas.Identity.Data.eIdeasUser> Picture  { get; set; }
        public DbSet<eIdeas.Areas.Identity.Data.eIdeasUser> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

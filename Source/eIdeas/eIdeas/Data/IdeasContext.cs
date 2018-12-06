using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eIdeas.Models;

namespace eIdeas.Data
{
    public class IdeasContext : DbContext
    {
        public IdeasContext()
        {
        }

        public IdeasContext (DbContextOptions<IdeasContext> options)
            : base(options)
        {
        }

        public DbSet<eIdeas.Models.Idea> Idea { get; set; }
        public DbSet<eIdeas.Models.Like> Like { get; set; }
        public DbSet<eIdeas.Models.Comment> Comment { get; set; }
        public DbSet<eIdeas.Models.Subscribe> Subscribe { get; set; }
        public DbSet<eIdeas.Models.Notification> Notifcation { get; set; }
    }
}

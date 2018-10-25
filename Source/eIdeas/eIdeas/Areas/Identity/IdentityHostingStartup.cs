using System;
using eIdeas.Areas.Identity.Data;
using eIdeas.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(eIdeas.Areas.Identity.IdentityHostingStartup))]
namespace eIdeas.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<eIdeasUsersContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("eIdeasUsersContextConnection")));

               services.AddDefaultIdentity<eIdeasUser>()
                    .AddEntityFrameworkStores<eIdeasUsersContext>();
            });
        }
    }
}
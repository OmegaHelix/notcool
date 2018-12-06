using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eIdeas.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using eIdeas.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using eIdeas.Areas.Identity.Services;
using eIdeas.Hubs;

namespace eIdeas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();



            services.AddTransient<IEmailSender, eIdeasEmailSender>
                (
                    sender => new eIdeasEmailSender
                    (
                        Configuration["eIdeasEmailSender:Host"],
                        Configuration.GetValue<int>("eIdeasEmailSender:PortNum"),
                        Configuration.GetValue<bool>("eIdeasEmailSender:EnableSSL"),
                        Configuration["eIdeasEmailSender:EmailAddress"],
                        Configuration["eIdeasEmailSender:Password"]
                    )
                );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSignalR();

            services.AddDbContext<IdeasContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("IdeasContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseSignalR(routes =>
            {
                routes.MapHub<SubscribeHub>("/subscribeHub");
                routes.MapHub<LikeHub>("/likeHub");
                routes.MapHub<CommentHub>("/commentHub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Ideas}/{action=Index}/{id?}");
            });
        }
    }
}

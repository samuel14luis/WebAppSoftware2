using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppLuisMendozaSamuel.Data;
using WebAppLuisMendozaSamuel.Models;
using WebAppLuisMendozaSamuel.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace WebAppLuisMendozaSamuel
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            ////////////////////////////////////////////////
            services.AddLocalization(option => option.ResourcesPath = "Resource");
            services.AddMvc(option =>
            {
                option.CacheProfiles.Add("Default", new CacheProfile() { Duration = 06, Location = ResponseCacheLocation.Any });
                option.CacheProfiles.Add("Never", new CacheProfile() { Duration = 06, Location = ResponseCacheLocation.None, NoStore = true });

            }).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            ///////////////////////////
            app.UseIdentity();
            var cultures = new List<CultureInfo>();
            cultures.Add(new CultureInfo("en-US"));
            cultures.Add(new CultureInfo("es-PE"));

            var requestlocations = new RequestLocalizationOptions
            {
                SupportedCultures = cultures,
                SupportedUICultures = cultures,
                DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US"),
            };

            app.UseRequestLocalization(requestlocations);
            //////////////////////////////////
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

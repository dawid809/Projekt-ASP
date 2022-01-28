using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt_ASP.Enums;
using Projekt_ASP.Data;
using System.Text.Json.Serialization;

namespace Projekt_ASP
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
            services.AddControllersWithViews();
            //session
            services.AddSession();
            //Api
            services.AddSingleton<BasicAuthorizationFilter>();
            services.AddMvc()
                .AddMvcOptions(o => o.Filters.AddService<BasicAuthorizationFilter>())
                .AddJsonOptions(o => o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)
                .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddControllersWithViews();

            //Database
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration["Data:BookShop:IdentityConnectionString"]));
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            //Authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminAccess", policy => policy.RequireRole(Roles.Admin.ToString()));
                options.AddPolicy("SellerAccess", policy => policy.RequireRole(Roles.Manager.ToString()));
                options.AddPolicy("UsersAccess", policy => policy.RequireRole(Roles.User.ToString()));
            });

            //Models
            services.AddTransient<ICRUDBookRepository, CRUDBookRepository>();
            services.AddTransient<ICRUDAuthorRepository, CRUDAuthorRepository>();
            services.AddTransient<ICRUDCategoryRepository, CRUDCategoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Customer}/{action=Index}/{id?}");
            });
            IdentitySeedData.CreateUserRolesAndAssign(app);
            IdentitySeedData.SeedAllData(app);
        }
    }
}

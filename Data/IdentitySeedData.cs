using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Projekt_ASP;
using Projekt_ASP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public static class IdentitySeedData
    {
        private const string adminName = "admin";
        private const string adminPassword = "Admin123*";
        private const string adminEmail = "admin@gmail.com";

        private const string managerFirstname = "Dawid";
        private const string managerSurname = "Dziad";
        private const string managerName = "dawid";
        private const string managerPassword = "Dawid123*";
        private const string managerEmail = "dawid@gmail.com";

        private const string userFirstname = "Andrzej";
        private const string userSurname = "Duda";
        private const string userName = "endriu";
        private const string userPassword = "Endriu123*";
        private const string userEmail = "endriu@gmail.com";

        public static async void CreateUserRolesAndAssign(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var roleManager = (RoleManager<IdentityRole>)scope.ServiceProvider.GetRequiredService(typeof(RoleManager<IdentityRole>));
            var userManager = (UserManager<AppUser>)scope.ServiceProvider.GetRequiredService(typeof(UserManager<AppUser>));

            IdentityResult roleResult;

            foreach (var roleName in Enum.GetValues(typeof(Roles)))
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName.ToString());

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName.ToString()));
                }
            }

            AppUser adminUser = await userManager.FindByIdAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new AppUser()
                {
                    UserName = adminName,
                    Email = adminEmail,
                };
                await userManager.CreateAsync(adminUser, adminPassword);
            }
            await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());


            AppUser managerUser = await userManager.FindByIdAsync(managerEmail);
            if (managerUser == null)
            {
                managerUser = new AppUser()
                {
                    FirstName = managerFirstname,
                    LastName = managerSurname,
                    UserName = managerName,
                    Email = managerEmail,
                };
                await userManager.CreateAsync(managerUser, managerPassword);
            }
            await userManager.AddToRoleAsync(managerUser, Roles.Manager.ToString());

            AppUser normalUser = await userManager.FindByIdAsync(userEmail);
            if (normalUser == null)
            {
                normalUser = new AppUser()
                {
                    FirstName = userFirstname,
                    LastName = userSurname,
                    UserName = userName,
                    Email = userEmail,
                };
                await userManager.CreateAsync(normalUser, userPassword);
            }
            await userManager.AddToRoleAsync(normalUser, Roles.User.ToString());
        }

        public static async void SeedAllData(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var _context = scope.ServiceProvider.GetService<AppDbContext>();
                _context.Database.EnsureCreated();

                //if (!_context.Books.Any())
                //{
                //    _context.Books.AddRange(new List<Book>()
                //    {
                //        new Book()
                //        {
                //            Name = "adad",
                //            Author = "Jan",
                //            CategoryId = BookCategories.Dramat,
                //            PageCount = 111,
                //            ReleaseDate = 2018
                //        }
                //    } );
                //    _context.SaveChanges();
                //}
            }
        }
    }
}


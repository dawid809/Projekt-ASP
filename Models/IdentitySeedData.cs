using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public static class IdentitySeedData
    {
        private const string adminName = "admin";
        private const string adminSurname = "admin";
        private const string adminPassword = "Admin123*";
        private const string adminEmail = "admin@gmail.com";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = (UserManager<AppUser>)scope.
                    ServiceProvider.GetService(typeof(UserManager<AppUser>));
                AppUser user = await userManager.FindByIdAsync(adminEmail);
                {
                    if (user == null)
                    {
                        user = new AppUser
                            {
                            UserName = adminName,
                            FirstName = adminName,
                            LastName = adminSurname,
                            Email = adminEmail,
                            };
                        await userManager.CreateAsync(user, adminPassword);
                    }
                }
            }
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "admin";
        private const string adminPassword = "admin";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            //using (var scope = app.ApplicationServices.CreateScope())
            //    var userManager = (UserManager<IdentityUser>)scope.
            //        ServiceProvider.GetService(typeof UserManager<IdentityUser>));
            //IdentityUser user = await userManager.FindByIdAsync(adminUser);
            //{
            //    if (user == null)
            //    {
            //        user = new IdentityUser(adminUser);
            //        await userManager.CreateAsync(user, adminPassword);
            //    }
            //}
        }
    }
}

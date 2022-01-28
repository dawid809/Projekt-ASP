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

        public static void SeedAllData(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            // Seed Authors
            if (context.Authors.Any())
            {
                return;
            }

            var authors = new Author[]
            {
                new Author {FirstName = "Jan", Lastname = "Brzechwa"},
                new Author {FirstName = "Bolesław", Lastname = "Prus"},
                new Author {FirstName = "Aleksander", Lastname = "Kamiński"},
                new Author {FirstName = "Joseph", Lastname = "Conrad"},
                new Author {FirstName = "J.K.", Lastname = "Rowling"}
            };

            foreach (Author a in authors)
            {
                context.Authors.Add(a);
            }
            context.SaveChanges();

            // Seed Categories
            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
           {
                new Category {BookCategory = "Literatura dziecięca"},
                new Category {BookCategory = "Fikcja"},
                new Category {BookCategory = "Powieść historyczna"},
                new Category {BookCategory = "Biografia"},
                new Category {BookCategory = "Fantasy"},
                new Category {BookCategory = "Przygodowe"},
                new Category {BookCategory = "Akcja"},
                new Category {BookCategory = "Horror"}
           };

            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            // Seed Books
            if (context.Books.Any())
            {
                return;
            }

            var books = new Book[]
            {
                new Book { Name = "Akademia pana Kleksa",
                           Author = authors.FirstOrDefault(a => a.AuthorId == 1),
                           Category = categories.FirstOrDefault(c => c.CategoryId == 1),
                           PageCount = 136, ReleaseDate = 2013, Price = 15, Quantity = 6 },
                new Book { Name = "Lalka",
                           Author = authors.FirstOrDefault(a => a.AuthorId == 2),
                           Category = categories.FirstOrDefault(c => c.CategoryId == 2),
                           PageCount = 678, ReleaseDate = 2017, Price = 33, Quantity = 5 },
                new Book { Name = "Faraon",
                           Author = authors.FirstOrDefault(a => a.AuthorId == 2),
                           Category = categories.FirstOrDefault(c => c.CategoryId == 3),
                           PageCount = 400 , ReleaseDate = 2015, Price = 22, Quantity = 1 },
                new Book { Name = "Kamienie na szaniec",
                           Author = authors.FirstOrDefault(a => a.AuthorId == 3),
                           Category = categories.FirstOrDefault(c => c.CategoryId == 4),
                           PageCount = 256, ReleaseDate = 2013, Price = 17, Quantity = 7 },
                new Book { Name = "Jądro ciemności",
                           Author = authors.FirstOrDefault(a => a.AuthorId == 4),
                           Category = categories.FirstOrDefault(c => c.CategoryId == 2),
                           PageCount = 96, ReleaseDate = 2018, Price = 37, Quantity = 13 },
                new Book { Name = "Harry Potter i Kamień Filozoficzny",
                           Author = authors.FirstOrDefault(a => a.AuthorId == 5),
                           Category = categories.FirstOrDefault(c => c.CategoryId == 5),
                           PageCount = 323, ReleaseDate = 2016, Price = 41, Quantity = 3 },
                new Book { Name = "Harry Potter i Komnata Tajemnic",
                           Author = authors.FirstOrDefault(a => a.AuthorId == 5),
                           Category = categories.FirstOrDefault(c => c.CategoryId == 5),
                           PageCount = 358, ReleaseDate = 2016, Price = 29, Quantity = 2 },
                new Book { Name = "Harry Potter i więzień Azkabanu",
                           Author = authors.FirstOrDefault(a => a.AuthorId == 5),
                           Category = categories.FirstOrDefault(c => c.CategoryId == 5),
                           PageCount = 448, ReleaseDate = 2016, Price = 28, Quantity = 5 },
                new Book { Name = "Harry Potter i Czara Ognia",
                           Author = authors.FirstOrDefault(a => a.AuthorId == 5),
                           Category = categories.FirstOrDefault(c => c.CategoryId == 5),
                           PageCount = 768, ReleaseDate = 2016, Price = 33, Quantity = 1 },
                new Book { Name = "Harry Potter i Zakon Feniksa",
                           Author = authors.FirstOrDefault(a => a.AuthorId == 5),
                           Category = categories.FirstOrDefault(c => c.CategoryId == 5),
                           PageCount = 960, ReleaseDate = 2016, Price = 32, Quantity = 3 },
                new Book { Name = "Harry Potter i Książę Półkrwi",
                           Author = authors.FirstOrDefault(a => a.AuthorId == 5),
                           Category = categories.FirstOrDefault(c => c.CategoryId == 5),
                           PageCount = 704, ReleaseDate = 2016, Price = 25, Quantity = 7 }
            };

            foreach (Book b in books)
            {
                context.Books.Add(b);
            }
            context.SaveChanges();
        }

    }
}




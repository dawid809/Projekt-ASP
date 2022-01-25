using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    internal class OnModelCreating2
    {
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Author>().HasMany(c => c.Books)
        //.WithOne(e => e.Author).HasData(
        //        new Author
        //        {
        //            AuthorId = 1,
        //            FirstName = "Jan",
        //            Lastname = "Dzban"
        //        },
        //         new Author
        //         {
        //             AuthorId = 2,
        //             FirstName = "Tom",
        //             Lastname = "Kom"
        //         }
        //        );

        //    modelBuilder.Entity<Category>().HasData(
        //        new Category
        //        {
        //            CategoryId = 1,
        //            BookCategory = Enums.BookCategories.Dramat
        //        }
        //        );

        //    modelBuilder.Entity<Book>().HasMany(x => x.Author).HasData(
        //        new Book
        //        {
        //            BookId = 1,
        //            Name = "W p i p",
        //            ReleaseDate = 2015,
        //            PageCount = 211,
        //            Author = ,
        //            Category = 1
        //        }
        //        );
        //}
    }
}

using Microsoft.EntityFrameworkCore;
using Projekt_ASP.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [DisplayName("Kategoria książki")]
        [Required(ErrorMessage = "Podaj kategorie książki!")]
        [EnumDataType(typeof(BookCategories))]
        public BookCategories BookCategory { get; set; }

        public ICollection<Book> Books { get; set; }


        //internal static void ModelCreate(ModelBuilder builder)
        //{
        //    builder.Entity<Category>()
        //        .HasOne(x => x.Books)
        //        .WithOne(BookCategory);

        //    builder.Entity<User>()
        //        .HasIndex(a => a.Email)
        //        .IsUnique(true);

        //    builder.Entity<User>().HasData(
        //        new Category()
        //        {
        //        }
        //    );
        }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_ASP.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Category
    {
        [Key]
        [HiddenInput]
        public int CategoryId { get; set; }

        [DisplayName("Kategoria książki")]
        [Required(ErrorMessage = "Podaj kategorie książki!")]
        [EnumDataType(typeof(BookCategories))]
        [NotMapped]
        public BookCategories? BookCategory { get; set; }

        public ICollection<Book> Books { get; set; }

        public static void ModelCreate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(b => b.Books)
                .WithOne(c => c.Category)
                .HasForeignKey(k => k.BookId);
        }

        [Column("BookCategory")]
        public string BookCategoryString
        {
            get { return BookCategory.ToString(); }
            private set { BookCategory = value.ParseEnum<BookCategories>(); }
        }
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

    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}

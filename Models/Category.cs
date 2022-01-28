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
        [DisplayName("Id kategorii")]
        public int CategoryId { get; set; }

        [DisplayName("Kategoria książki")]
        [Required(ErrorMessage = "Podaj kategorie książki!")]
        public string BookCategory { get; set; }

        public ICollection<Book> Books { get; set; }

        public static void ModelCreate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(b => b.Books)
                .WithOne(c => c.Category);
        }
    }
}

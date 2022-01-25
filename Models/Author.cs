using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Display(Name = "Imie autora")]
        [Required(ErrorMessage = "Podaj imie autora!")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko autora")]
        [Required(ErrorMessage = "Podaj nazwisko autora!")]
        public string Lastname { get; set; }

        [Display(Name = "Imie i nazwisko autora")]
        public string FullName
        {
            get
            {
                return Lastname + ", " + FirstName;
            }
        }

        public ICollection<Book>Books { get; set; }

        public static void ModelCreate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(b => b.Books)
                .WithOne(a => a.Author);
                //.HasForeignKey(k => k.BookId);
        }
    }
}

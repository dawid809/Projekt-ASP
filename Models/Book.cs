﻿using Microsoft.AspNetCore.Mvc;
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

    public class Book
    {
        [Key]
        [HiddenInput]
        [DisplayName("Id książki")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Podaj nazwe książki!")]
        [DisplayName("Nazwa książki")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Podaj liczbe stron!")]
        [DisplayName("Liczba stron")]
        public short PageCount { get; set; }

        [Required(ErrorMessage = "Podaj date wydania książki!")]
        [DisplayName("Data wydania")]
        public short ReleaseDate { get; set; }

        [Required]
        public Author Author { get; set; }

        [Required]
        public Category Category { get; set; }

        public static void ModelCreate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(a => a.Author)
                .WithMany(b => b.Books);

            modelBuilder.Entity<Book>()
               .HasOne(c => c.Category)
               .WithMany(b => b.Books);
        }
    }
}

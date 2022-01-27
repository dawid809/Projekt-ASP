using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class AddBook
    {
        [Required(ErrorMessage = "Podaj nazwe książki!")]
        [DisplayName("Nazwa książki")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Podaj liczbe stron!")]
        [DisplayName("Liczba stron")]
        public short PageCount { get; set; }

        [Required(ErrorMessage = "Podaj date wydania książki!")]
        [DisplayName("Data wydania")]
        public short ReleaseDate { get; set; }

        [Required(ErrorMessage = "Podaj imie autora!")]
        [DisplayName("Imie autora")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Podaj nazwisko autora!")]
        [DisplayName("Nazwisko autora")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Wybierz kategorie książki!")]
        [DisplayName("Kategoria książki")]
        public int CategoryId { get; set; }
    }
}

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
        [Required(ErrorMessage = "Podaj nazwe książki!")]
        [DisplayName ("Nazwa książki")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Podaj autora książki!")]
        [DisplayName ("Autor")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Podaj liczbe stron!")]
        [DisplayName ("Liczba stron")]
        public int PageCount { get; set; }
        public DateTime BookDate { get; set; }
    }
}

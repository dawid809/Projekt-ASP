using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        [Display(Name = "Imie")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        [Required]
        public string Surname { get; set; }
    }
}

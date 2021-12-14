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
    }
}

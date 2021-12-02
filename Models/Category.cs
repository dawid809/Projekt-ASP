using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Category
    {
        public enum BookCategory
        {
            Dramat = 1,
            Comedy= 2,
            Adventure = 3
        }

        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Podaj kategorie książki!")]
        [EnumDataType(typeof(BookCategory))]
        public BookCategory bookCategory { get; set; }
    }
}

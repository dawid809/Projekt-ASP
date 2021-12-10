using Projekt_ASP.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Podaj kategorie książki!")]
        [EnumDataType(typeof(BookCategories))]
        public BookCategories BookCategory { get; set; }
    }
}

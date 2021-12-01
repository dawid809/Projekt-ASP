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
            Dramat,
            Comedy,
            Adventure
        }

        public int CategoryId { get; set; }
        [Required]
        public BookCategory bookCategory { get; set; }
    }
}

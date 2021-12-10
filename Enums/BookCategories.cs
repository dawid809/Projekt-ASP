using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Enums
{
    public enum BookCategories
    {
        Dramat = 1,
        Comedy = 2,
        Adventure = 3,
        Action = 4,
        Horror = 5,
        Fantasy = 6,
        Classic = 7,
        Detective = 8,
        Mystery =  9, 
        Romance = 10,
        [Display(Name = "Science Fiction")]
        ScienceFiction = 11,
        Thriller = 12,
        History = 13
    }
}

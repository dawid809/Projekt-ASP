using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Podaj login!")]
        [Display(Name = "Login")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Podaj hasło!")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Podaj imię!")]
        [DataType(DataType.Text)]
        [Display(Name = "Imie")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Podaj nazwisko!")]
        [DataType(DataType.Text)]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Podaj hasło!")]
        [DataType(DataType.Password)]
        [MinLength(length: 4, ErrorMessage = "Hasło musi mieć co najmiej 4 znaki!")]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Podaj ponownie hasło!")]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasła się nie zgadzają!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Podaj adres email!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Imie i nazwisko")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}

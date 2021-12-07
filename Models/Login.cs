using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class Login
    {
        public int UserId { get; set; }
        [Required]
        [MinLength(length: 4, ErrorMessage = "Login musi mieć co najmiej 4 znaki")]
        public string Name { get; set; }
        [Required]
        [UIHint("password")]
        [DataType(DataType.Password)]
        [MinLength(length: 4, ErrorMessage = "Hasło musi mieć co najmiej 4 znaki")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }
        //public string Name { get; set; }
        //public string Surname { get; set; }
        //public int Age { get; set; }
    }
}

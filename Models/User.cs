using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class User
    {
        public int UserId { get; set; }
        [MinLength(length: 4, ErrorMessage = "Login musi mieć co najmiej 4 znaki")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [MinLength(length: 6, ErrorMessage = "Hasło musi mieć co najmiej 6 znaków")]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}

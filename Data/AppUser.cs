using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class AppUser : IdentityUser
    {

        public AppUser() : base() { }

        //[PersonalData]
        //[Column(TypeName = "nvarchar(30)")]
        public string FirstName { get; set; }

        //[PersonalData]
        //[Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; }

    }
}

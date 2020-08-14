using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NamibianFA.Domain.Entities
{
    public class User : IdentityUser
    {
        public User() { }
        public User(string name, string surname, string email)
        {
            FirstName = name;
            Surname = surname;
            Email = email;
        }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}

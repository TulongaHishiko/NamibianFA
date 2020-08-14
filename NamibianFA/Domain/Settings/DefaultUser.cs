using NamibianFA.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFA.Domain.Settings
{
    public class DefaultUser
    {
        public DefaultUser(string name, string surname, UserRoleEnum role, string email, string password)
        {
            FirstName = name;
            Surname = surname;
            Email = email;
            Password = password;
            Role = role;
        }
        public string FirstName { get; set; }
        public UserRoleEnum Role { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

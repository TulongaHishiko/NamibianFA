using NamibianFA.Domain.Abstract;
using NamibianFA.Domain.Entities;
using NamibianFA.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFA.Core.Configurations
{
    public static class SeedData
    {
        public static List<DefaultUser> DefaultUserSeed()
        {
            return new List<DefaultUser>
            {
                new DefaultUser("Admin","",UserRoleEnum.Administrator,"admin@email.com","iamadmin"),
                new DefaultUser("Manager","",UserRoleEnum.Manager,"manager@email.com","iammanager")
            };
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFA.Domain.Settings
{
    public class DatabaseSettings
    {
        public static string LocalConnection => "Server=THISHIKO-LT;Database=NamibianFADB;Trusted_Connection=True;MultipleActiveResultSets=true;";
        public static string ServerConnection => "";
        public static string IdentityLocalConnection => "Server=THISHIKO-LT;Database=NamibianFAIdentityDB;Trusted_Connection=True;MultipleActiveResultSets=true;";
        public static string IdentityServerConnection => "";

    }
}

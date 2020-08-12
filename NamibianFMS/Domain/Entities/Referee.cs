using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFMS.Domain.Entities
{
    public class Referee:Person
    {
        public string LicenseNumber { get; set; }
        public int YearsExperience { get; set; }
    }
}

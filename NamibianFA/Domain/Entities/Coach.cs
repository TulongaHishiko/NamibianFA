using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFA.Domain.Entities
{
    public class Coach:Person
    {
        public string LicenseNumber { get; set; }
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}

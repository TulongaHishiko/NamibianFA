using NamibianFA.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFA.Domain.Entities
{
    public class TeamCoach:BaseEntity
    {
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }
        public Guid CoachId { get; set; }
        public virtual Coach Coach { get; set; }
        public DateTime ContractStart { get; set; }
        public DateTime ContractEnd { get; set; }
    }
}

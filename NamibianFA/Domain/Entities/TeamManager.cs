using NamibianFA.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFA.Domain.Entities
{
    public class TeamManager:BaseEntity
    {
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }
        public Guid ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
        public DateTime ContractStart { get; set; }
        public DateTime ContractEnd { get; set; }
        public int GamesWon { get; set; }
        public int GamesDraw { get; set; }
        public int GamesLost { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFMS.Domain.Entities
{
    public class Player:Person
    {
        public int ShirtNumber { get; set; }
        public double Height { get; set; }
        public string Position { get; set; }
        public int GamesPlayed { get; set; }
        public int Goals { get; set; }
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}

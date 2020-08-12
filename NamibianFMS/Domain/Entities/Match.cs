using NamibianFMS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFMS.Domain.Entities
{
    public class Match:BaseEntity
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public Guid VenueId { get; set; }
        public virtual Stadium Venue { get; set; }
        public Guid RefereeId { get; set; }
        public virtual Referee Referee { get; set; }
    }
}

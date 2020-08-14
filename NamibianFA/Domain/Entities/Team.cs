using NamibianFA.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFA.Domain.Entities
{
    public class Team:BaseEntity
    {
        public string Name { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesDraw { get; set; }
        public int GamesLoss { get; set; }
        public int TotalGoals { get; set; }
        public int Cleansheets { get; set; }
        public int Conceded { get; set; }
        public DateTime YearFounded { get; set; }
        public Guid TeamLogoId { get; set; }
        public virtual DocumentStore TeamLogo { get; set; }
        public Guid StadiumId { get; set; }
        public virtual Stadium Stadium { get; set; }
    }
}

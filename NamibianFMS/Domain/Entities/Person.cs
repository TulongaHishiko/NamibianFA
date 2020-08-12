using NamibianFMS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFMS.Domain.Entities
{
    public abstract class Person:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string Nationality { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public Guid PictureId { get; set; }
        public virtual DocumentStore Picture { get; set; }
    }
}

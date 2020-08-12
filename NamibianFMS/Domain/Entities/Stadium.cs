using NamibianFMS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFMS.Domain.Entities
{
    public class Stadium:BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
        public string SurfaceType { get; set; }
    }
}

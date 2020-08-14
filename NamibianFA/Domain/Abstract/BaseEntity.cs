using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFA.Domain.Abstract
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            AddedDate = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool isDeleted { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}

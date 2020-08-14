using NamibianFA.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFA.Domain.Entities
{
    public class DocumentStore : BaseEntity
    {
        public DocumentStore() : base() { }
        public DocumentStore(string fileName) : base()
        {
            FileName = fileName;
            isDeleted = false;
        }
        public DocumentStore(string fileName, byte[] content)
        {
            FileName = fileName;
            Content = content;
            isDeleted = false;
        }
        public string FileName { get; set; }
        public byte[] Content { get; set; }

    }
}

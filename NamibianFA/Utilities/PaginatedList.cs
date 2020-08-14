using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFA.Utilities
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int pageIndex, int pageSize)
        {
            int count = items.Count();
            var pageItems = items.Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();
            PageIndex = pageIndex;
            this.AddRange(pageItems);
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
    }
}

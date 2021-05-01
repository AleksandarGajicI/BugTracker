using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.requests
{
    public class PagedQuery
    {
        public int? PageSize { get; set; }
        public int? PageNum { get; set; }

        public PagedQuery()
        {
            PageSize = 3;
            PageNum = 1;
        }

        public PagedQuery(int pageSize, int pageNum)
        {
            PageSize = pageSize;
            PageNum = pageNum > 100? 50 : pageNum;
        }
    }
}

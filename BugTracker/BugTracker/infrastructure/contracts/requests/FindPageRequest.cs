using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.requests
{
    public class FindPageRequest
    {
        public int PageSize { get; set; }
        public int PageNum { get; set; }

        public FindPageRequest(int pageSize = 3, int pageNum = 0)
        {
            PageSize = pageSize;
            PageNum = pageNum;
        }
    }
}

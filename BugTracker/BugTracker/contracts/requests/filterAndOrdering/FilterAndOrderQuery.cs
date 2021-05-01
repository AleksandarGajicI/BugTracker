using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.requests.filterAndOrdering
{
    public class FilterAndOrderQuery
    {
        public FilterAndOrderQuery()
        {
            Filters = new List<Filter>();
        }

        public IEnumerable<Filter> Filters { get; set; }
        public string OrderBy { get; set; }
    }
}

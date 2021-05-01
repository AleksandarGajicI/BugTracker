using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.requests.filterAndOrdering
{
    public class Filter
    {
        public string FilterProperty { get; set; }
        public string Value { get; set; }

    }
}

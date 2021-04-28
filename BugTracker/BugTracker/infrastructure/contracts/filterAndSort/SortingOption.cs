using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.filterAndSort
{
    public class SortingOption<TSortingOption>
        where TSortingOption: struct, IConvertible
    {
        public TSortingOption Option { get; set; }
        public string Value { get; set; }
    }
}

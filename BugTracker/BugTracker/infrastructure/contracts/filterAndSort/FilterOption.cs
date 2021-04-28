using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.filterAndSort
{
    public class FilterOption<TFilterOption>
        where TFilterOption : struct, IConvertible
    {
        public TFilterOption Option { get; set; }
        public string Value { get; set; }
    }
}

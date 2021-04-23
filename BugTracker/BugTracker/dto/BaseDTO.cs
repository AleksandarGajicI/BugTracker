using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.dto
{
    public interface BaseDTO
    {
        public Guid Id { get; set; }
    }
}

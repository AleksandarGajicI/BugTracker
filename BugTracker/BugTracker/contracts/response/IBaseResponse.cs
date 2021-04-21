using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.response
{
    public interface IBaseResponse
    {
        public ICollection<string> Errors { get; set; }
        public bool Success { get; set; }

    }
}

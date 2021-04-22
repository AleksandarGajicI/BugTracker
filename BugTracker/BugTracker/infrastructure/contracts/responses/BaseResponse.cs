using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.responses
{
    public class BaseResponse
    {
        public ICollection<string> Errors { get; set; }
        public bool Success { get; set; }

        public BaseResponse()
        {
            Errors = new List<string>();
        }
    }
}

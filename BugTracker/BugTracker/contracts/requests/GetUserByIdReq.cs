using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.requests
{
    public class GetUserByIdReq
    {
        public Guid UserId { get; set; }
    }
}

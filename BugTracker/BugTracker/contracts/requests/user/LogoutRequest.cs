using BugTracker.infrastructure.contracts.requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.requests.user
{
    public class LogoutRequest : BaseRequest
    {
        public string UserName { get; set; }
    }
}

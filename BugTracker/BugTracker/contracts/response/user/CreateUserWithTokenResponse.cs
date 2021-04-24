using BugTracker.dto;
using BugTracker.infrastructure.contracts.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.response.user
{
    public class CreateUserWithTokenResponse : CreateResponse<UserDTO>
    {
        public string BugTrackerToken { get; set; }
    }
}

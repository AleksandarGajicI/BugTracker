using BugTracker.infrastructure.contracts.requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.requests.user
{
    public class UpdateUserRequest : BaseRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

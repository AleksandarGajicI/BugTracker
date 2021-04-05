using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class UserAssignedRequest
    {
        public Guid Id { get; set; }

        public DateTime RequestSent { get; set; }

        public bool Accepted { get;     set; }

        public string Message { get; set; }

        public Project Project { get; set; }

        public User UserAssigned { get; set; }

        public Role Role { get; set; }
    }
}

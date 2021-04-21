using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.response.user
{
    public class FindAllUsersResponse : IBaseResponse
    {
        public ICollection<string> Errors { get; set; }
        public bool Success { get; set; }

        public IReadOnlyList<User> Users { get; set; }
    }
}

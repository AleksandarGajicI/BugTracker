using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.contracts.response.user
{
    public class FindUserByIdResponse : IBaseResponse
    {
        public ICollection<string> Errors { get; set; }
        public bool Success { get; set; }

        public User User { get; set; }
    }
}

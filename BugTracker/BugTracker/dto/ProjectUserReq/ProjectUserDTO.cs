using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.dto
{
    public class ProjectUserDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string InvitedBy { get; set; }
        public string Role { get; set; }
        public DateTime InvitedAt { get; set; }
    }
}

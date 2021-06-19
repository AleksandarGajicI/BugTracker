using System;

namespace BugTracker.dto
{
    public class RoleDTO : BaseDTO
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}

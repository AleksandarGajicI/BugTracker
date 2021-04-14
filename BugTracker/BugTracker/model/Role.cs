using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.model
{
    public class Role
    {   
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

    }
}

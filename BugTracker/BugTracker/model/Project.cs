using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }

        public bool Closed { get; set; }

        public User owner { get; set; }


    }
}

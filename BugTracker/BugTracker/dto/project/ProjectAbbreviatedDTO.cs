using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.dto.project
{
    public class ProjectAbbreviatedDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
    }
}

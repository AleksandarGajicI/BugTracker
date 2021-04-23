using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.dto.ProjectUserReq
{
    public class ProjectUserRequestDTO : ProjectUserDTO
    {
        public string Message { get; set; }
        public string status { get; set; }
    }
}

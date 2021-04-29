using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.database.config
{
    public class Triggers
    {
        public const string DisableProjectManagerTrigger =
            "disable trigger dbo.TR_DEL_UPD_project_user_req  on dbo.ProjectUserRequests";

        public const string EnableProjectManagerTrigger =
            "enable trigger dbo.TR_DEL_UPD_project_user_req  on dbo.ProjectUserRequests";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.responses
{
    public class DeleteResponse : ResponseBase
    {
        public Guid IdDeleted { get; set; }

        public DeleteResponse()
            : base()
        {
        }
    }
}

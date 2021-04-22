using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.responses
{
    public class CreateResponse<T> : BaseResponse
        where T : EntityBase
    {
        public T Entity { get; set; }

        public CreateResponse()
            : base()
        { 
        }
    }
}

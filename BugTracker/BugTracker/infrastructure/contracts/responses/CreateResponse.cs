using BugTracker.dto;
using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.responses
{
    public class CreateResponse<T> : ResponseBase
        where T : BaseDTO
    {
        public T EntityDTO { get; set; }

        public CreateResponse()
            : base()
        { 
        }
    }
}

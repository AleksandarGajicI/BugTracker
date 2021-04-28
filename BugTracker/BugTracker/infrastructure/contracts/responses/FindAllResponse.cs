using BugTracker.dto;
using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.responses
{
    public class FindAllResponse<T> : ResponseBase
        where T : BaseDTO
    {
        public ICollection<T> FoundEntitiesDTO { get; set; }

        public FindAllResponse()
            : base()
        { 
        
        }
    }
}

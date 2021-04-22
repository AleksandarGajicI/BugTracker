using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.responses
{
    public class FindAllResponse<T> : BaseResponse
        where T : EntityBase
    {
        public ICollection<T> FoundEntities { get; set; }

        public FindAllResponse()
            : base()
        { 
        
        }
    }
}

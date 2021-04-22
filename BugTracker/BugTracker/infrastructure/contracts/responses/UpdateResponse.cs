using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.contracts.responses
{
    public class UpdateResponse<T> : BaseResponse
        where T : EntityBase
    {
        public T UpdatedEntity { get; set; }

        public UpdateResponse()
            : base()
        {
        }
    }
}

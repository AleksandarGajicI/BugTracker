using BugTracker.dto;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.services
{
    public interface IPersistanceService<T, TCreate, TUpdate>
        where T : BaseDTO 
        where TCreate : RequestBase
        where TUpdate : RequestBase
    {
        public CreateResponse<T> Create(TCreate req);
        public DeleteResponse Delete(DeleteRequest req);
        public UpdateResponse<T> Update(TUpdate req);
    }
}

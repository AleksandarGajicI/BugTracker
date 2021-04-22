using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.services
{
    public interface IPersistanceService<T>
        where T : EntityBase
    {
        public CreateResponse<T> Create(CreateRequest<T> req);
        public DeleteResponse Delete(DeleteRequest req);
        public UpdateResponse<T> Update(UpdateRequest<T> req);
    }
}

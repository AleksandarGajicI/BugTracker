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
    public interface IReadOnlyService<T, TById>
        where T : BaseDTO
        where TById : BaseDTO
    {
        public FindAllResponse<T> FindAll();
        public FindByIdResponse<TById> FindById(FindByIdRequest req);
    }
}

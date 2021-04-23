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
    public interface IReadOnlyService<T>
        where T : BaseDTO
    {
        public FindAllResponse<T> FindAll();
        public FindByIdResponse<T> FindById(FindByIdRequest req);
        public FindPageResponse<T> FindPage(FindPageRequest req);
    }
}

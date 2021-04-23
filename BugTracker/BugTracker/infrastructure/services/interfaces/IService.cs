using BugTracker.dto;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.services
{
    public interface IService<T, TById, TCreate, TUpdate> : IReadOnlyService<T, TById>, IPersistanceService<T, TCreate, TUpdate>
        where T : BaseDTO
        where TCreate : BaseRequest
        where TUpdate : BaseRequest
        where TById : BaseDTO
    {
    }
}

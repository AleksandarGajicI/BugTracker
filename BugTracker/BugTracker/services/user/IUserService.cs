using BugTracker.contracts.requests.user;
using BugTracker.dto;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.services;
using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.user
{
    public interface IUserService : IService<UserDTO, CreateUserRequest, UpdateUserRequest>
    {
    }
}

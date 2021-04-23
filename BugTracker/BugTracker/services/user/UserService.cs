using BugTracker.contracts.requests.user;
using BugTracker.database;
using BugTracker.dto;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.repository;
using BugTracker.infrastructure.services;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.user
{
    public class UserService : IUserService
    {
        public CreateResponse<UserDTO> Create(CreateUserRequest req)
        {
            throw new NotImplementedException();
        }

        public DeleteResponse Delete(DeleteRequest req)
        {
            throw new NotImplementedException();
        }

        public FindAllResponse<UserDTO> FindAll()
        {
            throw new NotImplementedException();
        }

        public FindByIdResponse<UserDTO> FindById(FindByIdRequest req)
        {
            throw new NotImplementedException();
        }

        public FindPageResponse<UserDTO> FindPage(FindPageRequest req)
        {
            throw new NotImplementedException();
        }

        public UpdateResponse<UserDTO> Update(UpdateUserRequest req)
        {
            throw new NotImplementedException();
        }
    }
}

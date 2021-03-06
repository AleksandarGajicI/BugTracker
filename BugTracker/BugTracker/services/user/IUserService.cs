using BugTracker.contracts.requests.filterAndOrdering;
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
    public interface IUserService : IService<UserDTO, UserDTO, RegisterUserRequest, UpdateUserRequest>
    {
        public ResponseBase Logout(LogoutRequest req);

        public LoginResponse Login(LoginRequest req);

        public DeleteResponse Delete(DeleteRequest req, string userId);

        public PagedResponse<UserDTO> GetPage(string userId, PagedQuery pageQuery, FilterAndOrderQuery filterAndOrderQuery);

    }
}

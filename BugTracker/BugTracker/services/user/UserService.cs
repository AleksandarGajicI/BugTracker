using BugTracker.contracts.requests.user;
using BugTracker.database;
using BugTracker.dto;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.repository;
using BugTracker.infrastructure.services;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using BugTracker.repositories.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.user
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public CreateResponse<UserDTO> Create(CreateUserRequest req)
        {
            var res = new CreateResponse<UserDTO>();
            var user = new User(req.Email, req.UserName, req.FirstName, req.LastName);

            user.Validate();
            if (user.GetBrokenRules().Count > 0) 
            {
                foreach (var brokenRule in user.GetBrokenRules())
                {
                    res.Errors.Add(brokenRule.Rule);
                    res.Success = false;
                    return res;
                }
            }
            res.Success = true;
            //map user to DTO
            return res;
        }

        public DeleteResponse Delete(DeleteRequest req)
        {
            throw new NotImplementedException();
        }

        public FindAllResponse<UserDTO> FindAll()
        {
            var res = new FindAllResponse<UserDTO>();
            var users = _userRepository.FindAll();
            //map to DTO!
            res.Success = true;
            return res;
        }

        public FindByIdResponse<UserDTO> FindById(FindByIdRequest req)
        {
            var res = new FindByIdResponse<UserDTO>();
            var user = _userRepository.FindById(req.Id);

            if (user == null)
            {
                res.Errors.Add("User not found");
                res.Success = false;
                return res;
            }

            //map to DTO!
            res.Success = true;
            return res;
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

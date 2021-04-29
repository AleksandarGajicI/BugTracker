using AutoMapper;
using BugTracker.auth.service;
using BugTracker.contracts.requests.user;
using BugTracker.contracts.response.user;
using BugTracker.dto;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using BugTracker.repositories.user;
using System;
using System.Collections.Generic;
using BugTracker.helpers;

namespace BugTracker.services.user
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IAuthService _authService;

        public UserService(IUserRepository userRepository,
                            IMapper mapper, 
                            IUnitOfWork uow,
                            IAuthService authService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _uow = uow;
            _authService = authService;
        }
        public CreateResponse<UserDTO> Create(RegisterUserRequest req)
        {
            var res = new CreateUserWithTokenResponse();
                


            var user = new User(req.Email, req.UserName, req.FirstName, req.LastName);

            user.Validate();

            if (user.GetBrokenRules().Count > 0)
            {
                return (CreateUserWithTokenResponse)res.ReturnErrorResponseWithMultiple(user.GetBrokenRules());
            }

            var userExists = _authService.FindByEmailOrUserName(req.Email, req.UserName).GetAwaiter().GetResult();

            if (userExists)
            {
                return (CreateUserWithTokenResponse)
                    res.ReturnErrorResponseWith("User with the given user name or email already exists");
            }

            string token;
            try
            {
                token = _authService.Register(user.UserName, user.Email, req.Password).Result;
            }
            catch (Exception ex)
            {
                return (CreateUserWithTokenResponse) res.ReturnErrorResponseWith(ex.Message);
            }

            _userRepository.Save(user);

            try
            {
                _uow.Commit();
            }
            catch (Exception ex)
            {
                _authService.DeleteUser(user.UserName);

                return (CreateUserWithTokenResponse) res.ReturnErrorResponseWith(ex.Message);
            }
            
            res.Success = true;
            res.BugTrackerToken = token;
            res.EntityDTO = _mapper.Map<User, UserDTO>(user);

            return res;
        }

        public DeleteResponse Delete(DeleteRequest req)
        {
            var res = new DeleteResponse();

            var user = _userRepository.FindById(req.Id);

            if (user == null)
            {
                return (DeleteResponse) res.ReturnErrorResponseWith("User not found!");
            }

            try
            {
                _userRepository.Delete(user);
                _uow.Commit();
            }
            catch (Exception ex)
            {
                return (DeleteResponse) res.ReturnErrorResponseWith(ex.Message);
            }

            _authService.DeleteUser(user.UserName);

            res.Success = true;
            res.IdDeleted = req.Id;
            return res;
        }

        public FindAllResponse<UserDTO> FindAll()
        {
            var res = new FindAllResponse<UserDTO>();
            var users = _userRepository.FindAll();
            res.FoundEntitiesDTO =
                _mapper.Map<IEnumerable<User>, ICollection<UserDTO>>(users);
            res.Success = true;
            return res;
        }

        public FindByIdResponse<UserDTO> FindById(FindByIdRequest req)
        {
            var res = new FindByIdResponse<UserDTO>();
            var user = _userRepository.FindById(req.Id);

            if (user == null)
            {
                return (FindByIdResponse<UserDTO>) res.ReturnErrorResponseWith("User not found");
            }

            res.EntityDTO = _mapper.Map<User, UserDTO>(user);
            res.Success = true;
            return res;
        }

        public ResponseBase Logout(LogoutRequest req)
        {
            var res = new ResponseBase();

            _authService.Logout(req.UserName);
            res.Success = true;
            return res;
        }

        public UpdateResponse<UserDTO> Update(UpdateUserRequest req)
        {
            var res = new UpdateResponse<UserDTO>();
            var user = _userRepository.FindById(req.Id);

            if (user == null)
            {
                return (UpdateResponse<UserDTO>) res.ReturnErrorResponseWith("User not found");
            }

            if (req.FirstName == null || req.LastName == null)
            {
                return (UpdateResponse<UserDTO>) res.ReturnErrorResponseWith("Bad request");
            }

            user.FirstName = req.FirstName;
            user.LastName = req.LastName;

            user.Validate();

            if (user.GetBrokenRules().Count > 0)
            { 
                return (UpdateResponse<UserDTO>) res.ReturnErrorResponseWithMultiple(user.GetBrokenRules());
            }

            try
            {
                _userRepository.Update(user);
                _uow.Commit();
            }
            catch (Exception ex)
            {
                return (UpdateResponse<UserDTO>) res.ReturnErrorResponseWith(ex.Message);
            }

            res.EntityDTO = _mapper.Map<User, UserDTO>(user);
            res.Success = true;
            return res;
        }

    }


}

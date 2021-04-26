using AutoMapper;
using BugTracker.auth.service;
using BugTracker.contracts.requests.user;
using BugTracker.contracts.response.user;
using BugTracker.dto;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.domain;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using BugTracker.repositories.user;
using System;
using System.Collections.Generic;
using System.Linq;

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
                foreach (var brokenRule in user.GetBrokenRules())
                {
                    res.Errors.Add(brokenRule.Rule);
                    res.Success = false;
                    return res;
                }
            }

            var userExists = _authService.FindByEmailOrUserName(req.Email, req.UserName).GetAwaiter().GetResult();

            if (userExists)
            {
                res.Errors.Add("User with the given user name or email already exists");
                res.Success = false;
                return res;
            }

            string token;
            try
            {
                token = _authService.Register(user.UserName, user.Email, req.Password).Result;
            }
            catch (Exception e)
            {
                return (CreateResponse<UserDTO>)ReturnFailureResponseWith(res, e.Message);
            }

            _userRepository.Save(user);

            try
            {
                _uow.Commit();
            }
            catch (Exception e)
            {
                _authService.DeleteUser(user.UserName);

                res.Errors.Add(e.Message);
                res.Success = false;
                return res;
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
                return (DeleteResponse)ReturnFailureResponseWith(res, "User not found!");
            }

            try
            {
                _userRepository.Delete(req.Id);
                _uow.Commit();
            }
            catch (Exception ex)
            {
                return (DeleteResponse)ReturnFailureResponseWith(res, ex.Message);
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
                return (FindByIdResponse<UserDTO>) ReturnFailureResponseWith(res, "User not found");
            }

            res.EntityDTO = _mapper.Map<User, UserDTO>(user);
            res.Success = true;
            return res;
        }

        public FindPageResponse<UserDTO> FindPage(FindPageRequest req)
        {
            List<User> users = new List<User>();

            var query = users.AsQueryable();
            var result = _userRepository.FindWithPaging(query, req.PageNum, req.PageSize);
            return null;
        }

        public BaseResponse Logout(LogoutRequest req)
        {
            var res = new BaseResponse();

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
                return (UpdateResponse<UserDTO>) ReturnFailureResponseWith(res, "User not found");
            }

            if (req.FirstName == null || req.LastName == null)
            {
                return (UpdateResponse<UserDTO>)ReturnFailureResponseWith(res, "Bad request");
            }

            user.FirstName = req.FirstName;
            user.LastName = req.LastName;

            user.Validate();

            if (user.GetBrokenRules().Count > 0)
            { 
                return (UpdateResponse<UserDTO>)ReturnFailureResponseWithMultiple(res, user.GetBrokenRules());
            }

            try
            {
                _userRepository.Update(user);
                _uow.Commit();
            }
            catch (Exception e)
            {
                return (UpdateResponse<UserDTO>)ReturnFailureResponseWith(res, e.Message);
            }

            res.EntityDTO = _mapper.Map<User, UserDTO>(user);
            res.Success = true;
            return res;
        }

        private BaseResponse ReturnFailureResponseWith(BaseResponse res, string message)
        {
            res.Errors.Add(message);
            res.Success = false;
            return res;
        }

        private BaseResponse ReturnFailureResponseWithMultiple(BaseResponse res, ICollection<BusinessRule> errors)
        {
            foreach (var error in errors)
            {
                res.Errors.Add(error.Rule);
            }
            res.Success = false;
            return res;
        }
    }


}

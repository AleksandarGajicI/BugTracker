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
using Microsoft.AspNetCore.Http;
using BugTracker.contracts.requests.filterAndOrdering;
using System.Linq;
using BugTracker.helpers.users;

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
                return (CreateUserWithTokenResponse)
                            res.ReturnErrorResponseWithMultiple(user.GetBrokenRules());
            }

            _userRepository.Save(user);

            try
            {
                _uow.Commit();
            }
            catch (Exception ex)
            {
                return (CreateUserWithTokenResponse)res.ReturnErrorResponseWith(ex.Message);
            }

            string token = _authService.Register(user, req.Password).GetAwaiter().GetResult();

            if (token == MagicStrings.Users.Error.AlreadyExists ||
                token == MagicStrings.Users.Error.Signup)
            {

                _userRepository.Delete(user);
                _uow.Commit();

                return (CreateUserWithTokenResponse)
                            res.ReturnErrorResponseWith(token);
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
                return (DeleteResponse)
                            res.ReturnErrorResponseWith(MagicStrings.Users.Error.NotFound);
            }

            try
            {
                _userRepository.Delete(user);
                _authService.DeleteUser(user.Email);
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


        public DeleteResponse Delete(DeleteRequest req, string userId)
        {
            var res = new DeleteResponse();


            var user = _userRepository.FindById(req.Id);

            if (user == null)
            {
                return (DeleteResponse)
                            res.ReturnErrorResponseWith(MagicStrings.Users.Error.NotFound);
            }

            if (!user.Id.ToString().ToLower().Equals(userId.ToString().ToLower()))
            {
                return (DeleteResponse)
                            res.ReturnErrorResponseWith(MagicStrings.Users.Error.Unauthorized);
            }

            try
            {
                _userRepository.Delete(user);
                _uow.Commit();
            }
            catch (Exception ex)
            {
                return (DeleteResponse)res.ReturnErrorResponseWith(ex.Message);
            }

            Console.WriteLine("deleting in auth");
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
                return (FindByIdResponse<UserDTO>) 
                            res.ReturnErrorResponseWith(MagicStrings.Users.Error.NotFound);
            }

            res.EntityDTO = _mapper.Map<User, UserDTO>(user);
            res.Success = true;
            return res;
        }

        public PagedResponse<UserDTO> GetPage(string userId, PagedQuery pageQuery, FilterAndOrderQuery filterAndOrderQuery)
        {
            var res = new PagedResponse<UserDTO>();

            var size = pageQuery.PageSize == null ? 3 : (int)pageQuery.PageSize;
            var num = pageQuery.PageNum == null ? 3 : (int)pageQuery.PageNum;

            var usersQuery = _userRepository.GetBasicQuery();


            if (filterAndOrderQuery != null && filterAndOrderQuery.Filters != null)
            {
                if(filterAndOrderQuery.Filters.Count() > 0 )
                {
                    usersQuery = usersQuery
                    .ApplyFilterOptions(filterAndOrderQuery.Filters.First());

                    usersQuery = usersQuery.OrderBy(u => u.UserName);
                }
                
            }

            var users = usersQuery.Page(num, size).ToList();

            res.Success = true;
            res.EntitiesDTO = _mapper.Map<ICollection<User>, ICollection<UserDTO>>(users);
            return res;
        }

        public LoginResponse Login(LoginRequest req)
        {
            var res = new LoginResponse();
            var jwt = _authService.Login(req.Email, req.Password).GetAwaiter().GetResult();

            if (jwt == MagicStrings.Users.Error.Login || 
                jwt == MagicStrings.Users.Error.NotFound)
            {
                return (LoginResponse)res.ReturnErrorResponseWith(jwt);
            }

            res.Success = true;
            res.Token = jwt;
            return res;
        }

        public ResponseBase Logout(LogoutRequest req)
        {
            var res = new ResponseBase();

           // _authService.Logout(req.UserName);
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

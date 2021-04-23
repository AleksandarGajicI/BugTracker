using AutoMapper;
using BugTracker.contracts.requests.user;
using BugTracker.dto;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _uow = uow;
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
            var res = new DeleteResponse();
            try
            {
                _userRepository.Delete(req.Id);
                _uow.Commit();
            }
            catch (Exception e)
            {
                res.Errors.Add(e.Message);
                res.Success = false;
                return res;
            }

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
                res.Errors.Add("User not found");
                res.Success = false;
                return res;
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

        public UpdateResponse<UserDTO> Update(UpdateUserRequest req)
        {
            var res = new UpdateResponse<UserDTO>();
            var user = _userRepository.FindById(req.Id);

            if (user == null)
            {
                res.Errors.Add("User not found");
                res.Success = false;
                return res;
            }

            if (req.FirstName == null || req.LastName == null)
            {
                res.Errors.Add("Bad Requests");
                res.Success = false;
                return res;
            }

            user.FirstName = req.FirstName;
            user.LastName = req.LastName;

            user.Validate();

            if (user.GetBrokenRules().Count > 0)
            { 
                foreach(var brokenRule in user.GetBrokenRules())
                {
                    res.Errors.Add(brokenRule.Rule);
                }
                res.Success = false;
                return res;
            }

            try
            {
                _userRepository.Update(user);
                _uow.Commit();
            }
            catch (Exception e)
            {
                res.Errors.Add(e.Message);
                res.Success = false;
                return res;
            }

            res.EntityDTO = _mapper.Map<User, UserDTO>(user);
            res.Success = true;
            return res;
        }
    }
}

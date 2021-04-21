using BugTracker.contracts.response.user;
using BugTracker.repositories.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.user
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepository;

        public UserService(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public FindAllUsersResponse FindAllUsers()
        {
            var users = _usersRepository.FindAll();

            var res = new FindAllUsersResponse
            {
                Errors = new List<string>(),
                Success = true,
                Users = users.ToList().AsReadOnly()
            };

            return res;
        }

        public FindUserByIdResponse FindUserById(Guid id)
        {
            var user = _usersRepository.FindById(id);

            var res = new FindUserByIdResponse();

            if (user is null)
            {
                res.Errors.Add($"User with {id} doesnt exist");
                res.Success = false;
                return res;
            }

            res.Success = true;
            res.User = user;

            return res;
        }
    }
}

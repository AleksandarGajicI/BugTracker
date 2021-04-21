using BugTracker.contracts.response.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.user
{
    public interface IUserService
    {
        public FindAllUsersResponse FindAllUsers();
        public FindUserByIdResponse FindUserById(Guid id);
    }
}

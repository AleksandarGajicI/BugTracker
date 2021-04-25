using BugTracker.auth.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.auth.service
{
    public interface IAuthService
    {
        public Task<string> Login(string userName, string email, string password);
        public Task<string> Register(string userName, string email, string password);
        public Task<bool> FindByEmailOrUserName(string email, string userName);
        public void DeleteUser(string userName);

        public void Logout(string userName);

    }
}

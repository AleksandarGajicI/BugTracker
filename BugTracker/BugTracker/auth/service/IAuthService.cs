using BugTracker.auth.domain;
using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.auth.service
{
    public interface IAuthService
    {
        public Task<string> Login(string email, string password);
        public Task<string> Register(User user, string password);
        public void DeleteUser(string email);
    }
}

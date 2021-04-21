using BugTracker.model;
using BugTracker.repositories.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories.user
{
    public interface IUserRepository : IReadOnlyRepository<User>, IPersistanceRepository<User>
    {
    }
}

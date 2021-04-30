using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories.role
{
    public interface IRoleRepository : IReadOnlyRepository<Role>
    {
        public Role FindRoleByName(string name);
    }
}

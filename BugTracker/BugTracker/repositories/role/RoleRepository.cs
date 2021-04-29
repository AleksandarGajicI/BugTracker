using BugTracker.database;
using BugTracker.infrastructure.repository;
using BugTracker.model;
using BugTracker.repositories.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories.role
{
    public class RoleRepository : GenericReadOnlyRepository<Role>, IRoleRepository
    {
        public RoleRepository(BugTrackerDatabase context)
            : base(context)
        { 
        }

        public Role FindRoleByName(string name)
        {
            return _table.Where(r => r.RoleName.Contains(name)).FirstOrDefault();
        }
    }
}

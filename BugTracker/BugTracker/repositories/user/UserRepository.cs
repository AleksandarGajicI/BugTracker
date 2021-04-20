using BugTracker.database;
using BugTracker.infrastructure.repository;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories.user
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BugTrackerDatabase context, IUnitOfWork uow)
            : base(context, uow)
        { 
            
        }
    }
}

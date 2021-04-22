using BugTracker.database;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.repository;
using BugTracker.infrastructure.services;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.user
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(BugTrackerDatabase context, IUnitOfWork uow)
            : base(new GenericRepository<User>(context, uow)
                  , uow)
        { 
        }

        public override UpdateResponse<User> Update(UpdateRequest<User> req)
        {
            throw new NotImplementedException();
        }
    }
}

using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.unitOfWork
{
    public interface IUnitOfWork
    {
        public void RegisterCreated(EntityBase entity, IUnitOfWorkRepository repo);
        public void RegisterUpdated(EntityBase entity, IUnitOfWorkRepository repo);
        public void RegisterDeleted(EntityBase entity, IUnitOfWorkRepository repo);
        public void Commit();
    }
}

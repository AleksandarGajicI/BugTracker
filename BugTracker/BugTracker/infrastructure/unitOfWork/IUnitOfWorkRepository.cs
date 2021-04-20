using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.unitOfWork
{
    public interface IUnitOfWorkRepository
    {
        public void PersistCreationOf(EntityBase entity);
        public void PersistDeletionOf(EntityBase entity);
        public void PersistUpdateOf(EntityBase entity);
    }
}

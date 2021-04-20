using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories.generic
{
    public interface IPersistanceRepository<T>
        where T : EntityBase
    {
        public void save(T entity);
        public void update(T entity);
        public void delete(Guid id);
    }
}

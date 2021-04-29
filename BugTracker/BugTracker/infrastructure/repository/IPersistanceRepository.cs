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
        public void Save(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}

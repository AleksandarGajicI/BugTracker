using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.repositories
{
    public interface IReadOnlyRepository<T> where T : EntityBase
    {
        public T FindById(Guid id);
        public IEnumerable<T> FindAll();
        public IQueryable<T> GetBasicQuery();
    }
}

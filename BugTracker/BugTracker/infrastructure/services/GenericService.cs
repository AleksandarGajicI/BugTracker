using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.domain;
using BugTracker.infrastructure.repository;
using BugTracker.infrastructure.unitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.services
{
    public abstract class GenericService<T> : GenericReadOnlyService<T>, IPersistanceService<T>
        where T : EntityBase
    {
        private readonly IUnitOfWork _uow;

        public GenericService(GenericRepository<T> repository, IUnitOfWork uow)
            : base(repository)
        {
            _uow = uow;
        }

        public CreateResponse<T> Create(CreateRequest<T> req)
        {
            var res = new CreateResponse<T>();
            var entity = req.Entity;
            entity.Validate();

            if (entity.GetBrokenRules().Count > 0)
            {
                foreach (var brokenRule in entity.GetBrokenRules())
                {
                    res.Errors.Add(brokenRule.Rule);
                }
                res.Success = false;
                return res;
            }

            ((GenericRepository<T>)_repository).Save(entity);

            _uow.Commit();


            res.Success = true;
            res.Entity = req.Entity;
            return res;
        }

        public DeleteResponse Delete(DeleteRequest req)
        {
            var id = req.Id;
            var res = new DeleteResponse();

            ((GenericRepository<T>)_repository).Delete(id);

            _uow.Commit();

            res.Success = true;
            res.IdDeleted = id;

            return res;

        }

        public abstract UpdateResponse<T> Update(UpdateRequest<T> req);
    }
}

using BugTracker.dto;
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
    public abstract class GenericService<T, TEntity, TCreate, TUpdate> : GenericReadOnlyService<T, TEntity>, IPersistanceService<T, TCreate, TUpdate>
        where T : BaseDTO 
        where TEntity : EntityBase
        where TCreate : BaseRequest
        where TUpdate : BaseRequest
    {
        private readonly IUnitOfWork _uow;

        public GenericService(GenericRepository<TEntity> repository, IUnitOfWork uow)
            : base(repository)
        {
            _uow = uow;
        }

        public CreateResponse<T> Create(TCreate req)
        {
            var res = new CreateResponse<T>();
            //need to map entity
            //var entity = req.Entity;
            //entity.Validate();

            //if (entity.GetBrokenRules().Count > 0)
            //{
            //    foreach (var brokenRule in entity.GetBrokenRules())
            //    {
            //        res.Errors.Add(brokenRule.Rule);
            //    }
            //    res.Success = false;
            //    return res;
            //}

            //((GenericRepository<T>)_repository).Save(entity);

            //_uow.Commit();


            //res.Success = true;
            //res.Entity = req.Entity;
            return res;
        }

        public DeleteResponse Delete(DeleteRequest req)
        {
            var id = req.Id;
            var res = new DeleteResponse();

            ((GenericRepository<TEntity>)_repository).Delete(id);

            _uow.Commit();

            res.Success = true;
            res.IdDeleted = id;

            return res;

        }

        public abstract UpdateResponse<T> Update(TUpdate req);
    }
}

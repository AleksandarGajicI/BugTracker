using BugTracker.dto;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.domain;
using BugTracker.infrastructure.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.services
{
    public class GenericReadOnlyService<T, TById, TEntity> : IReadOnlyService<T, TById>
        where T : BaseDTO
        where TById : BaseDTO
        where TEntity : EntityBase
    {
        protected readonly GenericReadOnlyRepository<TEntity> _repository;

        public GenericReadOnlyService(GenericReadOnlyRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public FindAllResponse<T> FindAll()
        {
            var entities = _repository.FindAll();

            var res = new FindAllResponse<T>
            {
                Errors = new List<string>(),
                Success = true,
                //need to map entity to dto!
                //FoundEntitiesDTO = entities.ToList().AsReadOnly()
            };

            return res;
        }

        public FindByIdResponse<TById> FindById(FindByIdRequest req)
        {
            var res = new FindByIdResponse<TById>();

            var user = _repository.FindById(req.Id);

            if (res is null)
            {
                res.Errors.Add($"User with {req.Id} doesnt exist");
                res.Success = false;
                return res;
            }

            res.Success = true;
            //map entity to dto!
            //res.Entity = user;

            return res;
        }

    }
}

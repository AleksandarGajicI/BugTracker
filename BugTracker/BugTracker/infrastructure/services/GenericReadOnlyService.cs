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
    public class GenericReadOnlyService<T> : IReadOnlyService<T>
        where T : EntityBase
    {
        protected readonly GenericReadOnlyRepository<T> _repository;

        public GenericReadOnlyService(GenericReadOnlyRepository<T> repository)
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
                FoundEntities = entities.ToList().AsReadOnly()
            };

            return res;
        }

        public FindByIdResponse<T> FindById(FindByIdRequest req)
        {
            var res = new FindByIdResponse<T>();

            var user = _repository.FindById(req.Id);

            if (res is null)
            {
                res.Errors.Add($"User with {req.Id} doesnt exist");
                res.Success = false;
                return res;
            }

            res.Success = true;
            res.Entity = user;

            return res;
        }

        public FindPageResponse<T> FindPage(FindPageRequest req)
        {
            var res = new FindPageResponse<T>();
            //var entities = _repository.FindWithPaging(null, req.PageNum, req.PageSize);
            return res;
        }
    }
}

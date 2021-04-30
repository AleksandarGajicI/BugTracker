using AutoMapper;
using BugTracker.dto;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.model;
using BugTracker.repositories.role;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker.services.role
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public FindAllResponse<RoleDTO> FindAll()
        {
            var res = new FindAllResponse<RoleDTO>();

            var roles = _roleRepository.FindAll().ToList();
            var rolesDTO = _mapper.Map<ICollection<Role>, ICollection<RoleDTO>>(roles);

            res.Success = true;
            res.FoundEntitiesDTO = rolesDTO;
            return res;
        }

        public FindByIdResponse<RoleDTO> FindById(FindByIdRequest req)
        {
            var res = new FindByIdResponse<RoleDTO>();
            var role = _roleRepository.FindById(req.Id);

            if (role == null)
            {
                res.Success = false;
                res.Errors.Add("Role not found");
                return res;
            }

            res.Success = true;
            res.EntityDTO = _mapper.Map<Role, RoleDTO>(role);
            return res;
        }

    }
}

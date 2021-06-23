using AutoMapper;
using BugTracker.contracts.requests.projectUserReq;
using BugTracker.dto.ProjectUserReq;
using BugTracker.helpers;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using BugTracker.repositories.project;
using BugTracker.repositories.projectUserRequests;
using BugTracker.repositories.role;
using BugTracker.repositories.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.services.projectUserReq
{
    public class ProjectUserReqService : IProjectUserReqService
    {
        private readonly IProjectUserReqRepository _projectUserReqRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProjectUserReqService(IProjectUserReqRepository projectUserReqRepository,
                                        IUserRepository userRepository,
                                        IRoleRepository roleRepository,
                                        IProjectRepository projectRepository,
                                        IUnitOfWork uow,
                                        IMapper mapper)
        {
            _projectUserReqRepository = projectUserReqRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _projectRepository = projectRepository;
            _uow = uow;
            _mapper = mapper;
        }

        public CreateResponse<ProjectUserRequestDTO> Create(Guid id, CreateProjectUserReqRequest req)
        {
            var res = new CreateResponse<ProjectUserRequestDTO>();

            var role = _roleRepository.FindById(req.RoleId);

            if (role == null)
            {
                return (CreateResponse<ProjectUserRequestDTO>)
                            res.ReturnErrorResponseWith("Role not found.");
            }

            var project = _projectRepository.FindById(req.ProjectId);

            if (project == null)
            {
                return (CreateResponse<ProjectUserRequestDTO>)
                            res.ReturnErrorResponseWith("Project not found.");
            }

            var sender = _userRepository.FindById(id);

            if (sender == null)
            {
                return (CreateResponse<ProjectUserRequestDTO>)
                            res.ReturnErrorResponseWith("Invalid sender.");
            }

            var userAssigned = _userRepository.FindById(req.UserAssignedId);

            if (userAssigned == null)
            {
                return (CreateResponse<ProjectUserRequestDTO>)
                            res.ReturnErrorResponseWith("Assigned user not found.");
            }

            var projectManagers = project.ProjectUsersReq
                        .Where(pur => pur.Accepted == true && pur.Role.RoleName == "PROJECT_MANAGER").ToList();

            if (projectManagers.Find(pur => pur.UserAssigned.Id == id) == null)
            {
                return (CreateResponse<ProjectUserRequestDTO>)
                            res.ReturnErrorResponseWith("User must be project manager to send requests.");
            }

            if (project.ProjectUsersReq.ToList().Find(pur => pur.UserAssigned.Id == req.UserAssignedId) != null)
            {
                return (CreateResponse<ProjectUserRequestDTO>)
                            res.ReturnErrorResponseWith("User has alredy received an invitation.");
            }

            var projectUserReq = new ProjectUserReq()
            {
                Id = Guid.NewGuid(),
                Message = req.Message,
                UserAssigned = userAssigned,
                Sender = sender,
                Role = role,
                Project = project,
                Accepted = false,
                RequestSent = DateTime.Now
            };

            projectUserReq.Validate();

            if(projectUserReq.GetBrokenRules().Count > 0)
            {
                return (CreateResponse<ProjectUserRequestDTO>)
                            res.ReturnErrorResponseWithMultiple(projectUserReq.GetBrokenRules());
            }

            _projectUserReqRepository.Save(projectUserReq);

            try
            {
                _uow.Commit();
            }
            catch (Exception ex)
            {
                return (CreateResponse<ProjectUserRequestDTO>)
                            res.ReturnErrorResponseWith(ex.Message);
            }

            res.Success = true;
            return res;
        }

        public DeleteResponse Delete(Guid userId, Guid id)
        {
            var res = new DeleteResponse();

            var pur = _projectUserReqRepository.FindById(id);

            if (pur == null)
            {
                return (DeleteResponse)res.ReturnErrorResponseWith("Specified request not found");
            }

            if (!pur.Sender.Id.Equals(userId)) 
            {
                return (DeleteResponse)res.ReturnErrorResponseWith("You can delete only requests that you sent!");
            }

            _projectUserReqRepository.Delete(pur);

            try
            {
                _uow.Commit();
            }
            catch (Exception ex)
            { 
                return (DeleteResponse)res.ReturnErrorResponseWith(ex.Message);
            }

            res.Success = true;
            res.IdDeleted = id;
            return res;
        }

        public FindAllResponse<ProjectUserRequestDTO> GetAll(Guid id)
        {
            var res = new FindAllResponse<ProjectUserRequestDTO>();

            var requests = _projectUserReqRepository.FindReceivedReqFor(id);

            res.FoundEntitiesDTO = _mapper.Map<ICollection<ProjectUserReq>, 
                                                ICollection<ProjectUserRequestDTO>>(requests);
            res.Success = true;
            return res;
        }

        public FindAllResponse<ProjectUserRequestDTO> GetAllSentReq(Guid id)
        {
            var res = new FindAllResponse<ProjectUserRequestDTO>();

            var requests = _projectUserReqRepository.FindSentReqFor(id);

            res.FoundEntitiesDTO = _mapper.Map<ICollection<ProjectUserReq>,
                                                ICollection<ProjectUserRequestDTO>>(requests);
            res.Success = true;
            return res;
        }

        public ResponseBase ReplyWith(Guid userId, ProjectUserReplyRequest req)
        {
            var res = new ResponseBase();

            var pur = _projectUserReqRepository.FindById(req.RequestId);

            if (pur == null)
            {
                return res.ReturnErrorResponseWith("Specified request for project not found.");
            }

            if (!pur.UserAssigned.Id.Equals(userId))
            {
                return res.ReturnErrorResponseWith("Request is not yours.");
            }

            if (req.IsAccepted)
            {
                //update
                pur.Accepted = req.IsAccepted;
                _projectUserReqRepository.Update(pur);
            }
            else
            {
                _projectUserReqRepository.Delete(pur);
            }

            pur.Validate();

            if (pur.GetBrokenRules().Count > 0)
            {
                return res.ReturnErrorResponseWithMultiple(pur.GetBrokenRules());
            }

            try 
            {
                _uow.Commit();
            }
            catch(Exception ex)
            {
                return res.ReturnErrorResponseWith(ex.Message);
            }

            res.Success = true;
            return res;
        }
    }
}

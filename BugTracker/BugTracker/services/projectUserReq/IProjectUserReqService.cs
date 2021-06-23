using BugTracker.contracts.requests.projectUserReq;
using BugTracker.dto.ProjectUserReq;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using System;

namespace BugTracker.services.projectUserReq
{
    public interface IProjectUserReqService
    {
        public FindAllResponse<ProjectUserRequestDTO> GetAll(Guid id);
        public FindAllResponse<ProjectUserRequestDTO> GetAllSentReq(Guid id);
        public CreateResponse<ProjectUserRequestDTO> Create(Guid id, CreateProjectUserReqRequest req);
        public ResponseBase ReplyWith(Guid userId, ProjectUserReplyRequest req);

        public DeleteResponse Delete(Guid userId, Guid id);
    }
}

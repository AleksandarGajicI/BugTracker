using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BugTracker.contracts;
using BugTracker.dto;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using BugTracker.repositories.comment;
using BugTracker.repositories.ticket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CommentController(ICommentRepository commentRepository,
                                 ITicketRepository ticketRepository,
                                 IUnitOfWork uow,
                                 IMapper mapper)
        {
            _commentRepository = commentRepository;
            _ticketRepository = ticketRepository;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(ApiRoutes.Comments.GetAllForTicket)]
        public IActionResult FindForTicket(Guid id) 
        {
            var res = new FindAllResponse<CommentDTO>();

            var ticket = _ticketRepository.FindById(id);

            if (ticket is null) {
                res.Success = false;
                res.Errors.Add("Wrong ticket id!");
                return NotFound(res);
            }

            res.Success = true;
            res.FoundEntitiesDTO = 
                _mapper.Map<ICollection<Comment>, ICollection<CommentDTO>>(_commentRepository.findCommentsForTicket(id));
            return Ok(res);
        }

        [HttpDelete]
        [Route(ApiRoutes.Comments.Delete)]
        public IActionResult Delete(Guid id) 
        {
            var res = new DeleteResponse();

            var comment = _commentRepository.FindById(id);

            if (comment is null) 
            {
                res.Success = false;
                res.Errors.Add("Wrong comment id");
                return NotFound(res);
            }

            _commentRepository.Delete(comment);

            return NoContent();

        }
    }
}

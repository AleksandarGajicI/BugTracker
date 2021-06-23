using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BugTracker.contracts;
using BugTracker.contracts.requests.filterAndOrdering;
using BugTracker.dto;
using BugTracker.dto.comment;
using BugTracker.helpers;
using BugTracker.infrastructure.contracts.requests;
using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.unitOfWork;
using BugTracker.model;
using BugTracker.repositories.comment;
using BugTracker.repositories.ticket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        [Route(ApiRoutes.Comments.Create)]
        public IActionResult Create(CommentCreateDTO req) 
        {
            var res = new UpdateResponse<CommentDTO>();
            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            var ticket = _ticketRepository.FindById(req.TicketId);

            if (ticket == null) 
            {
                res.Success = false;
                res.Errors.Add("Bad ticket id");
                return BadRequest(res);
            }

            //ticket.Project.ProjectUsersReq.Where(
            //        pur => pur.UserAssigned.Id.Equals(userId) ||
            //        pur.Sender.Id.Equals(userId)).ToList().Count <= 0

            if (ticket.Project.ProjectUsersReq.Where(
                    pur => pur.UserAssigned.Id.Equals(Guid.Parse(userId)) ||
                    pur.Sender.Id.Equals(Guid.Parse(userId))).ToList().Count <= 0)
            {
                res.Success = false;
                res.Errors.Add("User can make comments only on tickets that belong to him");
                return BadRequest(res);
            }

            var projectUser = ticket.Project.ProjectUsersReq.Where(
                    pur => pur.UserAssigned.Id.Equals(Guid.Parse(userId))).FirstOrDefault();

            var comment = new Comment();
            comment.Commenter = projectUser;
            comment.Created = DateTime.Now;
            comment.Message = req.Message;
            ticket.Comments.Add(comment);

            _ticketRepository.Update(ticket);

            try
            {
                _uow.Commit();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                res.Success = false;
                res.Errors.Add("Server error");
                return StatusCode(StatusCodes.Status500InternalServerError, res);
            }

            res.EntityDTO = _mapper.Map<Comment, CommentDTO>(comment);
            res.Success = true;

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

            try
            {
                _uow.Commit();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return BadRequest();
            }
                
            return NoContent();

        }

        [HttpGet]
        [Route(ApiRoutes.Comments.GetPageForTicket)]
        public IActionResult GetPageForTicket(Guid id, [FromQuery] PagedQuery pageQuery, [FromQuery] FilterAndOrderQuery filterAndOrderQuery) 
        {



            var res = new PagedResponse<CommentDTO>();

            var size = pageQuery.PageSize == null ? 3 : (int)pageQuery.PageSize;
            var num = pageQuery.PageNum == null ? 3 : (int)pageQuery.PageNum;

            var commentsQuery = _commentRepository.GetBasicQuery();


            if (filterAndOrderQuery != null && filterAndOrderQuery.Filters != null)
            {
                if (filterAndOrderQuery.Filters.Count() > 0)
                {
                    commentsQuery = commentsQuery
                        .Where(c => c.Commenter.UserAssigned.UserName.Contains(filterAndOrderQuery.Filters.First().Value));

                    commentsQuery = commentsQuery.OrderBy(c => c.Created);
                }

            }

            var comments = commentsQuery
                .Where(c => c.Ticket.Id.Equals(id))
                .Include(c => c.Commenter)
                    .ThenInclude(pur => pur.UserAssigned)
                .Page(num, size)
                .ToList();

            res.Success = true;
            res.EntitiesDTO = _mapper.Map<ICollection<Comment>, ICollection<CommentDTO>>(comments);

            return Ok(res);
        }

    }
}

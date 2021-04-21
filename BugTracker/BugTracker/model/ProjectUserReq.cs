using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class ProjectUserReq : EntityBase
    {
        public Guid Id { get; set; }
        public DateTime RequestSent { get; set; }
        public bool Accepted { get;     set; }
        public string Message { get; set; }

        public ProjectUserReq()
        {
            AssignedForTicket = new List<ProjectUserForTicket>();
        }

        public ProjectUserReq(string message,
                                User userAssigned,
                                Role role,
                                Project project,
                                bool accepted = false)
            : this()
        {
            RequestSent = DateTime.Now;
            Message = message;
            UserAssigned = userAssigned;
            Role = role;
            Project = project;
            Accepted = accepted;
        }




        public Guid ProjectId { get; set; }
        public Project Project { get; set; }


        public Guid UserAssignedId { get; set; }
        public User UserAssigned { get; set; }

        public Role Role { get; set; }

        public User Sender { get; set; }

        public ICollection<ProjectUserForTicket> AssignedForTicket { get; set; }

        public override string ToString()
        {
            return $"ProjectUserReq:" +
                    $" Id: {Id}," +
                    $" RequestSent: {RequestSent}," +
                    $" Accepted: {Accepted}," +
                    $" Message: {Message}," +
                    $" Sender: {Sender?.UserName}," +
                    $" User: {UserAssigned?.UserName}" +
                    $" Project: {Project?.Name}" +
                    $" Role: {Role?.RoleName}";
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

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

        public override void Validate()
        {
            if (RequestSent == null)
            {
                AddBrokenRule(new BusinessRule("RequestSent", "Request must have a date that it has been sent on."));
            }

            if (Id == null)
            {
                AddBrokenRule(new BusinessRule("Id", "Request must have an unique identifier."));
            }

            if (UserAssigned == null)
            {
                AddBrokenRule(new BusinessRule("UserAssigned", "Request must have a receiver."));
            }

            if (Role == null)
            {
                AddBrokenRule(new BusinessRule("Role", "Request must have a specified role."));
            }

            if (Sender == null)
            {
                AddBrokenRule(new BusinessRule("Sender", "Request must have a sender."));
            }

            if (Project == null)
            {
                AddBrokenRule(new BusinessRule("Project", "Request must have project that it is tied to."));
            }

            if (DateTime.Compare(RequestSent, DateTime.Now) > 0)
            {
                AddBrokenRule(new BusinessRule("RequestSent", "Request can't be sent in future."));
            }
        }
    }
}

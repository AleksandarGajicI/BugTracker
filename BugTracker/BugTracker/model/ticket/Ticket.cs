using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class Ticket : EntityBase
    {

        public enum TicketType { 
                UNDEFINED, BUG_ERROR, FEATURE_REQUEST, OTHER, DOCUMENT_REQUEST 
        }



        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public TicketType Type { get; set; }


        public ProjectUserReq Reporter { get; set; }
        public Project Project { get; set; }

        public TicketStatus Status { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<ProjectUserForTicket> AssignedUsers { get; set; }

        public override void Validate()
        {
            if (Id == null)
            {
                AddBrokenRule(new BusinessRule("Id", "TicketId can't be null"));
            }

            if (string.IsNullOrEmpty(Title))
            {
                AddBrokenRule(new BusinessRule("Title", "Ticket title can't be null or empty"));
            }

            if (DateTime.Compare(Created, DateTime.Now) > 0)
            {
                AddBrokenRule(new BusinessRule("Created", "Ticket can't be created in the future."));
            }

            if (Created == null)
            {
                AddBrokenRule(new BusinessRule("Created", "Ticket must specify a date it is created on."));
            }

            if (Deadline == null)
            {
                AddBrokenRule(new BusinessRule("Created", "Ticket must have a deadline."));
            }

            if (Type == 0)
            {
                AddBrokenRule(new BusinessRule("Type", "Ticket must have a TicketType."));
            }

            if (Reporter == null)
            {
                AddBrokenRule(new BusinessRule("Reporter", "Ticket must have a Reported."));
            }

            if (Project == null)
            {
                AddBrokenRule(new BusinessRule("Project", "Ticket must have a project it is tied to."));
            }

            if (Status == null)
            {
                AddBrokenRule(new BusinessRule("Status", "Ticket must have a defined status."));
            }
        }

        public override string ToString()
        {
            return "Ticket.ToString() not implemented";
        }
    }
}

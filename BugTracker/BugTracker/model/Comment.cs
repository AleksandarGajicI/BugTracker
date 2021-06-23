using BugTracker.infrastructure.domain;
using System;

namespace BugTracker.model
{
    public class Comment : EntityBase
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Message { get; set; }

        public ProjectUserReq Commenter { get; set; }

        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public override string ToString()
        {
            return $"Commenter: ${Commenter}, message: ${Message}, created at: ${Created}";
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Message))
            {
                AddBrokenRule(new BusinessRule("Message", "Message can't be null or empty field"));
            }

            if (Commenter is null)
            {
                AddBrokenRule(new BusinessRule("Commenter", "Message must have an owner"));
            }

            if (Ticket is null)
            {
                AddBrokenRule(new BusinessRule("Ticket", "Message must have a ticket it is tied to"));
            }
        }
    }
}

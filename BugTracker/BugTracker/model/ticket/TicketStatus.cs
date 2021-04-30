using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class TicketStatus : EntityBase
    {
        public Guid Id { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return $"TicketStatus:" +
                $" Id: {Id}," +
                $" Status: {Status}";
        }

        public override void Validate()
        {
            if (Id == null)
            {
                AddBrokenRule(new BusinessRule("Id", "TicketStatus must have an Id"));
            }

            if (string.IsNullOrEmpty(Status) || string.IsNullOrWhiteSpace(Status))
            {
                AddBrokenRule(
                    new BusinessRule("Status", "TicketStatus must have status name that is not null or white space"));
            }
        }
    }
}

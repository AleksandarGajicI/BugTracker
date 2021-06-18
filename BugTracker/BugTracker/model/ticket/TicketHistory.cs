using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class TicketHistory : EntityBase
    {
        public Guid Id { get; set; }
        public string ChangedProperty { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Changed { get; set; }
        public string UserName { get; set; }

        public Ticket Ticket { get; set; }

        public override string ToString()
        {
            return $"Old value: ${OldValue} -> ${NewValue}, at: ${Changed} by: ${UserName}";
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(OldValue)) {
                AddBrokenRule(new BusinessRule("OldValue", "OldValue can't be null or empty string"));
            }

            if (string.IsNullOrEmpty(NewValue))
            {
                AddBrokenRule(new BusinessRule("NewValue", "NewValue can't be null or empty string"));
            }

            if (string.IsNullOrEmpty(ChangedProperty))
            {
                AddBrokenRule(new BusinessRule("ChangedProperty", "ChangedProperty can't be null or empty string"));
            }

            if (string.IsNullOrEmpty(UserName))
            {
                AddBrokenRule(new BusinessRule("UserName", "UserName can't be null or empty string"));
            }
        }
    }
}

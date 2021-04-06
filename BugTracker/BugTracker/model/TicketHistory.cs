using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class TicketHistory
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string ChangedProperty { get; set; }
        [Required]
        [MaxLength(30)]
        public string OldValue { get; set; }
        [Required]
        [MaxLength(30)]
        public string NewValue { get; set; }
        [Required]
        public DateTime Changed { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
    }
}

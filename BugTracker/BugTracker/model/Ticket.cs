using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class Ticket
    {

        public enum TicketType { 
                BUG_ERROR, FEATURE_REQUEST, OTHER, DOCUMENT_REQUEST 
        }



        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public TicketType Type { get; set; }
        [Required]
        public User Reporter { get; set; }
        public List<Comment> Comments { get; set; }
        [Required]
        public TicketStatus Status { get; set; }

    }
}

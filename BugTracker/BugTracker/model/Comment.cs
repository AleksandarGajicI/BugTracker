using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [MaxLength(350)]
        public string Message { get; set; }
        [Required]
        public User Commenter { get; set; }

        [Required]
        public Ticket Ticket { get; set; }
    }
}

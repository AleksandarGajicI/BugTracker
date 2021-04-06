using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(350)]
        public string Description { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        public bool Closed { get; set; }
        [Required]
        public User owner { get; set; }


    }
}

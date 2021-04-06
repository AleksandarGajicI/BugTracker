using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.model
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }
        [Required]
        [MaxLength(350)]
        public string Description { get; set; }

    }
}

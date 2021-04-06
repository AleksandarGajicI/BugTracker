﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.model
{
    public class UserAssignedRequest
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime RequestSent { get; set; }
        [Required]
        public bool Accepted { get;     set; }
        [MaxLength(200)]
        public string Message { get; set; }
        [Required]
        public Project Project { get; set; }
        [Required]
        public User UserAssigned { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}

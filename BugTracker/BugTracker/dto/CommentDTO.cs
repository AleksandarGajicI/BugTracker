using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.dto
{
    public class CommentDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Message { get; set; }

        public UserAbbreviatedDTO Commenter { get; set; }
    }
}

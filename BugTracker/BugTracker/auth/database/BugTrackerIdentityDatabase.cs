using BugTracker.auth.domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.auth.database
{
    public class BugTrackerIdentityDatabase : IdentityDbContext<UserAuth>
    {
        public BugTrackerIdentityDatabase(DbContextOptions<BugTrackerIdentityDatabase> options)
            : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

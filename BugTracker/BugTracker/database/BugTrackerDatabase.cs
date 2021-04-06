using BugTracker.database.config;
using BugTracker.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.database
{
    public class BugTrackerDatabase : DbContext
    {
        public BugTrackerDatabase(DbContextOptions options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            UserDbConfig.ConfigureUserTable(modelBuilder);
            ProjectDbConfig.ConfigureProjectTable(modelBuilder);
        }

        public DbSet<User> User { get; set; }

        public DbSet<Project> Project { get; set;}
    }
}

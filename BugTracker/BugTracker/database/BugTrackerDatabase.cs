using BugTracker.database.config;
using BugTracker.database.config.relationship;
using BugTracker.database.config.ticket;
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
        public BugTrackerDatabase(DbContextOptions<BugTrackerDatabase> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var configClasses = typeof(BugTrackerDatabase).Assembly.ExportedTypes
                .Where(x => typeof(IConfigDB).IsAssignableFrom(x) &&!x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IConfigDB>().ToList();

            configClasses.ForEach(config => config.ConfigureDB(modelBuilder));

            RelationshipsDbConfig.ConfigureRealtionships(modelBuilder);

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProjectUserReq> ProjectUserRequests { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketHistory> TicketHistory { get; set; }

    }
}

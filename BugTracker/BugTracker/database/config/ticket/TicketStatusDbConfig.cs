using BugTracker.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.database.config
{
    public class TicketStatusDbConfig : IConfigDB
    {
        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var ticketStatus = modelBuilder.Entity<TicketStatus>();

            ticketStatus
                .HasKey(t => t.Id);

            ticketStatus.HasIndex(t => t.Status)
                .IsUnique();

            ticketStatus
                .Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

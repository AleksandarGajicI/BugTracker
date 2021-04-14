using BugTracker.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.database.config.ticket
{
    public class TicketHistoryDbConfig : IConfigDB
    {

        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var ticketHistory = modelBuilder.Entity<TicketHistory>();

            ticketHistory
                .HasKey(t => t.Id);

            ticketHistory
                .Property(t => t.ChangedProperty)
                .HasMaxLength(30)
                .IsRequired();

            ticketHistory
                .Property(t => t.OldValue)
                .HasMaxLength(100)
                .IsRequired();

            ticketHistory
                .Property(t => t.NewValue)
                .HasMaxLength(100)
                .IsRequired();

            ticketHistory
                .Property(t => t.Changed)
                .IsRequired();

            ticketHistory
                .Property(t => t.UserName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}

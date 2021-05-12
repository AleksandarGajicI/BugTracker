using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static BugTracker.model.Ticket;

namespace BugTracker.model.domainServices
{
    public class TicketDomainService
    {
        public ICollection<TicketHistory> GetHistoriesFor(Ticket ticket, 
                                                            User user,
                                                            string title, 
                                                            string description, 
                                                            DateTime deadline,
                                                            TicketType type)
        {
            var histories = new List<TicketHistory>();

            if (!ticket.Title.Equals(title))
            {
                var history = new TicketHistory();

                histories.Add(MakeHistoryFor(ticket, 
                                             user.UserName, 
                                             ticket.Title, 
                                             title, 
                                             ticket => ticket.Title));
            }

            if (!ticket.Description.Equals(description))
            {
                histories.Add(MakeHistoryFor(ticket,
                                             user.UserName,
                                             ticket.Description,
                                             description,
                                             ticket => ticket.Description));
            }

            if (DateTime.Compare(ticket.Deadline, deadline) != 0)
            {
                histories.Add(MakeHistoryFor(ticket,
                                             user.UserName,
                                             ticket.Deadline.ToString(),
                                             deadline.ToString(),
                                             ticket => ticket.Deadline));
            }

            if (ticket.Type != type)
            {
                histories.Add(MakeHistoryFor(ticket,
                                             user.UserName,
                                             ticket.Type.ToString(),
                                             type.ToString(),
                                             ticket => ticket.Type));
            }

            return histories;
        }

        private TicketHistory MakeHistoryFor<TProperty>(Ticket ticket,
                                                        string userName,
                                                        string oldValue,
                                                        string newValue,
                                                        Expression<Func<Ticket, TProperty>> changedProperty)
        {
            var history = new TicketHistory();
            history.OldValue = oldValue;
            history.NewValue = newValue;
            history.Changed = DateTime.Now;
            history.UserName = userName;
            history.Ticket = ticket;

            var expression = (MemberExpression)changedProperty.Body;

            history.ChangedProperty = expression.Member.Name;

            return history;
        }
    }
}

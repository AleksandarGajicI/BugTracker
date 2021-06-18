using BugTracker.infrastructure.unitOfWork;
using BugTracker.repositories.comment;
using BugTracker.repositories.project;
using BugTracker.repositories.projectUserRequests;
using BugTracker.repositories.role;
using BugTracker.repositories.ticket;
using BugTracker.repositories.ticketHistory;
using BugTracker.repositories.ticketStatus;
using BugTracker.repositories.user;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.helpers.dependencyInjection
{
    public static class RepositoriesInjectionExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, BugTrackerUnitOfWork>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IProjectUserReqRepository, ProjectUserReqRepository>();
            services.AddScoped<ITicketStatusRepository, TicketStatusRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketHistoryRepository, TicketHistoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}

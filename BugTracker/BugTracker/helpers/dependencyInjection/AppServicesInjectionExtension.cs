using BugTracker.auth.service;
using BugTracker.helpers.uri;
using BugTracker.services.project;
using BugTracker.services.projectUserReq;
using BugTracker.services.role;
using BugTracker.services.ticket;
using BugTracker.services.ticketStatus;
using BugTracker.services.user;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.helpers.dependencyInjection
{
    public static class AppServicesInjectionExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IProjectUserReqService, ProjectUserReqService>();
            services.AddScoped<ITicketStatusService, TicketStatusService>();
            services.AddScoped<ITicketService, TicketService>();

            services.AddSingleton<IUriService, UriService>(provider =>
            {
                var accessor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent(), "/");
                return new UriService(absoluteUri);
            });
        }
    }
}

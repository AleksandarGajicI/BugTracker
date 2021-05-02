using BugTracker.auth.database;
using BugTracker.auth.domain;
using BugTracker.database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.helpers.dependencyInjection
{
    public static class DbInjectionExtension
    {
        public static void AddContextsWithAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContexts(configuration);

            services.AddDbContext<BugTrackerIdentityDatabase>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Identity"));
            });

            services.AddIdentity<UserAuth, UserRole>()
                .AddEntityFrameworkStores<BugTrackerIdentityDatabase>();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                //just for Develoment
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            });
        }

        public static void AddContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BugTrackerDatabase>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }
    }
}

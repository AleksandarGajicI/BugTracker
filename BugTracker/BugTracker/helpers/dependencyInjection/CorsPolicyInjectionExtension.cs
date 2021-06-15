using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.helpers.dependencyInjection
{
    public static class CorsPolicyInjectionExtension
    {
        public static void AddCustomCorsPolicy(this IServiceCollection services) {
            services.AddCors(o => o.AddPolicy("AllAccess", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }
    }
}

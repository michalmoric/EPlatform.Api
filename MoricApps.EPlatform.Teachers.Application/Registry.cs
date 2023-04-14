using Microsoft.Extensions.DependencyInjection;
using MoricApps.EPlatform.Teachers.Application.Services;

namespace MoricApps.EPlatform.Teachers.Application
{
    public static class Registry
    {
        public static IServiceCollection? AddTeacherService(this IServiceCollection services)
        {
            if (services == null)
            {
                return null;
            }
            services.AddScoped<ITeacherService, TeacherService>();
            return services;
        }
        public static IServiceCollection? AddEmailService(this IServiceCollection services)
        {
            if (services == null)
            {
                return null;
            }
            services.AddScoped<IEmailService, EmailService>();
            return services;
        }
    }
}

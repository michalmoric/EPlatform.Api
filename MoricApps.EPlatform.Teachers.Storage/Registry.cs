using Microsoft.Extensions.DependencyInjection;
using MoricApps.EPlatform.Teachers.Api.Repositories;

namespace MoricApps.EPlatform.Teachers.Storage
{
    public static class Registry
    {
        public static IServiceCollection? AddTeacherRepository(this IServiceCollection services)
        {
            if (services == null)
            {
                return null;
            }
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            return services;
        }
    }
}

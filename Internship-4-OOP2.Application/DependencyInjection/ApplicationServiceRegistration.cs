using Microsoft.Extensions.DependencyInjection;

namespace Internship_4_OOP2.Application.DependencyInjection
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}

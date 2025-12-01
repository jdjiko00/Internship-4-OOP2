using Internship_4_OOP2.Application.Common.Interfaces;
using Internship_4_OOP2.Doimain.Persistence.Companies;
using Internship_4_OOP2.Doimain.Persistence.Users;
using Internship_4_OOP2.Infrastructure.Common.Caching;
using Internship_4_OOP2.Infrastructure.Common.ExternalApi;
using Internship_4_OOP2.Infrastructure.Companies;
using Internship_4_OOP2.Infrastructure.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Internship_4_OOP2.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
        services.AddScoped<ICompanyUnitOfWork, CompanyUnitOfWork>();

        services.AddHttpClient<IExternalUserApiService, ExternalUserApiService>();

        services.AddMemoryCache();
        services.AddSingleton<IMemoryCacheService, MemoryCacheService>();

        return services;
    }
}

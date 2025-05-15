using CleanArc.Infrastructure.Shared.Data;
using Microsoft.Extensions.DependencyInjection;
using CleanArc.Infrastructure.Accounts.Repositories;
using CleanArc.Application.Shared.Repositories.Abstractions;
using CleanArc.Application.Accounts.Repositories.Abstractions;

namespace CleanArc.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IAccountRepository, AccountRepository>();
        
        return services;
    }
}
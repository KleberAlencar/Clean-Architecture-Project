using FluentValidation;
using CleanArc.Application.Shared.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArc.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAccountApplication(this IServiceCollection services)
    {
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            x.AddOpenBehavior(typeof(LoggingBehavior<,>));
            x.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        return services;
    }
}
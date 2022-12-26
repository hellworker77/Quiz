using Core.Abstraction.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Domain.Services.DependencyInject;

public static class ServiceProvider
{
    public static void ServicesProvide(this IServiceCollection services)
    {
        services.AddTransient<ITestService, TestService>();
        services.AddScoped<IIdentityService, IdentityService>();
    }
}
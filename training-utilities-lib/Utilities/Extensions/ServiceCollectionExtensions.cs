using Microsoft.Extensions.DependencyInjection;
using Utilities.Clients;

namespace Utilities.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUtilityServices(
        this IServiceCollection services)
    {
        services.AddHttpClient<IIdentityClient, IdentityClient>();

        return services;
    }
}
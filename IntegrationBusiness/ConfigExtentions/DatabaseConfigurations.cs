using IntegrationDtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationBusiness.ConfigExtentions;

public static class DatabaseConfigurations
{
    public static IServiceCollection AddSqlOptions(this IServiceCollection services, IConfiguration configuration)
    {
        //Add DbContext
        // ConnectionStrings
        return services;
    }
}
using IntegrationDtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationBusiness.ConfigExtentions;

public static class OptionsConfigurations
{
    // Đăng ký các config trong appsettings.json sử dụng Options Pattern
    public static IServiceCollection AddAllOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<WeatherOptions>(configuration.GetSection(WeatherOptions.Name));
        return services;
    }
}
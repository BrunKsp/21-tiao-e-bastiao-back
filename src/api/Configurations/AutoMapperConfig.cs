using application.AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api.Configurations;

public static class AutoMapperConfig
{
    public static void AutoMapperServiceConfig(this IServiceCollection services, IConfiguration config)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var mappginConfig = AutoMapperSetup.RegisterMappings(config);
        var mapper = mappginConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}
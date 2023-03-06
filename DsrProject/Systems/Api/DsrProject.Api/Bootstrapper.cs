namespace DsrProject.Api;

using DsrProject.Api.Settings;
using DsrProject.Services.Settings;
using DsrProject.Services.Thoughts;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services
            .AddSwaggerSettings(builder)
            .AddApiSpecialSettings(builder)
            .AddMainSettings(builder)
            .AddThouhgtService();
        return services;
    }
    public static  IServiceCollection AddMainSettings(this IServiceCollection services, WebApplicationBuilder  builder)
    {  
        services.Configure<MainSettings>(builder.Configuration.GetSection("Main"));
        return services;
    }
    public static IServiceCollection AddApiSpecialSettings(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.Configure<ApiSpecialSettings>(builder.Configuration.GetSection("ApiSpecial"));
        return services;
    }
    public static IServiceCollection AddSwaggerSettings(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.Configure<SwaggerSettings>(builder.Configuration.GetSection("Swagger"));
        return services;
    }
}

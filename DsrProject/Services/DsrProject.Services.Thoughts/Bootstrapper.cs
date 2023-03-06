namespace DsrProject.Services.Thoughts;

using DsrProject.Services.Thoughts;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddThouhgtService(this IServiceCollection services)
    {
        services.AddSingleton<IThoughtService, ThoughtService>();

        return services;
    }
}

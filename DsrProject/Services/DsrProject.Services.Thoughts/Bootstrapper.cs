using Microsoft.Extensions.DependencyInjection;

namespace DsrProject.Services.Thoughts
{ 
public static class Bootstrapper
{
    public static IServiceCollection AddThouhgtService(this IServiceCollection services)
    {
        services.AddSingleton<IThoughtService, ThoughtService>();

        return services;
    }
}

}
using Microsoft.Extensions.DependencyInjection;

namespace DsrProject.Services.Actions
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddActions(this IServiceCollection services)
        {
            services.AddSingleton<IAction, Action>();

            return services;
        }
    }
}

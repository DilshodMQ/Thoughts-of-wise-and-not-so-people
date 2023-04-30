using Microsoft.Extensions.DependencyInjection;

namespace DsrProject.Services.Authors
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAuthorService(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorService, AuthorService>();

            return services;
        }
    }
}
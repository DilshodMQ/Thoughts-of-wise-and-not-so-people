using Microsoft.Extensions.DependencyInjection;

namespace DsrProject.Services.Respondents
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddRespondentService(this IServiceCollection services)
        {
            services.AddSingleton<IRespondentService, RespondentService>();

            return services;
        }
    }
}

using DsrProject.Services.EmailSender;
using DsrProject.Services.RabbitMq;
using Microsoft.Extensions.DependencyInjection;

namespace DsrProject.Worker
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services
                .AddRabbitMq()
                .AddEmailSender()
                ;

            services.AddSingleton<ITaskExecutor, TaskExecutor>();

            return services;
        }
    }
}
 




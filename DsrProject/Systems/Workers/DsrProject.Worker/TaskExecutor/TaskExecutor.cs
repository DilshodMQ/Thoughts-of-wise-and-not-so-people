using DsrProject.Consts;
using DsrProject.Services.EmailSender;
using DsrProject.Services.RabbitMq;

namespace DsrProject.Worker
{
    public class TaskExecutor : ITaskExecutor
    {
        private readonly ILogger<TaskExecutor> logger;
        private readonly IServiceProvider serviceProvider;
        private readonly IRabbitMq rabbitMq;

        public TaskExecutor(
            ILogger<TaskExecutor> logger,
            IServiceProvider serviceProvider,
            IRabbitMq rabbitMq
        )
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            this.rabbitMq = rabbitMq;
        }

        private async Task Execute<T>(Func<T, Task> action)
        {
            try
            {
                using var scope = serviceProvider.CreateScope();

                var service = scope.ServiceProvider.GetService<T>();
                if (service != null)
                    await action(service);
                else
                    logger.LogError($"Error: {action.ToString()} wasn`t resolved");
            }
            catch (Exception e)
            {
                logger.LogError($"Error: {RabbitMqTaskQueueNames.SEND_EMAIL}: {e.Message}");
                throw;
            }
        }

        public void Start()
        {
            rabbitMq.Subscribe<EmailModel>(RabbitMqTaskQueueNames.SEND_EMAIL, async data
                => await Execute<IEmailSender>(async service =>
                {
                    await service.Send(data);
                }));
        }
    }
}
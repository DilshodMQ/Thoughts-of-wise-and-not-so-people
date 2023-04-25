using DsrProject.Consts;
using DsrProject.Services.EmailSender;
using DsrProject.Services.RabbitMq;

namespace DsrProject.Services.Actions
{
    public class Action : IAction
    {
        private readonly IRabbitMq rabbitMq;

        public Action(IRabbitMq rabbitMq)
        {
            this.rabbitMq = rabbitMq;
        }

        public async Task SendEmail(EmailModel email)
        {
            await rabbitMq.PushAsync(RabbitMqTaskQueueNames.SEND_EMAIL, email);
        }
    }
}
